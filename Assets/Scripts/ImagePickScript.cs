using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ImagePickScript : MonoBehaviour 
{
    [SerializeField]
    Canvas enterButton;
    [SerializeField]
    Image btnEnter;
    [HideInInspector]
    public bool canBePicked = false;
    bool picturePicked;
	void Awake () 
    {
        enterButton.enabled = false;
        btnEnter.color = new Color(btnEnter.color.r, btnEnter.color.g, btnEnter.color.b, 0);
	}
	void Update () 
    {
        if (picturePicked) pickPicture();

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
        if((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)) && col.gameObject.tag == "Player" && canBePicked)
        {
            picturePicked = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && canBePicked)
        enterButton.enabled = false;
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
    IEnumerator FadeIn()
    {
        Color color;
        color = btnEnter.color;
        while(btnEnter.color.a != 1)
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
