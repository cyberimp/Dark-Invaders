﻿using UnityEngine;
using System.Collections;

interface IWeapon
{
    void Fire(bool state);
    void LevelUp();
}

public class LaserGunController : MonoBehaviour,IWeapon {
	public float MaxCD = 0.5f;
	public int power = 0;
	private bool isFire = false;
    public GameObject afterglow;
	private float CD;

	private Vector3 start;
	private Vector3 finish;
    private Vector3 oldStart;

    private RaycastHit2D[] targets;

    void Awake()
    {
        GetComponent<LineRenderer>().sortingLayerName = "Bullets";
    }

    // Use this for initialization
    void Start () {
        start = new Vector3();
		CD = MaxCD;
        GetComponent<LineRenderer>().sortingLayerName = "Bullets";
	}


	// Update is called once per frame
	void Update () {
        oldStart = start;
		start = transform.position;
        finish = start + new Vector3(0, 15);
        if (isFire)
        {
            CD -= Time.deltaTime;
            if (CD <= 0)
            {
                GetComponent<LineRenderer>().enabled = true;
                GetComponent<LineRenderer>().sortingLayerName = "Bullets";
                //GetComponent<LineRenderer>().SetPosition(0, start);
                //GetComponent<LineRenderer>().SetPosition(1, finish);
                GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
                GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 15));
                if (!start.Equals(oldStart))
                {
                    GameObject newGlow = Instantiate(afterglow);
                    newGlow.GetComponent<LineRenderer>().SetPosition(0, start);
                    newGlow.GetComponent<LineRenderer>().SetPosition(1, finish);
                }
                targets = Physics2D.RaycastAll(start, Vector2.up,100,LayerMask.GetMask("Enemy"));
                if (targets!=null)
                    foreach (RaycastHit2D item in targets)
                    {
                        if (item.collider.tag == "Enemy")
                        {
                            item.collider.SendMessage("ApplyDamage", 1f + power * 0.2f);
                        }

                    }
            }
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            CD = MaxCD;
        }
	}

	public void LevelUp(){
		power++;
        GetComponent<LineRenderer>().SetWidth(0.1f + 0.05f * power, 0.1f + 0.05f * power);

    }
	public void Fire(bool state){
		isFire = state;
        if (isFire)
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Stop();

    }
}
