using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {

    Vector3 xVelocity = Vector3.zero;
    public float dragSpeed = 1;
    private Vector3 _dragOrigin;

    // Use this for initialization
    void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {
        if (Application.isMobilePlatform)
            processTouchMovement();
        else
            processMouseDragMovement();
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

    void processMouseDragMovement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(1))
            return;

        RaycastHit hitOrig = new RaycastHit();
        RaycastHit hitDest = new RaycastHit();
        Transform orig = null;
        Transform dest = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(_dragOrigin), out hitOrig, 100.0f))
            orig = hitOrig.transform;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitDest, 100.0f))
            dest = hitDest.transform;


        if (orig != null && dest != null)
        {
            Vector3 validateTrans = -(dest.position - orig.position) * 0.15f;
            validateTrans = transform.position + validateTrans;
            if (CanMoveX(validateTrans) && CanMoveZ(validateTrans))
                transform.Translate(-(dest.position - orig.position) * 0.15f, Space.World);
            else if (CanMoveX(validateTrans))
            {
                validateTrans = -(dest.position - orig.position) * 0.15f;
                validateTrans.z = 0;
                transform.Translate(validateTrans, Space.World);
            }
            else if (CanMoveZ(validateTrans))
            {
                validateTrans = -(dest.position - orig.position) * 0.15f;
                validateTrans.x = 0;
                transform.Translate(validateTrans, Space.World);
            }
        }
    }


    private bool CanMoveX(Vector3 newPoint)
    {
        return !(newPoint.x > ConfigurationSettings.GridSize.x 
                || newPoint.x < 0);
    }

    private bool CanMoveZ(Vector3 newPoint)
    {
        return !( newPoint.z > ConfigurationSettings.GridSize.z
                || newPoint.z < 0);
    }

}
