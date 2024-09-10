using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool Paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Restart()
    {
        if (Paused = true)
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
