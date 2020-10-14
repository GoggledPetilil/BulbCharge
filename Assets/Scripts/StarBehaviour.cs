using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
    public int m_Score;
    
    public GameObject m_Sprite;
    public AudioSource m_as;
    public AudioClip m_Collected;

    // Start is called before the first frame update
    void Start()
    {
        m_as = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.m_instance.m_GameEnded == true)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        if (tag == "Player" || tag == "Ground" || tag == "Star")
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerMove pm = other.gameObject.GetComponent<PlayerMove>();
                int m_Owner = pm.m_ID;
                GameManager.m_instance.m_PlayerScore[m_Owner - 1] += m_Score;
                GameManager.m_instance.UpdateScore(m_Owner - 1);
                PlayAudio(m_Collected);
            }
            float m_ScreenSizeX = 5.0f;
            float m_ScreenSizeY = 9.0f;
            float X_coord = Random.Range(-m_ScreenSizeX, m_ScreenSizeX);
            float Y_coord = Random.Range(-m_ScreenSizeY, m_ScreenSizeY);
            float z = -2;
            Animator m_Ani = m_Sprite.GetComponent<Animator>();
            m_Ani.SetTrigger("Respawn");
            transform.position = new Vector3(X_coord / 2, Y_coord / 2, z);
        }
    }

    private void PlayAudio(AudioClip Clip)
    {
        m_as.clip = Clip;
        m_as.Play();
    }
}
