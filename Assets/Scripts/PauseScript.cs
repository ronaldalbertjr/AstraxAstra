using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<Canvas>().enabled = false;
    }
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Escape))
        {
            this.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }     
	}
    public void OnResumeClick()
    {
        this.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void OnReturnToMenuClick()
    {
        Application.LoadLevel("menu");
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}
