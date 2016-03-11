using UnityEngine;
using System.Collections;
using System;

public class RocketLauncherController : MonoBehaviour,IWeapon {
    private bool isFire;
    private float CD= 0.5f;
    private float MaxCD = 0.5f;
    public GameObject rocket;

    public void Fire(bool state)
    {
        isFire = state;
    }

    public void LevelUp()
    {
        MaxCD = Mathf.Clamp(MaxCD - 0.1f,0.1f,1f);
    }

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void FixedUpdate() {
        if (isFire){
            CD -= Time.fixedDeltaTime;
            if (CD <= 0.0f){
                    GameObject newRocket;
                    newRocket = Instantiate(rocket, transform.position, Quaternion.identity) as GameObject;
                    newRocket.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
//                    GetComponent<AudioSource>().Play();
                    CD = MaxCD;
                    //gameObject.GetComponent<AudioSource>().Play();


                }
        }
    }
}
