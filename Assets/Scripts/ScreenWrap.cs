using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public Vector2 m_Offset;

    private void OnTriggerEnter2D(Collider2D other)
    {
        float x = -other.transform.position.x + m_Offset.x;
        float y = other.transform.position.y + m_Offset.y;
        float z = other.transform.position.z;
        other.transform.position = new Vector3(x, y, z);
    }
}
