using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraCreditsScript : MonoBehaviour
{
    [SerializeField]
    Image transitionImage;
    float alpha = 0;
	void Start ()
    {
        StartCoroutine(CameraMovementOnCredits());
	}
    IEnumerator FadeIn()
    {
        while (alpha < 1)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOut()
    {
        while (alpha > 0)
        {
            alpha -= 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator CameraMovementOnCredits()
    {
        yield return new WaitForSeconds(5);

        while (alpha < 1)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        this.transform.position = new Vector3(33f, 0, -10f);

        while (alpha > 0)
        {
            alpha -= 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        while (this.transform.position.x < 56)
        {
            this.transform.position += new Vector3(0.01f, 0);
            yield return new WaitForSeconds(0.000001f);
        }

        yield return new WaitForSeconds(1);

        while (alpha < 1)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        this.transform.position = new Vector3(4.5f, -20.7f, -10f);

        while (alpha > 0)
        {
            alpha -= 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5);

        while (alpha < 1)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        this.transform.position = new Vector3(-18.2f, -20.2f, -10f);

        while (alpha > 0)
        {
            alpha -= 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5);

        while (alpha < 1)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        Application.LoadLevel("menu");
    }
}
