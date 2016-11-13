using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DoorEntered : MonoBehaviour 
{
    [SerializeField]
    AudioSource doorOpen;
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
            FadeIn();   
        }
        else if(!transiting && alpha > 0)
        {
            FadeOut();
        }
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" && Input.GetKey(KeyCode.Return))
        {
            transiting = true;
            player = col.gameObject;
            cam.GetComponent<CameraFollow>().sceneIn = sceneTo;
            StartCoroutine(playDoorSound());
        }
    }
    void FadeIn()
    {
        alpha += 0.01f;
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
        if (alpha >= 1)
        {
            transiting = false;
        }
    }
    void FadeOut()
    {
        cam.GetComponent<CameraFollow>().OnDoorEnter();
        cam.GetComponent<CameraFollow>().offset.y = player.transform.position.y;
		if (sceneTo == "Cozinha") 
		{
			cam.GetComponent<CameraFollow>().offset.y = -20.4f;
		}
        player.transform.position = positionTo;
        alpha -= 0.01f;
        transitionImage.color = new Color(transitionImage.color.r, transitionImage.color.g, transitionImage.color.b, alpha);
    }
    IEnumerator playDoorSound()
    {
        if (doorOpen != null)
        {
            doorOpen.Play();
            yield return new WaitForSeconds(3);
            doorOpen.Stop();
        }
    }
}
