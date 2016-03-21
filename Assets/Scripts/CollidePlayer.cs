using UnityEngine;
using System.Collections;

public class CollidePlayer : MonoBehaviour {

    private Collider2D playerCollider;
    private Collider2D thisCollider;

	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        thisCollider = gameObject.GetComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.IsTouching(playerCollider, thisCollider))
            playerCollider.SendMessage("Die", 1);
	}
}
