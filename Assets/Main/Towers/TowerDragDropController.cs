using UnityEngine;
using System.Collections;

public class TowerDragDropController : MonoBehaviour {


    GameObject target;
    bool isMouseDrag = false;
    private Vector3 screenPosition;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
	
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                isMouseDrag = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDrag = false;
        }

        if (isMouseDrag)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.tag.Equals("Cube"))
                {
                    target.transform.position = new Vector3(Mathf.Round(hit.transform.position.x), 1, Mathf.Round(hit.transform.position.z));
                    break;
                }

                if (hit.transform.tag.Equals("ImaginaryCube"))
                {
                    target.transform.position = new Vector3(hit.point.x, 1, hit.point.z);
                    break;
                }
            }
        }
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit) && hit.transform.tag.Equals("Tower")) 
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
