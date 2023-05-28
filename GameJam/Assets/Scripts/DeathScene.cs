using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour
{
    public GameObject player;
    public CharacterStats playerStats;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
