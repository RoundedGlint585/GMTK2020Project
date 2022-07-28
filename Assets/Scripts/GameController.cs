using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string Size = "16x16";

    [SerializeField] private string[] _nameStates;
    [SerializeField] private Side[] _SideState;
    private Dictionary<string, Side> _statesSides= new Dictionary<string, Side>();

    private void Awake()
    {
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
