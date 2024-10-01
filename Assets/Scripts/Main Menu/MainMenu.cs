using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HowtoPlayUI;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void HowtoPlay()
    {
        HowtoPlayUI.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
