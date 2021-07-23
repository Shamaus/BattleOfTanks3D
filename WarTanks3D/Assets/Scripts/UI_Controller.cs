using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject shtab;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject win;
    public GameObject lose;

    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (!enemy1 && !enemy2 && !enemy3)
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
        if (!player || !shtab)
        {
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
