using UnityEngine;
using System.Collections;

public class CollidePlayer : MonoBehaviour {

    public Collider2D playerCollider;
    public Collider2D thisCollider;

	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        thisCollider = gameObject.GetComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (Physics2D.CircleCast(transform.position,0.5f,Vector2.zero,0f, 1 << LayerMask.NameToLayer("Player")))
            playerCollider.SendMessage("Die", 1);
	}
}
