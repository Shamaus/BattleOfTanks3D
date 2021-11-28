using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    private int numTanks;
    GameObject[] tanks;

    private void Start()
    {
        tanks = GameObject.FindGameObjectsWithTag("Enemy");
        numTanks = 0;
        foreach (GameObject tank in tanks)
        {
            tank.SetActive(false);
        }
        if (tanks.Length > 0)
            tanks[numTanks].SetActive(true);
        Time.timeScale = 1;
    }

    public void DestroyEnemy()
    {
        if (numTanks + 1 == tanks.Length)
        {
            WinLevel();
        }
        else
        {
            numTanks++;
            tanks[numTanks].SetActive(true);
        }
    }

    public void LoseLevel()
    {
        lose.SetActive(true);
        //Time.timeScale = 0;
    }

    void WinLevel()
    {
        win.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
