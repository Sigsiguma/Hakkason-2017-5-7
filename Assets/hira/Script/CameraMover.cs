using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private const float m_moveSpeed = 0.4f;

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += m_moveSpeed;
            transform.position = pos;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x -= m_moveSpeed;
            transform.position = pos;
        }

        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.y += m_moveSpeed;
            transform.position = pos;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y -= m_moveSpeed;
            transform.position = pos;
        }
    }


	void Update ()
    {
        Move();
    }
}
