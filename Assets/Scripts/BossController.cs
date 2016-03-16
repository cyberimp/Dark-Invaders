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

    // Use this for initialization
    void Start () {
        foreach (GameObject curTurret in turrets)
        {
            curTurret.SendMessage("Lockdown", true);
        }
        flightDir = Vector2.down;
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 oldFlightDir = flightDir;
        if (transform.position.y < 2.5f && aiStage == 1)
        //boss found his place and now begins slow movement from left to right
        {
            //new flight direction
            flightDir = Vector2.left;
            //turn on the turrets
            foreach (GameObject curTurret in turrets)
                curTurret.SendMessage("Lockdown", false);
            //now time for stage 2
            aiStage = 2;
        }

        if(transform.position.x < -5.5f && aiStage == 2)
        {
            flightDir = Vector2.zero;
            bigGun.SendMessage("Fire");
            aiStage = 3;
            fireCD = 4f;
        }

        if (fireCD > 0 && aiStage == 3)
        {
            fireCD -= Time.deltaTime;
            if (fireCD <= 0)
            {
                flightDir = Vector2.right;
                fireCD = 0;
                aiStage = 4;
            }
        }

        if (transform.position.x > 5.5f && aiStage == 4)
        {
            flightDir = Vector2.zero;
            bigGun.SendMessage("Fire");
            aiStage = 5;
            fireCD = 4f;
        }

        if (fireCD > 0 && aiStage == 5)
        {
            fireCD -= Time.deltaTime;
            if (fireCD <= 0)
            {
                flightDir = Vector2.left;
                fireCD = 0;
                aiStage = 2;
            }
        }

        if (aiStage == 6)
        {
            aiStage = 7;
            if (transform.position.x > 5.3f)
                flightDir = Vector2.left;
            else
                flightDir = Vector2.zero;
        }

        if (transform.position.x < 5.3f && aiStage == 7)
        {
            berserkingDialog.enabled = true;
            flightDir = Vector2.zero;
            dialogCD = 2f;
            aiStage = 8;
        }

        if (dialogCD > 0f && aiStage == 8)
        {
            dialogCD -= Time.deltaTime;
            if (dialogCD < 0f)
            {
                berserkingDialog.enabled = false;
                stopCD = 1f;
                aiStage = 9;
            }
        }

        if (stopCD > 0f && aiStage == 9)
        {
            stopCD -= Time.deltaTime;
            if (stopCD < 0f)
            {
                stopCD = 0f;
                aiStage = 10;
            }
        }

        if (aiStage == 10)
        {
            Vector3 transVector = playerTrans.position - transform.position;
            Vector2 seekingVector = new Vector2(transVector.x, transVector.y);
            seekingVector.Normalize();
            flightDir = seekingVector * 20;
            aiStage = 11;
        }

        if (aiStage == 11 && (transform.position.x < -7f || transform.position.x > 7f ||
            transform.position.y < -3.8f || transform.position.y > 3.8f))
        {
            if (transform.position.x < -7f)
                transform.position = new Vector3(-7f, transform.position.y, 0);
            if (transform.position.x > 7f)
                transform.position = new Vector3(7f, transform.position.y, 0);
            if (transform.position.y < -3.8f)
                transform.position = new Vector3(transform.position.x, -3.8f, 0);
            if (transform.position.y > 3.8f)
                transform.position = new Vector3(transform.position.x, 3.8f, 0);
            flightDir = Vector2.zero;
            aiStage = 9;
            stopCD = 1f;
        }

        //correct flight direction
        if (oldFlightDir!=flightDir)
            GetComponent<Rigidbody2D>().velocity = flightDir;
	}
    void GoBerserk()
    {
        aiStage = 6;
    }
}
