using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChange : MonoBehaviour
{
    private SpriteRenderer m_sr;
    public int m_Owner;

    // Start is called before the first frame update
    void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
        m_Owner = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMove pm = other.gameObject.GetComponent<PlayerMove>();
            m_sr.material = pm.m_Material;
            if (GameManager.m_instance.m_GameEnded == false)
            {
                if (m_Owner != 0)
                {
                    GameManager.m_instance.DecreaseScore(m_Owner - 1);
                    GameManager.m_instance.UpdateScore(m_Owner - 1);
                }
                m_Owner = pm.m_ID;
                GameManager.m_instance.IncreaseScore(m_Owner - 1);
                GameManager.m_instance.UpdateScore(m_Owner - 1);
            }
        }
    }
}
