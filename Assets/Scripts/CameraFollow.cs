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

	void Start ()
    {
        sceneIn = "Quarto";
	}
	void Update () 
    {
        switch(sceneIn)
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
        if (playerPosition.position.x > borders[1].transform.position.x && playerPosition.position.x < borders[0].transform.position.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x + offset.x, 0f, -14f);
        }
        else if(playerPosition.position.x < borders[1].transform.position.x)
        {
            this.transform.position =  new Vector3(camPos[0].transform.position.x, 0f, -14f);
        }
        else if (playerPosition.position.x > borders[0].transform.position.x + offset.x)
        {
            this.transform.position = new Vector3(camPos[1].transform.position.x, 0f, -14f);
        }
	}
}
