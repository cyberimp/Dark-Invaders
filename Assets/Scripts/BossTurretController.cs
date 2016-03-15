using UnityEngine;
using System.Collections;

public class BossTurretController : MonoBehaviour {

    public float maxTurretCD = 1f;
    public GameObject bullet;
    public GameObject explosion;


    private Transform playerTrans;
    private float turretCD;

	// Use this for initialization
	void Start () {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        turretCD = maxTurretCD;
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D rgBody = GetComponent<Rigidbody2D>();
        Vector3 seekingVector = transform.position - playerTrans.position ;
        rgBody.MoveRotation(Mathf.Atan2(seekingVector.y,seekingVector.x)*Mathf.Rad2Deg - 90f);
        turretCD -= Time.deltaTime;
        if (turretCD < 0f)
        {
            Fire();
            turretCD = maxTurretCD;
        }

    }

    void Fire()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.down * 200);
    }

    void Die()
    {
        GameObject expl = Instantiate(explosion,transform.position,Quaternion.identity) as GameObject;
        Destroy(expl, 5f);
        Destroy(gameObject);
    }
}
