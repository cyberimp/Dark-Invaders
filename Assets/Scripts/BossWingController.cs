﻿using UnityEngine;
using System.Collections;
using System;

public class BossWingController : Assets.Scripts.CEnemy {

    [Tooltip(" 1 - left wing, 2 - right wing")]
    public int signal;

    private BossHP bar;
    // Use this for initialization
    new void Start()
    {
        bar = transform.FindChild("Canvas").GetComponentInChildren<BossHP>();
        base.Start();
    }

    // Update is called once per frame
    void Update () {
	
	}


    public override void Die()
    {
        base.Die();
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(GetComponent<PolygonCollider2D>());
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        ParticleSystem.EmissionModule module;
        module = ps.emission;
        module.enabled = true;
        GameObject.Find("Boss Head").SendMessage("Destroyed", signal);
        transform.FindChild("Gun").SendMessage("Die");
        gameObject.SendMessage("Disable");

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyFinish")
            return;
        base.OnTriggerEnter2D(other);
    }

    public override void ApplyDamage(float value)
    {
        base.ApplyDamage(value);
        if (bar != null)
            bar.SendMessage("SetHp",HP/1000);
    }

}
