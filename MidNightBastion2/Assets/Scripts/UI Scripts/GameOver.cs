using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene"); //loads game scene and sets time to 1 so that it is not paused
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit(); 
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}