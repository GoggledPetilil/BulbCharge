using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator m_Animator;
    public float m_TransitionTime;
    
    void Start()
    {
        GameManager.m_instance.ScoreToZero();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame(0);
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetGame(-1);
        }   
    }

    public void ResetGame(int sceneID)
    {
        StartCoroutine(Transition(sceneID));
    }

    IEnumerator Transition(int sceneID)
    {
        m_Animator.SetTrigger("Start");
        yield return new WaitForSeconds(m_TransitionTime);
        if (sceneID < 0)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
