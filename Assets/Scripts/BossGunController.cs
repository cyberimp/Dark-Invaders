using UnityEngine;
using System.Collections;

public class BossGunController : Assets.Scripts.CEnemy{


    public ParticleSystem DeathRay;
    public ParticleSystem DeathRayEnergy;
    public ParticleSystem DeathRayGlow;
    public BoxCollider2D rayCollider;
    private float FireCD = 0f;
    private float ShutdownCD = 0f;
    private bool isDead = false;

	// Use this for initialization
	new void Start () {
        base.Start();
//        DeathRay.sortingLayerName = "Bullets";
//        DeathRay.enabled = false;
	}

    void Update()
    {
        if (FireCD > 0f)
            FireCD -= Time.deltaTime;
        if (ShutdownCD > 0f)
            ShutdownCD -= Time.deltaTime;
        if (FireCD < 0f)
        {
            FireCD = 0f;
            ParticleSystem.EmissionModule module;
            module = DeathRayEnergy.emission;
            module.enabled = false;
            DeathRayGlow.Play();
           // module = DeathRayGlow.emission;
            //module.enabled = true;
            DeathRay.Play();
            rayCollider.enabled = true;
            ShutdownCD = 2f;
        }
        if (ShutdownCD < 0f)
        {
            DeathRayGlow.Stop();
            DeathRay.Stop();
            DeathRay.SetParticles(null,0);
            ShutdownCD = 0f;
            rayCollider.enabled = false;
        }

    }

    public override void Die()
    {
        base.Die();
        StopFire();
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(GetComponent<PolygonCollider2D>());
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        ParticleSystem.EmissionModule module;
        module = ps.emission;
        module.enabled = true;
        GameObject.Find("Boss Head").SendMessage("Destroyed", 3);
        isDead = true;
        gameObject.SendMessage("Disable");
    }

    public void Fire()
    {
        if (FireCD == 0f && ShutdownCD == 0f && !isDead)
        {
            GetComponent<AudioSource>().Play();
            ParticleSystem.EmissionModule module;
            module = DeathRayEnergy.emission;
            module.enabled = true;
            FireCD = 2f;
        }
    }
    public void StopFire()
    {
        GetComponent<AudioSource>().Stop();
        FireCD = 0f;
        ShutdownCD = 0f;
        DeathRayGlow.Stop();
        DeathRay.Stop();
        DeathRay.SetParticles(null, 0);
        ParticleSystem.EmissionModule module;
        module = DeathRayEnergy.emission;
        module.enabled = false;
        rayCollider.enabled = false;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyFinish")
            return;
        base.OnTriggerEnter2D(other);
    }

}
