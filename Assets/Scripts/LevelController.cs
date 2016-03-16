using UnityEngine;
using System.Collections;
using System;

public class nameComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return (new CaseInsensitiveComparer()).Compare(((GameObject)x).name, ((GameObject)y).name);
    }
}

public class LevelController : MonoBehaviour {
    public AudioSource music;
    public GameObject boss;
	private GameObject[] spawnPoints;
    private GameObject[] enemies;
    private GameObject player;

	// Use this for initialization
	void Start () {
        nameComparer compare = new nameComparer();
        player = GameObject.FindGameObjectWithTag("Player");
		spawnPoints = GameObject.FindGameObjectsWithTag ("Respawn");
        Array.Sort(spawnPoints,compare);
		StartCoroutine (LevelScript());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LevelScript() {
        music.SendMessage("SetMusic","bgm01");
        yield return new WaitForSeconds(2f);
        for (int j = 0; j < 2; ++j)
        {
            for (int i = 0; i < 5; ++i)
            {
                spawnPoints[0].SendMessage("Spawn", true);
                spawnPoints[1].SendMessage("Spawn", false);
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.SendMessage("Fire", (Vector2)(player.transform.position - enemy.transform.position),
                        SendMessageOptions.DontRequireReceiver);
                }
                yield return new WaitForSeconds(0.6f);
            }
            yield return new WaitForSeconds(4f);
        }
        GameObject newBoss = Instantiate(boss,new Vector3 (0,8,0),Quaternion.identity) as GameObject;
       // newBoss.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 200f);
    }
}
