using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_script : MonoBehaviour
{
    public GameObject CanvasMain;
    public GameObject CanvasPlay;


    public void Play()
    {
        CanvasMain.SetActive(false);
        CanvasPlay.SetActive(true);
    }
    public void SinglePlayer() 
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMain()
    {
        CanvasMain.SetActive(true);
        CanvasPlay.SetActive(false);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }


}
