using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScriptsUI : MonoBehaviour
{
    private Movement _mvmt;
    private Cube_Script _cube;
    private bool flags = true;


    float startTime = 0f;
    public float RestartTime = 0.1f;

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StepBack()
    {
        if (_mvmt.GetIsMoving())
        {
            return;
        }
        if (flags && !_mvmt.IsMovingBack())
        {
            if (!_mvmt.GetIsRendering())
            {
                _mvmt.SetIsRendering(true);
            }
            _mvmt.RealRemove();
            flags = false;
            StartCoroutine(Wait());
        }
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update()
    {
        _cube = FindObjectOfType<Cube_Script>();
        _mvmt = FindObjectOfType<Movement>();

        if (_mvmt != null)
        {
            var result = _mvmt.GetCurrentMovementResults();
            if (result == Movement.MovementResult.Win)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            startTime = Time.time;
        }else 
        if (Input.GetKey(KeyCode.R))
        {
            if(Time.time - startTime >= RestartTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                startTime = float.PositiveInfinity;
            }
        }
        else
        {
            startTime = float.PositiveInfinity;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        flags = true;
    }
}
