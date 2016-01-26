using UnityEngine;
using System.Collections;

public class PlasmaMachineGunController : MonoBehaviour {

	public int MaxCD = 5;
	public int power = 0;
	public bool isFire = false;
	public GameObject bullet;
	private int CD;

	// Use this for initialization
	void Start () {
		CD = MaxCD;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFire) {
			CD--;
			if (CD <= 0)
			if (power < 2) {
				GameObject newBullet;
				newBullet = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 20);
				CD = MaxCD;
				gameObject.GetComponent<AudioSource> ().Play ();
			} else {
				GameObject newBullet;
				newBullet = Instantiate (bullet, new Vector3 (transform.position.x - 0.2f, transform.position.y), Quaternion.identity) as GameObject;
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 20);
				newBullet = Instantiate (bullet, new Vector3 (transform.position.x + 0.2f, transform.position.y), Quaternion.identity) as GameObject;
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 20);
				CD = MaxCD;
				gameObject.GetComponent<AudioSource> ().Play ();
			}
		}
	}

	void LevelUp(){
		power++;
		switch (power) {
		case 1:
			MaxCD--;
			break;
				
		}
	}
	void Fire(bool state){
		isFire = state;
	}
}
