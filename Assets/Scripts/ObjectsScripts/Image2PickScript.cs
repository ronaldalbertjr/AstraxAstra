using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Image2PickScript : MonoBehaviour 
{
    [HideInInspector]
    public bool canBePicked;
    bool picturePicked;
    [SerializeField]
    Canvas enterButton;
    [SerializeField]
    Image btnEnter;
	void Start () 
    {
        enterButton.enabled = false;
        btnEnter.color = new Color(btnEnter.color.r, btnEnter.color.g, btnEnter.color.b, 0);
	}
	void Update () 
    {
        if (canBePicked && picturePicked) pickPicture(); 
	}
    void pickPicture()
    {
        this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.black, 0.7f);
        if (this.GetComponent<SpriteRenderer>().color == Color.black)
        {
            enterButton.enabled = false;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canBePicked)
        {
            enterButton.enabled = true;
            StartCoroutine(FadeIn());
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)) && col.gameObject.tag == "Player" && canBePicked)
        {
            picturePicked = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && canBePicked)
            enterButton.enabled = false;
    }
    IEnumerator FadeIn()
    {
        Color color;
        color = btnEnter.color;
        while (btnEnter.color.a != 1)
        {
            while (color.a < 1)
            {
                color.a += 0.1f;
                btnEnter.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            break;
        }
    }
}
