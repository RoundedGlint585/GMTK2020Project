using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Script : MonoBehaviour
{
    private Stack<string> _moveCube = new Stack<string>();

    private Movement _movment;


    private void Start()
    {
        _movment = GetComponent<Movement>();
    }

    public void AddMove(string move)
    {
        _moveCube.Push(move);
    }

    public void ReMove()
    { if (_moveCube.Count > 0)
        {
            switch (_moveCube.Pop())
            {
                case "forward":
                    _movment.BackMove(false);
                    break;

                case "back":
                    _movment.ForwardMove(false);
                    break;

                case "left":
                    _movment.RightMove(false);
                    break;

                case "right":
                    _movment.LeftMove(false);
                    break;
            }

        }
    }
}
