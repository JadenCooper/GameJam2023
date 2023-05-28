using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
