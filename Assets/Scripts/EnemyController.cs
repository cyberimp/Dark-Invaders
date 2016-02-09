using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D myBody;
	private GameObject bonus = null;
	public float hp = 10f;
    private bool dying = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		myBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Awake() {
		myBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Die (){
		if (bonus != null) {
			GameObject newBonus = Instantiate (bonus) as GameObject;
			newBonus.transform.position = gameObject.transform.position;
		}
        Destroy(GetComponent<CircleCollider2D>());
		gameObject.tag = "MostlyHarmless";
		ParticleSystem ps = gameObject.GetComponent<ParticleSystem> ();
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		ps.Emit (500);
        ps.Play();
		Destroy (gameObject,0.3f);
	}

	void ApplyDamage(float value){
		ParticleSystem ps = gameObject.GetComponent<ParticleSystem> ();
		ps.Play ();
		hp -= value;
		if (hp <= 0) {
            //	Destroy (gameObject);
            if (!dying)
            {
                dying = true;
                Die();
            }
		}
	}

	void MoveX(float value){
		myBody.velocity = new Vector2(value,0);
	}

	void Move(Vector2 speed){
//		myBody = gameObject.GetComponent<Rigidbody2D> ();
		myBody.velocity = speed;
	}

	void SetBonus(GameObject newBonus){
		bonus = newBonus;
	}


	void OnTriggerEnter2D(Collider2D other){
		string otherTag = other.gameObject.tag;
		if (otherTag == "Player") {
			player.SendMessage ("Die");
			gameObject.SendMessage ("ApplyDamage", 100);
		}
		if (otherTag == "EnemyFinish") {
			Destroy (gameObject);
		}
	}
}
