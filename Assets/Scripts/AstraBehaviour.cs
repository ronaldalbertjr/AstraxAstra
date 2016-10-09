using UnityEngine;
using System.Collections;

public class AstraBehaviour : MonoBehaviour 
{
    float w;
    float h;
    bool faceRight;
	void Start () 
    {
	
	}
    void FixedUpdate()
    {
        w = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(w, h);

        if (w < 0 && !faceRight) Flip();
        else if (w > 0 && faceRight) Flip();
    }
    void Flip()
    {
        faceRight = !faceRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
