using UnityEngine;
using System.Collections;

public class DoorEntered : MonoBehaviour 
{
    void Start()
    {

    }
	void Update () 
    {
        	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("oi");
    }
    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("collision");
        if(col.tag == "Player" && Input.GetKey(KeyCode.KeypadEnter))
        {
            col.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
