using UnityEngine;
using System.Collections;

public class AstraBehaviour : MonoBehaviour 
{
    float w;
    float h;
	[SerializeField] float speed;
    bool faceRight;
    bool walkController;
    Animator anim;
    Rigidbody2D rb;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        w = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(w * speed, h * speed);

        CheckWalkAnimation();

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
    void CheckWalkAnimation()
    {
        walkController = (rb.velocity.x != 0 || rb.velocity.y != 0);
        anim.SetBool("walking", walkController);
    }
}
