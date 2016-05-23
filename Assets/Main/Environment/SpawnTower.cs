using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SpawnTower : MonoBehaviour, IPointerDownHandler {

    public GameObject TowerType;


    // Use this for initialization
    void Start () {
	
	}


    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0)) { 

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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

    // Update is called once per frame
    void Update() {

	}
}
