using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScriptsUI : MonoBehaviour
{
    private Movement _mvmt;
    private Cube_Script _cube;

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StepBack()
    {
        _cube.ReMove();
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        _cube = FindObjectOfType<Cube_Script>();
        _mvmt = FindObjectOfType<Movement>();
        
        var result = _mvmt.GetCurrentMovementResults();

        if(result == Movement.MovementResult.Die)
        {
            StepBack();
        }

        if(result == Movement.MovementResult.Win)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
