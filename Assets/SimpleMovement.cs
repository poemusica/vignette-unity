using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleMovement : MonoBehaviour
{
    public float walkSpeed = 3;

    public KeyCode upKey = KeyCode.W;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode downKey = KeyCode.S;

    public KeyCode upKeyAlt = KeyCode.None;
    public KeyCode leftKeyAlt = KeyCode.None;
    public KeyCode rightKeyAlt = KeyCode.None;
    public KeyCode downKeyAlt = KeyCode.None;

    void Awake()
    {
        if (GetComponent<CharacterController>() == null)
            gameObject.AddComponent<CharacterController>();
    }

    void Start()
    {

    }

    void Update()
    {

        UpdateMovement();
    }

    void UpdateMovement()
    {
        Vector3 _movementDirection = Vector3.zero;
        float _movementAmount = 0;


        if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt))
        {
            _movementDirection -= new Vector3(1, 0, 0);
        }
        if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt))
        {
            _movementDirection += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(upKey) || Input.GetKey(upKeyAlt))
        {
            _movementDirection += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(downKey) || Input.GetKey(downKeyAlt))
        {
            _movementDirection -= new Vector3(0, 1, 0);
        }

        _movementAmount = walkSpeed * Time.smoothDeltaTime;

        Vector3 _current = transform.position;


        GetComponent<CharacterController>().Move(_movementDirection.normalized * _movementAmount);
    }
}