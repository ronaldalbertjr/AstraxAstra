using UnityEngine;
using System.Collections;

public class PortaRetratoScript : MonoBehaviour
{
    [SerializeField]
    Sprite sp;
	void Start ()
    {
        Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>());
	}
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider.gameObject == this.gameObject)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sp;
            }
        }
	}
}
