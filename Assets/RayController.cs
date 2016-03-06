using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            transform.rotation = Quaternion.identity;
        else {
            GameObject nearest = enemies[0];
            float distance = (transform.position - nearest.transform.position).sqrMagnitude;
            foreach (GameObject enemy in enemies)
            {
                float newDistance = (transform.position - enemy.transform.position).sqrMagnitude;
                if (newDistance < distance) {
                    nearest = enemy;
                    distance = newDistance;
                }

            }
            transform.rotation = Quaternion.FromToRotation(Vector3.up, nearest.transform.position - transform.position);
        }
	
	}
}
