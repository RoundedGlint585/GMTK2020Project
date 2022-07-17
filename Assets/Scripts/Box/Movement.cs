using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube_Script))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 3;
    private bool _isMoving;
    private Cube_Script _cubeScript;
    private GameController _gameController;
    private StateSides[] _stateSides;
    GameObject[] walls = null;
    GameObject[] tiles = null;
    GameObject[] monsters = null;
    GameObject[] acidTiles = null;
    GameObject[] poisonTiles = null;
    GameObject[] fireTiles = null;
    GameObject[] cleanerTiles = null;
    GameObject[] CubeSides = null;
    GameObject currentFaceDown = null;
    MovementResult movementResult;
    private void Start()
    {
        _cubeScript = GetComponent<Cube_Script>();
        _gameController = FindObjectOfType<GameController>();
        _stateSides = FindObjectsOfType<StateSides>();
    }

    enum MovementResult
    {
        Die,
        CannotMove,
        CanMove,
        PaintIntoAcid,
        PaintIntoFire,
        PaintIntoPoison,
        PaintIntoEmpty,
        KillMonster,
        Win,

    }


    private void UpdateSide()
    {
        StateSides stateSides = currentFaceDown.GetComponent<StateSides>();
        if (movementResult == MovementResult.PaintIntoAcid)
        {
            if (stateSides.GetCurrentState() == "Empty")
            {
                stateSides.AddMoveSide("Acid");
            }

        }
        if (movementResult == MovementResult.PaintIntoFire)
        {
            if (stateSides.GetCurrentState() == "Empty")
            {
                stateSides.AddMoveSide("Fire");
            }
        }
        if (movementResult == MovementResult.PaintIntoPoison)
        {
            if (stateSides.GetCurrentState() == "Empty")
            {
                stateSides.AddMoveSide("Posion");
            }
        }        
        if (movementResult == MovementResult.PaintIntoEmpty)
        {

            stateSides.AddMoveSide("Empty");
        }
    }

    private void UpdateFaceDown()
    {
        foreach(GameObject obj in CubeSides)
        {
            if (obj.transform.up == new Vector3(0.0f, -1.0f, 0.0f))
            {
                currentFaceDown = obj;
                return;
            }
        }
        return;
    }

    private MovementResult MovementCheck(KeyCode keyCode)
    {
        float x = transform.position.x;
        float z = transform.position.z;
        if (keyCode == KeyCode.A)
        {
            x -= 4;
        }
        if (keyCode == KeyCode.D)
        {
            x += 4;
        }
        if (keyCode == KeyCode.W)
        {
            z += 4;
        }
        if (keyCode == KeyCode.S)
        {
            z -= 4;
        }
        foreach (GameObject obj in walls)
        {
            if (Mathf.Approximately(x, obj.transform.position.x) && Mathf.Approximately(z, obj.transform.position.z))
            {
                return MovementResult.CannotMove;
            }
        }
        foreach(GameObject obj in monsters)
        {
            if (Mathf.Approximately(x, obj.transform.position.x) && Mathf.Approximately(z, obj.transform.position.z))
            {
                if (!obj.transform.Find("Monster").gameObject.active)
                {
                    return MovementResult.CanMove;
                }
                obj.transform.Find("Monster").gameObject.SetActive(false);
                if (monsters.Length == 1)
                {
                    return MovementResult.CanMove;
                    return MovementResult.Win;
                }
                else
                {

                    return MovementResult.CanMove;
                    return MovementResult.KillMonster;
                }
            }
        }
        foreach (GameObject obj in acidTiles)
        {
            if (Mathf.Approximately(x, obj.transform.position.x) && Mathf.Approximately(z, obj.transform.position.z))
            {
                return MovementResult.PaintIntoAcid;
            }
        }
        foreach (GameObject obj in poisonTiles)
        {
            if (Mathf.Approximately(x, obj.transform.position.x) && Mathf.Approximately(z, obj.transform.position.z))
            {
                return MovementResult.PaintIntoPoison;
            }
        }

        foreach (GameObject obj in fireTiles)
        {
            if (Mathf.Approximately(x, obj.transform.position.x) && Mathf.Approximately(z, obj.transform.position.z))
            {
                return MovementResult.PaintIntoFire;
            }
        }
        foreach (GameObject obj in tiles)
        {
            if (Mathf.Approximately(x, obj.transform.position.x) && Mathf.Approximately(z, obj.transform.position.z))
            {
                return MovementResult.CanMove;
            }
        }
        return MovementResult.CannotMove;
    }

    private void Update()
    {

        if (walls == null)
        {
            walls = GameObject.FindGameObjectsWithTag("Wall");
        }
        if (tiles == null)
        {
            tiles = GameObject.FindGameObjectsWithTag("Tile");
        }
        if (monsters == null)
        {
            monsters = GameObject.FindGameObjectsWithTag("Monster");
        }
        if (CubeSides == null)
        {
            CubeSides = GameObject.FindGameObjectsWithTag("CubeSide");
        }
        if (acidTiles == null)
        {
            acidTiles = GameObject.FindGameObjectsWithTag("Acid");
        }
        if (poisonTiles == null)
        {
            poisonTiles = GameObject.FindGameObjectsWithTag("Poison");
        }
        if (fireTiles == null)
        {
            fireTiles = GameObject.FindGameObjectsWithTag("Fire");
        }

        if (_isMoving) return;

        if (_gameController != null)
        {

            MovementResult result;
            if (Input.GetKey(KeyCode.A))
            {
                movementResult = MovementCheck(KeyCode.A);
                if (movementResult > MovementResult.CannotMove)
                {
                    LeftMove(true);
                    ChangeSide();
                }
            }else if(Input.GetKey(KeyCode.D))
            {
                movementResult = MovementCheck(KeyCode.D);
                if (movementResult > MovementResult.CannotMove)
                {
                    RightMove(true);
                    ChangeSide();
                }
            } else if (Input.GetKey(KeyCode.W))
            {
                movementResult = MovementCheck(KeyCode.W);
                if (movementResult > MovementResult.CannotMove)
                {
                    ForwardMove(true);
                    ChangeSide();
                }
            } else if (Input.GetKey(KeyCode.S))
            {
                movementResult = MovementCheck(KeyCode.S);
                if (movementResult > MovementResult.CannotMove)
                {
                    BackMove(true);
                    ChangeSide();
                }
            } else if (Input.GetKey(KeyCode.V))
            {
                //todo update faceDown
                _cubeScript.ReMove();
                RemoveSide();
            }
        }
           
    }

    public void LeftMove(bool is_user)
    {
        Assemble(Vector3.left);
        if (is_user) _cubeScript.AddMove("left");
    }

    public void RightMove(bool is_user)
    {
        Assemble(Vector3.right);
        if (is_user) _cubeScript.AddMove("right");
    }
    public void ForwardMove(bool is_user)
    {
        Assemble(Vector3.forward);
        if (is_user) _cubeScript.AddMove("forward");
    }

    public void BackMove(bool is_user)
    {
        Assemble(Vector3.back);
        if (is_user) _cubeScript.AddMove("back");
    }


    private void Assemble(Vector3 dir)
    {

        var anchor = transform.position + (Vector3.down + dir) * 2.0f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Roll(anchor, axis));
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        AudioSource audioSource = this.GetComponentInParent<AudioSource>();
        audioSource.Play();
        for (int i = 0; i < (90 / _rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        UpdateFaceDown();
        UpdateSide();
        _isMoving = false;
    }

    public void ChangeSide()
    {
        _stateSides = FindObjectsOfType<StateSides>();
        for( int i = 0; i < _stateSides.Length; i++)
        {
            _stateSides[i].AddMoveSide();
        }
    }

    public void RemoveSide()
    {
        _stateSides = FindObjectsOfType<StateSides>();
        for (int i = 0; i < _stateSides.Length; i++)
        {
            _stateSides[i].RemoveState();
        }
    }
}