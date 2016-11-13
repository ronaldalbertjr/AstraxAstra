using UnityEngine;
using System.Collections;

public class DespertadorScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool goingToStartPos = false;
    bool prateleiraRotated = false;
    Vector3 mousePosition;
    GameObject prateleira;
    GameObject foto;

    void Awake ()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        prateleira = GameObject.Find("prateleira");
        foto = GameObject.Find("foto");
    }
    
    void Update()
    {
        if (goingToStartPos && !prateleiraRotated)
        {
            prateleiraCollided();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider.gameObject == this.gameObject)
                {
                    rb.AddForce(Vector2.up * 100, ForceMode2D.Force);
                    anim.SetBool("Shaking", true);
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("prateleira"))
        {
            goingToStartPos = true;
        }
    }
    IEnumerator rotatePrateleira()
    {
        while(Vector3.Distance(prateleira.transform.eulerAngles, new Vector3(0f,0f,330f)) > 1)
        {
            prateleira.transform.rotation = Quaternion.Lerp(prateleira.transform.rotation, Quaternion.Euler(0f, 0f, 330f), Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        prateleiraRotated = true;
        yield return 0;
    }
    void prateleiraCollided()
    {
        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(-9.08f, 4.11f, 0), 2 * Time.deltaTime);
        rb.Sleep();
        anim.SetBool("Shaking", false);
        foto.GetComponent<ImagePickScript>().canBePicked = true;
        StartCoroutine(rotatePrateleira());
    }
}
