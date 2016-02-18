using UnityEngine;
using System.Collections;

public class LaserGunController : MonoBehaviour {
	public float MaxCD = 0.5f;
	public int power = 0;
	private bool isFire = false;
    public GameObject afterglow;
	private float CD;

	private Vector3 start;
	private Vector3 finish;
    private Vector3 oldStart;

    private RaycastHit2D[] targets;

	// Use this for initialization
	void Start () {
        start = new Vector3();
		CD = MaxCD;
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
                GetComponent<AudioSource>().Play();
                GetComponent<LineRenderer>().enabled = true;
                GetComponent<LineRenderer>().SetPosition(0, start);
                GetComponent<LineRenderer>().SetPosition(1, finish);
                if (!start.Equals(oldStart))
                {
                    GameObject newGlow = Instantiate(afterglow);
                    newGlow.GetComponent<LineRenderer>().SetPosition(0, start);
                    newGlow.GetComponent<LineRenderer>().SetPosition(1, finish);
                }
                targets = Physics2D.RaycastAll(start, finish);
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
            GetComponent<AudioSource>().Stop();
            GetComponent<LineRenderer>().enabled = false;
            CD = MaxCD;
        }
	}

	void LevelUp(){
		power++;
        GetComponent<LineRenderer>().SetWidth(0.1f + 0.05f * power, 0.1f + 0.05f * power);

    }
	void Fire(bool state){
		isFire = state;
	}
}
