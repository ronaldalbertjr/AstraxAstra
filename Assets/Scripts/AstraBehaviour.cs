using UnityEngine;
using System.Collections;

public class AstraBehaviour : MonoBehaviour 
{
    float w;
    float h;
	void Start () 
    {
	
	}
    void FixedUpdate()
    {
        w = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(w, h);
    }
}
