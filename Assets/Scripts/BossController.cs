using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    private float fireCD = 0f;
    int aiStage = 1;
    private Vector2 flightDir;
    public GameObject[] turrets;
    public GameObject bigGun;
    public SpriteRenderer berserkingDialog;
    private float dialogCD = 0f;
    private float stopCD = 0f;
    private Transform playerTrans;
    private Animator anim;

    // Use this for initialization
    void Start () {
        foreach (GameObject curTurret in turrets)
        {
            curTurret.SendMessage("Lockdown", true);
        }
        flightDir = Vector2.down;
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
	}
	
    void Unlock()
    {
            foreach (GameObject curTurret in turrets)
                curTurret.SendMessage("Lockdown", false);

    }

    void SetPhysical()
    {
        PolygonCollider2D[] colliders = transform.GetComponentsInChildren<PolygonCollider2D>();
        Collider2D PlayerCollider = 
            GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        foreach (PolygonCollider2D currCollider in colliders)
        {
            currCollider.isTrigger = false;

            Physics2D.IgnoreCollision(currCollider, PlayerCollider);
        }
    }
    // Update is called once per frame
    void Update () {
        anim.SetFloat("bossX", transform.position.x);
        anim.SetFloat("bossY", transform.position.y);
 	}
    void GoBerserk()
    {
        GetComponent<Animator>().SetBool("isBerserking", true);
    }

    void Dialog(bool state)
    {
        berserkingDialog.enabled = state;
    }

    void FireBigGun()
    {
        bigGun.SendMessage("Fire");
    }
}
