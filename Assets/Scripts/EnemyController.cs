using UnityEngine;
using System.Collections;

public class EnemyController : Assets.Scripts.CEnemy {

	private Rigidbody2D myBody;
	private GameObject bonus = null;
    public GameObject bullet;
    private float CD = 0.5f;

	// Use this for initialization
	override public void Start () {
        base.Start();
		myBody = gameObject.GetComponent<Rigidbody2D>();
	}

	override public void OnEnable() {
        base.OnEnable();
		myBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        CD -= Time.fixedDeltaTime;
        if (CD < 0)
        {
            Vector2 angle = player.GetComponent<Rigidbody2D>().position - 
                myBody.position; 
            angle.Normalize();
            Fire(angle*5);
            CD = 0.5f;
        }
    }

	// Update is called once per frame
	void Update () {

	}

	override public void Die (){
        base.Die();
		if (bonus != null) {
			GameObject newBonus = Instantiate (bonus) as GameObject;
			newBonus.transform.position = gameObject.transform.position;
		}
        Destroy(GetComponent<CircleCollider2D>());
        GetComponent<Animator>().SetBool("isDead", true);
        GetComponent<AudioSource>().Play();
		gameObject.tag = "MostlyHarmless";
		//ParticleSystem ps = gameObject.GetComponent<ParticleSystem> ();
        //gameObject.GetComponent<SpriteRenderer> ().enabled = false;
        //		ps.Emit (500);
        //        ps.Play();
		Destroy (gameObject,0.2f);
	}

	override public void ApplyDamage(float value){
		ParticleSystem ps = gameObject.GetComponent<ParticleSystem> ();
		ps.Play ();
        base.ApplyDamage(value);
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


    
    void Fire(Vector2 direction)
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector2.up, direction)) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().velocity = direction;
    }
}
