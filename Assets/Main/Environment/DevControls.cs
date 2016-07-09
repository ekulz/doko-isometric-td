using UnityEngine;
using System.Collections;
using UnityEditor;

/*
    Use this to add custom controls for development
*/

public class DevControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NavMeshBuilder.BuildNavMesh();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

        }
	}
}
