using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEditor;

public class EnemyController : MonoBehaviour {
    public int direction = 1;
    Vector3 endPoint;
    Vector3 startPoint;
    bool initializedState;
    Vector3 xVelocity = Vector3.zero;
    private NavMeshAgent navMeshAgent;

    // Use this for initialization
    void Start () {
        LoadGridInformation();
        initializedState = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (initializedState)
        {
            MoveToFirstGridSpace();
        }

        if (!initializedState)
        {
            MoveNext();
        }
	}

    void LoadGridInformation()
    {

        if (direction == 1) //Left to right
        {
            endPoint = new Vector3(19, 1, 10);
            startPoint = new Vector3(0, 1, 10);
        }
        else //Right to left
        {
            endPoint = new Vector3(0, 1, 10);
            startPoint = new Vector3(19, 1, 10);
        }


        navMeshAgent = this.transform.GetComponent("NavMeshAgent") as NavMeshAgent;

    }

    void MoveNext()
    {
        navMeshAgent.SetDestination(endPoint);
    }

    void MoveToFirstGridSpace()
    {

        transform.position = Vector3.SmoothDamp(transform.position, startPoint, ref xVelocity, 0.1f);
        if (Mathf.Abs((startPoint.x - transform.position.x)) < 0.01 && Mathf.Abs((startPoint.z - transform.position.z)) < 0.01)
        {
            initializedState = false;
            transform.position = startPoint; //Correct position
        }
        
    }
}
