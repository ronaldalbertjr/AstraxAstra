using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    Image transitionImage;
    float alpha = 0;
    bool keyPressed = false;
	void Update ()
    {
        if(Input.anyKey && !keyPressed)
        {
            keyPressed = true;
            StartCoroutine("menuEnumerator");
        }
	
	}

    IEnumerator menuEnumerator()
    {
        while (alpha < 1)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }
        Application.LoadLevel("casa");

    }
}
