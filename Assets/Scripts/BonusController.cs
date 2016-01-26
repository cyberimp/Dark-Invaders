using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {
	GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Finish")
			Destroy (gameObject);
		if (other.tag == "Player") {
			player.SendMessage ("GetBonus", 1);
			Destroy (gameObject);
		}
	}
}
