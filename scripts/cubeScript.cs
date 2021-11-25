using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum movement
{
    Up,
    Down,
    Right,
    Left,
}

public class cubeScript : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 10;
        rigidBody = GetComponent<Rigidbody>();
        keywordRecognizer.move += move;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void move(movement move) {
        switch (move)
        {
            case movement.Up:
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 1, 0) * Time.fixedDeltaTime * velocidad);
            break;
            case movement.Down:
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, -1, 0) * Time.fixedDeltaTime * velocidad);
            break;
            case movement.Right:
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 0, 1) * Time.fixedDeltaTime * velocidad);
            break;
            case movement.Left:
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 0, -1) * Time.fixedDeltaTime * velocidad);
            break;
            default:
            print("Internal error");
            break;
        }

    }
}
