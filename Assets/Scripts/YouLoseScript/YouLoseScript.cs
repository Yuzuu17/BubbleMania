using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLoseScript : MonoBehaviour
{
    public GameObject YouLoseUI;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            YouLoseUI.SetActive(true);
            Debug.LogError("Help");
        }

    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
