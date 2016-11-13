using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;
    public Transform playerPosition;
    public string sceneIn;
    [HideInInspector]
    public GameObject[] borders =  new GameObject[2];
    [HideInInspector]
    public  GameObject[] camPos;
    [HideInInspector]
    public bool onDoorEnter;

	void Start ()
    {
        sceneIn = "Quarto";
        OnDoorEnter();
        offset.y = playerPosition.position.y;
	}
	void Update () 
    {
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
            case "Corredor":
                borders = GameObject.FindGameObjectsWithTag("Border/Corredor");
                camPos = GameObject.FindGameObjectsWithTag("camPos/Corredor");
                break;
            case "Sala":
                borders = GameObject.FindGameObjectsWithTag("Border/Sala");
                camPos = GameObject.FindGameObjectsWithTag("camPos/Sala");
                break;
			case "Cozinha":
				borders = GameObject.FindGameObjectsWithTag("Border/Cozinha");
				camPos = GameObject.FindGameObjectsWithTag("camPos/Cozinha");
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
        else if (playerPosition.position.x > borders[0].transform.position.x)
        {
            this.transform.position = new Vector3(camPos[1].transform.position.x, offset.y, -14f);
        }
    }
}
