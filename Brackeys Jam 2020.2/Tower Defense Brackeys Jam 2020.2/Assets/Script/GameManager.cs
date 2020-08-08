using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] menus;
    private int maxMenuIndex;

    private void Start()
    {
        maxMenuIndex = menus.Length - 1;
    }

    public void GameOver()
    {
        for (int i = 0; i < maxMenuIndex; i++)
        {
            menus[i].SetActive(false);
        }
        menus[maxMenuIndex].SetActive(true);
    }
}
