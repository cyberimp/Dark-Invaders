using UnityEngine;
using System.Collections;
using UnityEditor;


public class WayPointsController : MonoBehaviour {
    [SerializeField]
    public Vector3[] waypoints;
    private Vector2 oldPosition;
    private int targetWaypoint = 0;
    private Rigidbody2D moveBody;
 //   [SerializeField]
    private bool isMoving =false;
	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        moveBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (moveBody!=null && targetWaypoint < waypoints.Length)
            if (isMoving)//We are on way from one waypoint to another, shouldn't miss it
            {
                Vector2 oldWayPos;
                if (targetWaypoint == 0)
                    oldWayPos = Vector2.zero;
                else
                    oldWayPos = new Vector2(waypoints[targetWaypoint - 1].x,
                                                  waypoints[targetWaypoint - 1].y);
                Vector2 newPosition = new Vector2(waypoints[targetWaypoint].x,
                                                  waypoints[targetWaypoint].y) - oldWayPos;
                if ((moveBody.position - oldPosition).SqrMagnitude() > newPosition.SqrMagnitude())
                {
                    isMoving = false;
                    //moveBody.velocity = Vector2.zero;
                    targetWaypoint++;
                }
            }
            else//Let's find another waypoint!
            {
                oldPosition = moveBody.position;
                Vector2 oldWayPos;
                if (targetWaypoint == 0)
                    oldWayPos = Vector2.zero;
                else 
                    oldWayPos = new Vector2(waypoints[targetWaypoint-1].x,
                                                  waypoints[targetWaypoint-1].y);
                Vector2 newPosition = new Vector2(waypoints[targetWaypoint].x, 
                                                  waypoints[targetWaypoint].y)-oldWayPos;
                newPosition.Normalize();
                Vector2 velocity = newPosition * waypoints[targetWaypoint].z;
                moveBody.velocity = velocity;
                isMoving = true;
            }
	
	}

}
