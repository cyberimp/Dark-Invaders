using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Finish")
			Destroy (gameObject);
		if (other.tag == "Enemy") {
			other.SendMessage ("ApplyDamage", 1);
			Destroy (gameObject);
		}
        if (other.tag == "Player")
        {
            other.SendMessage("Die");
            Destroy(gameObject);
        }
    }
}
