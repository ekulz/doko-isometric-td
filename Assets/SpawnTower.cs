using UnityEngine;
using System.Collections;

public class SpawnTower : MonoBehaviour {

    public GameObject TowerType;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool buttonPressed = false;
            if (Physics.Raycast(ray, out hit, 100.0f))
                buttonPressed = hit.transform.tag.Equals("ObsticleTowerButton");


            if (buttonPressed) {
                RaycastHit[] hits = Physics.RaycastAll(ray);

                foreach (RaycastHit h in hits)
                {
                    if (h.transform.tag.Equals("ImaginaryCube"))
                    {
                        TowerType.transform.position = new Vector3(h.point.x, 1, h.point.z);
                        break;
                    }
                    else if (h.transform.tag.Equals("Cube"))
                    {
                        TowerType.transform.position = new Vector3(Mathf.Round(h.transform.position.x), 1, Mathf.Round(h.transform.position.z)); 
                        break;
                    }
                }
                Instantiate(TowerType);
            }
        }
	}
}
