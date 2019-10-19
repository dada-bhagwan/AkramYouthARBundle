using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToAkramYouthAR()
    {
        SceneManager.LoadScene("AkramYouthAR");
    }


    public void GoToVideo()
    {
        SceneManager.LoadScene("Video");
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void OpenYouthApp()
    {
        Application.OpenURL("market://details?id=org.dadabhagwan.youth");
    }
}
