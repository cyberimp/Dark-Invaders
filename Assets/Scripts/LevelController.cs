using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
    public AudioSource music;
	private GameObject[] spawnPoints;

	// Use this for initialization
	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag ("Respawn");
		StartCoroutine (LevelScript());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LevelScript() {
        music.SendMessage("SetMusic","bgm01");
		for (int i = 0; i < 5; ++i) {
			spawnPoints [0].SendMessage ("Spawn",true);
			spawnPoints [1].SendMessage ("Spawn",false);
			yield return new WaitForSeconds (0.6f);
		}
	}
}
