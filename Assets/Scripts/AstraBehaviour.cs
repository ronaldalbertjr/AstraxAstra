using UnityEngine;
using System.Collections;

public class AstraBehaviour : MonoBehaviour 
{
    float w;
    float h;
	[SerializeField] float speed;
    bool faceRight;
    void FixedUpdate()
    {
        w = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(w * speed, h * speed);

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
