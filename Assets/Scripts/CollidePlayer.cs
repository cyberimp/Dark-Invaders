using UnityEngine;
using System.Collections;

public class CollidePlayer : MonoBehaviour {

    public Collider2D playerCollider;
    public Collider2D thisCollider;
    private bool isEnabled = true;

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
        if (isEnabled)
        if ((playerCollider.transform.position - thisCollider.transform.position).sqrMagnitude < 0.25f)
            playerCollider.SendMessage("Die", 1);
	}

    void Disable()
    {
        isEnabled = false;
    }
}
