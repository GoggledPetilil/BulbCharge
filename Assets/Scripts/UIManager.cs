using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text m_Instructions;
    public Image m_VictoryImage;
    public int m_Victor;
    public Sprite[] m_VictorImages;
    
    // Start is called before the first frame update
    void Start()
    {
        m_VictoryImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.m_instance.m_GameStarted == true && m_Instructions.enabled == true)
        {
            m_Instructions.enabled = false;
        }
        else if (GameManager.m_instance.m_GameEnded == true)
        {
            GameManager.m_instance.UpdateHighest();
            
            m_Victor = GameManager.m_instance.m_HighestPlayer;
            m_VictoryImage.sprite = m_VictorImages[m_Victor];
            m_VictoryImage.enabled = true;
        }
    }
}
