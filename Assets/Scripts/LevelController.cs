using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
    public AudioSource music;
	private GameObject[] spawnPoints;
    private GameObject[] enemies;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		spawnPoints = GameObject.FindGameObjectsWithTag ("Respawn");
		StartCoroutine (LevelScript());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LevelScript() {
        music.SendMessage("SetMusic","bgm01");
        yield return new WaitForSeconds(2f);
        for (int j = 0; j < 10; ++j)
        {
            for (int i = 0; i < 5; ++i)
            {
                spawnPoints[0].SendMessage("Spawn", true);
                spawnPoints[1].SendMessage("Spawn", false);
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.SendMessage("Fire", (Vector2)(player.transform.position - enemy.transform.position));
                }
                yield return new WaitForSeconds(0.6f);
            }
            yield return new WaitForSeconds(4f);
        }
    }
}
