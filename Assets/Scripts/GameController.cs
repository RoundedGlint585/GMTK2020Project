using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string Size = "8x8";

    [SerializeField] private string[] _nameStates;
    [SerializeField] private Side[] _SideState;
    private Dictionary<string, Side> _statesSides= new Dictionary<string, Side>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_SideState.Length == _nameStates.Length)
        {
            for(int i = 0; i < _SideState.Length; i++)
            {
                _statesSides.Add(_nameStates[i], _SideState[i]);
            }
        }
    }

    public  Side FindPrefsState(string nameState)
    {
        if (_statesSides.ContainsKey(nameState))
        {
            return  _statesSides[nameState];
        }
        else
        {
            return null;
        }
    }
}
