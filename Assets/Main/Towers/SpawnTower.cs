using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SpawnTower : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public GameObject TowerType;
    private GameObject _spawnedTower;
    private bool _mouseDrag = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        bool towerSpawned = false;

        if (Input.GetMouseButtonDown(0)) {

            if (!towerSpawned)
            {
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

                _spawnedTower = Instantiate(TowerType);
                towerSpawned = true;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _spawnedTower = null;
        _mouseDrag = false;
    }

    //This is called every frame
    public void Update()
    {
        if (_spawnedTower != null)
        {
            PickUpSpawnedTower();
            DragSpawnedTower();
        }
    }

    public void PickUpSpawnedTower()
    {
        if (_spawnedTower != null && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.tag.Equals("Tower") && hit.transform.gameObject == _spawnedTower)
                {
                    _mouseDrag = true;
                    break;
                }
            }
        }
    }

    public void DragSpawnedTower()
    {
        if (_mouseDrag)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.tag.Equals("Cube"))
                {
                    _spawnedTower.transform.position = new Vector3(Mathf.Round(hit.transform.position.x), 1, Mathf.Round(hit.transform.position.z));
                    break;
                }

                if (hit.transform.tag.Equals("ImaginaryCube"))
                {
                    _spawnedTower.transform.position = new Vector3(hit.point.x, 1, hit.point.z);
                    break;
                }
            }
        }
    }
}
