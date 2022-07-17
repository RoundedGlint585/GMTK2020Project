using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScriptsUI : MonoBehaviour
{
    private Movement _mvmt;

    public void Start()
    {
        _mvmt = GetComponent<Movement>();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StepBack()
    {

    }

    public void Update()
    {
    }
}
