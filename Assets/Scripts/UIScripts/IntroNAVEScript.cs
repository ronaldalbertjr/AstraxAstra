using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroNAVEScript : MonoBehaviour
{
    [SerializeField] Image fadingPanel;
    [SerializeField]
    Image naveImage;
    [SerializeField]
    Image seeducImage;
    [SerializeField]
    Image cejllImage;
    [SerializeField]
    Text texto;
    [SerializeField]
    float fadeDuration;
    float alpha = 1;
    bool fadingIn = true;
    int counter = 0;
	void Start ()
    {
        naveImage.enabled = false;
        cejllImage.enabled = false;
        texto.enabled = false;
    }
	void Update ()
    {
        if(fadingIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
        if (fadingPanel.color.a <= 0)
        {
            fadingIn = false;
        }
        else if(fadingPanel.color.a >= 1)
        {
            fadingIn = true;
            switch (counter)
            {
                case 0:
                    seeducImage.enabled = false;
                    cejllImage.enabled = true;
                    break;
                case 1:
                    cejllImage.enabled = false;
                    naveImage.enabled = true;
                    break;
                case 2:
                    naveImage.enabled = false;
                    texto.enabled = true;
                    break;
                case 3:
                    LoadGame();
                    break;
            }
            counter++;
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
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    void ChangeImage(ref Image actualImage, ref Image nextImage)
    {
        actualImage.enabled = false;
        nextImage.enabled = true;
    }
}
