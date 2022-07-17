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

    private void Start()
    {
        _cubeScript = GetComponent<Cube_Script>();
        _gameController = FindObjectOfType<GameController>();
        _stateSides = FindObjectsOfType<StateSides>();
    }


    private void Update()
    {
        if (_isMoving) return;

        if (_gameController != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                LeftMove(true);
                ChangeSide();
                return;
            }

            if (Input.GetKey(KeyCode.D))
            {
                RightMove(true);
                ChangeSide();
                return;
            }
            if (Input.GetKey(KeyCode.W))
            {
                ForwardMove(true);
                ChangeSide();
                return;
            }
            if (Input.GetKey(KeyCode.S))
            {
                BackMove(true);
                ChangeSide();
                return;
            }

            if (Input.GetKey(KeyCode.V))
            {
                _cubeScript.ReMove();
                RemoveSide();
                return;
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