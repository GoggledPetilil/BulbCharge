using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource m_Aud;
    public AudioClip m_GameClip;
    public AudioClip m_EndClip;
    private bool m_Started;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Aud = GetComponent<AudioSource>();
        m_Aud.clip = m_GameClip;
        m_Aud.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.m_instance.m_GameStarted == true)
        {
            if (m_Started == false)
            {
                m_Started = true;
                m_Aud.Play();
            }
            else if (m_Started == true && m_Aud.isPlaying == false)
            {
                GameManager.m_instance.m_GameEnded = true;
                m_Aud.clip = m_EndClip;
                m_Aud.loop = true;
                m_Aud.Play();
            }
                
        }
    }
}
