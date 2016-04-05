﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class nameComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return (new CaseInsensitiveComparer()).Compare(
            ((GameObject)x).name, ((GameObject)y).name);
    }
}

public class LevelController : MonoBehaviour {
    public AudioSource music;
    public GameObject boss;
    public Canvas gameoverScreen;
    public Canvas pauseMenu;
    public Canvas victoryScreen;
    public AnimationCurve bonus;

    private IEnumerator[] levels;
    private int levelNo; 

	private GameObject[] spawnPoints;
    private List<GameObject> enemies;
    public List<GameObject> enemyList { get { return enemies; } }
    private GameObject player;
    private Coroutine currLevel;
    private GameObject[] musicArray;

	// Use this for initialization
	void Start () {
        nameComparer compare = new nameComparer();
        player = GameObject.FindGameObjectWithTag("Player");
		spawnPoints = GameObject.FindGameObjectsWithTag ("Respawn");
        Array.Sort(spawnPoints,compare);
        levels = new IEnumerator[2];
        levelNo = 0;
        levels[0] = LevelScript();
		currLevel = StartCoroutine (levels[levelNo]);
        enemies = new List<GameObject>();
	}

    public void DelEnemy(GameObject oldEnemy)
    {
        enemies.Remove(oldEnemy);
    }

    public void AddEnemy(GameObject newEnemy)
    {
        enemies.Add(newEnemy);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameoverScreen.enabled)
        {
            if (Input.GetButtonDown("Fire"))
                LevelRestart();
        }
	}

	IEnumerator LevelScript() {
        musicArray = new GameObject[2];
        musicArray[0] = Resources.Load("Level01") as GameObject;
        musicArray[1] = Resources.Load("Boss01") as GameObject;
        music.SendMessage("SetMusic",musicArray[0]);
        yield return new WaitForSeconds(16.774f);//music intro
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                spawnPoints[i%2].SendMessage("Spawn", false);
                yield return new WaitForSeconds(0.6f);

            }
            yield return new WaitForSeconds(4.951f-1.8f);
        }
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                spawnPoints[i%2].SendMessage("Spawn", false);
                yield return new WaitForSeconds(0.6f);

            }
            yield return new WaitForSeconds(4.551f - 1.8f);
        }
        yield return new WaitForSeconds(60f);

        music.SendMessage("SetMusic", musicArray[1]);
        GameObject newBoss = Instantiate(boss,new Vector3 (0,8,0),Quaternion.identity) as GameObject;
       // newBoss.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 200f);
    }

    void LevelRestart()
    {
        StopCoroutine(currLevel);
        enemies.Clear();
        Time.timeScale = 1f;
        gameoverScreen.enabled = false;
        GameObject[] all = FindObjectsOfType<GameObject>();
        foreach (GameObject go in all)
        {
            if (go.name.Contains("(Clone)"))
                Destroy(go);
        }
        player.SendMessage("Restart");
        currLevel = StartCoroutine(levels[levelNo]);
        pauseMenu.SendMessage("Lockdown", false);
    }

    void GameOver()
    {

        gameoverScreen.enabled = true;
        Time.timeScale = 0;
        music.Stop();
        pauseMenu.SendMessage("Lockdown", true);
    }

    void Victory()
    {

    }
}
