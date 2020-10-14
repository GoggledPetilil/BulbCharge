using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Data")]
    public int m_ID;
    private Vector2 m_OriginScale;
    public float m_RayCastLength;
    
    [Header("Movement")]
    [SerializeField] private float m_MoveSpeed;
    public Vector2 m_Movement;
    private bool m_FacingRight;
    public float m_LinearDrag;

    [Header("Trail")] 
    public Material m_Material;

    [Header("Components")] 
    public GameObject m_Graphics;
    public Animator m_ani;
    public Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_FacingRight = false;
        m_rb = GetComponent<Rigidbody2D>();
        m_OriginScale = new Vector2(m_Graphics.transform.localScale.x, m_Graphics.transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.m_instance.m_GameStarted == true)
        {
            m_Movement = new Vector2(Input.GetAxis("Horizontal" + m_ID.ToString()), Input.GetAxis("Vertical" + m_ID.ToString()));
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(m_Movement.x, m_Movement.y);
        ModifyDrag();
    }

    void MoveCharacter(float directionX, float directionY)
    {
        m_rb.velocity = new Vector2(directionX * m_MoveSpeed, directionY * m_MoveSpeed);
        
        m_ani.SetFloat("Horizontal", Mathf.Abs(m_rb.velocity.x));
        m_ani.SetFloat("Vertical", Mathf.Abs(m_rb.velocity.y));

        if (directionX > 0 && m_FacingRight == false)
        {
            Flip(true);
        } else if (directionX < 0 && m_FacingRight == true)
        {
            Flip(false);
        }
    }

    void ModifyDrag()
    {
        if (Mathf.Abs(m_Movement.x) < 0.5f && Mathf.Abs(m_Movement.y) < 0.5f)
        {
            m_rb.drag = m_LinearDrag;
        }
        else
        {
            m_rb.drag = 0f;
        }
    }
    
    void Flip(bool state)
    {
        m_FacingRight = state;
        transform.rotation = Quaternion.Euler(0, m_FacingRight ? 180 : 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Player")
        {
            Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
