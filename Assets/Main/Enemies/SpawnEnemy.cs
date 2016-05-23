using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;
    public int waveSize;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
            Instantiate(enemy);
        }
	}
}
