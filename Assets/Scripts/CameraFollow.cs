using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;
    public Transform playerPosition;
    public string sceneIn;
    [SerializeField]
    public GameObject[] borders =  new GameObject[2];
    [SerializeField]
    public  GameObject[] camPos;
    [SerializeField]
    public bool onDoorEnter;

	void Start ()
    {
        sceneIn = "Quarto";
        OnDoorEnter();
        offset.y = playerPosition.position.y;
	}
	void Update () 
    {
        Debug.Log(borders[0].tag);
        UpdateCamPos();
   	}

    public void OnDoorEnter()
    {
        switch (sceneIn)
        {
            case "Quarto":
                borders = GameObject.FindGameObjectsWithTag("Border/Quarto");
                camPos = GameObject.FindGameObjectsWithTag("camPos/Quarto");
                break;
            case "Sala":
                borders = GameObject.FindGameObjectsWithTag("Border/Sala");
                camPos = GameObject.FindGameObjectsWithTag("camPos/Sala");
                break;
        }
    }
    void UpdateCamPos()
    {
        if (playerPosition.position.x > borders[1].transform.position.x && playerPosition.position.x < borders[0].transform.position.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x + offset.x, offset.y, -14f);
        }
        else if (playerPosition.position.x < borders[1].transform.position.x)
        {
            this.transform.position = new Vector3(camPos[0].transform.position.x, offset.y, -14f);
        }
        else if (playerPosition.position.x > borders[0].transform.position.x + offset.x)
        {
            this.transform.position = new Vector3(camPos[1].transform.position.x, offset.y, -14f);
        }
    }
}
