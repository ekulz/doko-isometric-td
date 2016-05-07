using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    ConfigurationSettings settings;
    static bool inMotion = false; //Don't like this. Remove static later
    RaycastHit hit;
    Ray ray;
    float smoothTime = 0.3F;
    Vector3 xVelocity = Vector3.zero;


    // Use this for initialization
    void Start () {
         settings = new ConfigurationSettings();
	}

    // Update is called once per frame
    void Update()
    {

        if (Application.isMobilePlatform)
            processTouchMovement();
        else
            processMouseMovement();
    }
      

    void processTouchMovement()
    {
        Touch[] touches = Input.touches;

        if (touches.Length > 0)
        {
            if (touches.Length == 1)
            {
                if (touches[0].phase == TouchPhase.Moved)
                {
                    //TODO: Implement touch
                }
            }
        }
    }

    void processMouseMovement()
    {
        if (!inMotion)
        {
            if (Input.GetMouseButtonUp(0))
            {
                hit = new RaycastHit();
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                    if (hit.transform.tag.Contains("Cube"))
                        inMotion = true;
            }
        }

        if (inMotion)
        {
            transform.position = Vector3.SmoothDamp(transform.position, hit.transform.position, ref xVelocity, 0.1f);
            if(Mathf.Abs((hit.transform.position.x - transform.position.x)) < 0.01 && Mathf.Abs((hit.transform.position.z - transform.position.z)) < 0.01)
            {
                inMotion = false;
                transform.position = hit.transform.position; //Correct focus position to exact cube position
            }
        }
    }

}
