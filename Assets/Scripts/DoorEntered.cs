using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorEntered : MonoBehaviour 
{
    public Image transitionImage;
    bool transiting = false;
    public string sceneTo;
    public Vector3 positionTo;
    float alpha;
    GameObject player;
    GameObject cam;
    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        alpha = 0;
    }
	void Update () 
    {
        if(transiting)
        {
            alpha += 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
            if(alpha >= 1)
            {
                transiting = false;
            }
        }
        else if(!transiting && alpha > 0)
        {
            player.transform.position = positionTo;
            alpha -= 0.01f;
            transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
        }
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" && Input.GetKey(KeyCode.Return))
        {
            transiting = true;
            player = col.gameObject;
            cam.GetComponent<CameraFollow>().sceneIn = sceneTo;
        }
    }
}
