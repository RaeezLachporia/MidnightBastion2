using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower1 : MonoBehaviour
{
    public GameObject PausePanel;
    public void Start()
    {
        PausePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }    
}
