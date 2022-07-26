using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSides : MonoBehaviour
{
    [SerializeField] string _nameState;
    private GameController _gameController;
    [SerializeField] private GameObject _gameObjectDad;
    private Stack<string> _newState = new Stack<string>();
    private Side _side;
    private Side prefside;
    private Movement movement;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        movement = FindObjectOfType<Movement>();
        prefside = _gameController.FindPrefsState(_nameState);

        _side = Instantiate(prefside, _gameObjectDad.gameObject.transform.position, _gameObjectDad.gameObject.transform.rotation, _gameObjectDad.gameObject.transform);
        _newState.Push(_nameState);
    }

    public void AddMoveSide(string newState)
    {
        _nameState = newState;
        _newState.Push(newState);
        prefside = _gameController.FindPrefsState(newState);
        Destroy(_side.gameObject);
        _side = Instantiate(prefside, _gameObjectDad.gameObject.transform.position, _gameObjectDad.gameObject.transform.rotation, _gameObjectDad.gameObject.transform);
    }

    public void AddMoveSide()
    {
        _newState.Push(_nameState);
    }

    public void RemoveState()
    {
        if (_newState.Count > 1)
        {
            string oneState = _newState.Pop();
            if (oneState != _newState.Peek())
            {
                GameObject obj = movement.GetCurrentTile();
                if (oneState != "Empty")
                {
                    
                    obj.transform.tag = oneState;
                    obj.transform.Find(oneState + "(Placeholder)").gameObject.SetActive(true);
                    obj.transform.Find("default").gameObject.SetActive(true);
                    movement.UpdateTileType(oneState);
                    movement.UpdateTileType("Tile");
                    _nameState = "Empty";
                }
                else
                {
                    obj.transform.tag = "Cleaner";
                    obj.GetComponentInChildren<CleanerTile>().AddLife();
                    movement.UpdateTileType("Cleaner");
                    movement.UpdateTileType("Tile");
                    _nameState = _newState.Peek();
                    _newState.Pop();
                }
                Destroy(_side.gameObject);
                prefside = _gameController.FindPrefsState(_newState.Peek());
                _side = Instantiate(prefside, _gameObjectDad.gameObject.transform.position, _gameObjectDad.gameObject.transform.rotation, _gameObjectDad.gameObject.transform);
                //_nameState = _newState.Peek();

            }
        }
    }

    public string GetCurrentState()
    {
        return _nameState;
    }
}
