using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStars : MonoBehaviour
{
    [SerializeField] private GameObject m_Star;
    [SerializeField] private int m_StarAmount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_StarAmount; i++)
        {
            SpawnStar();
        }
    }
    
    private void SpawnStar()
    {
        Vector2 spawnCoord = new Vector3(0, 0, 0);
        float m_ScreenSizeX = 5.0f;
        float m_ScreenSizeY = 5.0f;
        float X_coord = Random.Range(-m_ScreenSizeX, m_ScreenSizeX);
        float Y_coord = Random.Range(-m_ScreenSizeY, m_ScreenSizeY);
        float z = -2;
        spawnCoord = new Vector3(X_coord / 2, Y_coord / 2, z);
        GameObject star = Instantiate(m_Star, spawnCoord, Quaternion.identity) as GameObject;
    }
}
