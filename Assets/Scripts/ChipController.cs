using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChipController : MonoBehaviour {
//    private bool isFading = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        	
	}
    void FlyOut()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        rb.AddForce(new Vector2(50, 150));
        rb.AddTorque(-90);
//        isFading = true;
        Destroy(gameObject, 1);
        LeanTween.alpha(GetComponent<RectTransform>(), 0, 1);
    }
}
