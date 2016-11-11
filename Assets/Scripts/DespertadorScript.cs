using UnityEngine;
using System.Collections;

public class DespertadorScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool goingToStartPos = false;
    private float shakeAmount = 0.1f;

    void Awake ()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (goingToStartPos)
        {
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(-9.08f, 4.11f, 0),2 * Time.deltaTime);
            rb.Sleep();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(Input.mousePosition.x, Input.mousePosition.y), Vector2.zero, 0);
                if (hit.collider.gameObject == this.gameObject)
                {
                    rb.AddForce(Vector2.up * 10, ForceMode2D.Force);
                    this.transform.localPosition = this.transform.localPosition + Random.insideUnitSphere * shakeAmount;
                }
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("prateleira"))
        {
            goingToStartPos = true;
        }
    }
}
