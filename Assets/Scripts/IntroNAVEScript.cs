using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroNAVEScript : MonoBehaviour
{
    [SerializeField] Image fadingPanel;
    [SerializeField]
    float fadeDuration;
    float alpha = 1;
    bool fadingIn = true;
	void Start ()
    {
    }
	void Update ()
    {
        if(fadingIn)
        {
            FadeIn();
        }
        else
        {
            Invoke("FadeOut", 3);
            Invoke("LoadGame", 6);
        }
        if(fadingPanel.color.a <= 0)
        {
            fadingIn = false;
        }
    }
    void FadeIn()
    {
        alpha -= Time.deltaTime * fadeDuration;
        fadingPanel.color = new Color(fadingPanel.color.r, fadingPanel.color.g, fadingPanel.color.b, alpha);
    }
    void FadeOut()
    {
        alpha += Time.deltaTime * fadeDuration;
        fadingPanel.color = new Color(fadingPanel.color.r, fadingPanel.color.g, fadingPanel.color.b, alpha);
    }
    void LoadGame()
    {
        Application.LoadLevel("casa");
    }
}
