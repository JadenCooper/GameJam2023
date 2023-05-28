using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HelpMenu()
    {
        if (!helpMenu.activeSelf)
        {
            mainMenu.SetActive(false);
            helpMenu.SetActive(true);
        }
        else
        {
            Button backButton = GameObject.Find("BackButton").GetComponent<Button>();

            if (EventSystem.current.currentSelectedGameObject == backButton.gameObject)
            {
                mainMenu.SetActive(true);
                helpMenu.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
