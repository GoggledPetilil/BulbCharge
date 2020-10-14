using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager m_instance;
    public bool m_GameStarted;
    public bool m_GameEnded;
    
    [Header("Screen Ration")]
    public Vector3 m_Center;
    public float m_ScreenX;
    public float m_ScreenY;

    [Header("Player Score")]
    public int[] m_PlayerScore;
    public Text[] m_PlayerText;
    public int m_TileScore;
    public int m_HighestPlayer;
    public int m_HighestScore;
    
    // Start is called before the first frame update
    void Start()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && m_GameStarted == false)
        {
            m_GameStarted = true;
        }
    }

    public void IncreaseScore(int PlayerID)
    {
        m_PlayerScore[PlayerID] += m_TileScore;
        UpdateScore(PlayerID);
    }
    
    public void DecreaseScore(int PlayerID)
    {
        m_PlayerScore[PlayerID] -= m_TileScore;
        UpdateScore(PlayerID);
    }

    public void ClearAll()
    {
        m_GameStarted = false;
        m_GameEnded = false;
        ScoreToZero();
    }
    
    public void ScoreToZero()
    {
        for (int i = 0; i < m_PlayerText.Length; i++)
        {
            m_PlayerText[i].text = 0.ToString();
        }
        m_HighestPlayer = 0;
        m_HighestScore = 0;
    }
    
    public void UpdateScore(int PlayerID)
    {
        m_PlayerText[PlayerID].text = m_PlayerScore[PlayerID].ToString();
    }

    public void UpdateHighest()
    {
        for (int i = 0; i < m_PlayerScore.Length; i++)
        {
            if (m_PlayerScore[i] > m_HighestScore)
            {
                m_HighestScore = m_PlayerScore[i];
                m_HighestPlayer = i;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 m_ScreenSize = new Vector2(m_ScreenX, m_ScreenY);
        Gizmos.DrawWireCube(m_Center, m_ScreenSize);
    }
}
