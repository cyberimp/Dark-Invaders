using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject enemyType;
	public GameObject bonus;
	public Vector2 direction= new Vector2(0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(bool isBonus) {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        WayPointsController wpc = GetComponent<WayPointsController>();
        ps.Play();
        //GetComponent<AudioSource>().Play();
		GameObject newEnemy = Instantiate (enemyType) as GameObject;
        newEnemy.transform.position = gameObject.transform.position;
		if (isBonus)
			newEnemy.SendMessage ("SetBonus", bonus);
        if (wpc != null)
        {
            WayPointsController enemyWPC = newEnemy.AddComponent<WayPointsController>();
            enemyWPC.waypoints = wpc.waypoints;
        }
        else
        newEnemy.SendMessage ("Move", this.direction);	
	}
}
