using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] menus;
    private int maxMenuIndex;
    public bool gameOver;

    private void Awake()
    {
        maxMenuIndex = menus.Length - 1;
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;

        for (int i = 0; i < maxMenuIndex; i++)
        {
            menus[i].SetActive(false);
        }
        menus[maxMenuIndex].SetActive(true);
    }
}
