using UnityEngine;
using System.Collections;

public class PlasmaMachineGunController : MonoBehaviour {

	public float MaxCD = 0.5f;
	public int power = 0;
	private bool isFire = false;
	public GameObject bullet;
	private float CD;

	// Use this for initialization
	void Start () {
		CD = MaxCD;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isFire) {
			CD-=Time.fixedDeltaTime;
			if (CD <= 0.0f)
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
			MaxCD/=2;
			break;
				
		}
	}
	void Fire(bool state){
		isFire = state;
	}
}
