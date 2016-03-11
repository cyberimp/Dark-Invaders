using UnityEngine;
using System.Collections;

public class BossGunController : Assets.Scripts.CEnemy{

	// Use this for initialization
	new void Start () {
        base.Start();
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
        GameObject.Find("Boss Head").SendMessage("Destroyed", 3);

    }


    // Update is called once per frame
    void Update () {
	
	}
}
