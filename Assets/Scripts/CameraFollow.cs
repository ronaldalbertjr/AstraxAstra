﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;
    public Transform playerPosition;
    public GameObject[] camPos;
    GameObject[] borders =  new GameObject[2];

	void Start ()
    {
        borders = GameObject.FindGameObjectsWithTag("Border");
	}
	void Update () 
    {
        if (playerPosition.position.x > borders[1].transform.position.x && playerPosition.position.x < borders[0].transform.position.x)
        {
            this.transform.position = new Vector3(playerPosition.position.x + offset.x, 0f, -14f);
        }
        else if(playerPosition.position.x < borders[1].transform.position.x)
        {
            this.transform.position =  new Vector3(camPos[0].transform.position.x, 0f, -14f);
        }
        else if (playerPosition.position.x > borders[0].transform.position.x)
        {
            this.transform.position = new Vector3(camPos[1].transform.position.x, 0f, -14f);
        }
	}
}