using UnityEngine;
using System.Collections;
using UnityEditor;

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
	}
}
