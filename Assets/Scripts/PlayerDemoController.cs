﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDemoController : MonoBehaviour {

    public static GameObject weaponPrefab;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(GetComponent<PlayerDemoController>());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetWeapon (GameObject prefab)
    {
        if (weaponPrefab != null)
        {
            weaponPrefab.SendMessage("Fire", false);
            Destroy(weaponPrefab);
        }
        weaponPrefab = Instantiate(prefab);
        weaponPrefab.GetComponent<AudioSource>().enabled = false;
        weaponPrefab.transform.parent = transform;
        weaponPrefab.name = "Test Gun";
        weaponPrefab.transform.localPosition = new Vector3();
        weaponPrefab.SendMessage("Fire", true);
    }

    public void NextScene() {
        weaponPrefab.SendMessage("Fire", false);
        transform.position = new Vector3(100,100);
        SceneManager.LoadScene("Main");
    }
}
