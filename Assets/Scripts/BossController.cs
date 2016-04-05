using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    private float fireCD = 0f;
    int aiStage = 1;
    private Vector2 flightDir;
    public GameObject[] turrets;
    public GameObject bigGun;
    public SpriteRenderer berserkingDialog;
    private bool isCollider = false;
    private float dialogCD = 0f;
    private float stopCD = 0f;
    private Transform playerTrans;
    private Animator anim;
    private Rigidbody2D rb;
    Vector2 oldPosition;

    // Use this for initialization
    void Start () {
        PolygonCollider2D[] colliders = transform.GetComponentsInChildren<PolygonCollider2D>();
        foreach (GameObject curTurret in turrets)
        {
            curTurret.SendMessage("Lockdown", true);
        }
        flightDir = Vector2.down;
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        oldPosition = rb.position;
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
    void FixedUpdate () {

        anim.SetFloat("bossX", rb.position.x);
        anim.SetFloat("bossY", rb.position.y);
        anim.SetFloat("Xdelta", Mathf.Abs(oldPosition.x - rb.position.x)*100);
        anim.SetFloat("Ydelta", Mathf.Abs(oldPosition.y - rb.position.y)*100);
        oldPosition = rb.position;
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
