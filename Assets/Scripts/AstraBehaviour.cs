using UnityEngine;
using System.Collections;

public class AstraBehaviour : MonoBehaviour 
{
    [SerializeField]
    float speed;
    float w;
    float h;
    bool faceRight;
    bool walkController;
    Animator anim;
    Rigidbody2D rb;
    void Awake()
    {
        Physics2D.IgnoreCollision(GameObject.Find("prateleira").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("fotoQuarto").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("pictureCollider").GetComponent<EdgeCollider2D>(), this.GetComponent<BoxCollider2D>());
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        CheckWalkAnimation();

        w = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(w * speed, h * speed);

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
