using UnityEngine;
using System.Collections;

public class LaserGunController : MonoBehaviour {
	public float MaxCD = 0.2f;
	public int power = 0;
	public bool isFire = false;
	private float CD;

	private Vector3 start;
	private Vector3 finish;

    private RaycastHit2D[] targets;

	// Use this for initialization
	void Start () {
		CD = MaxCD;
	}


	// Update is called once per frame
	void Update () {
		start = transform.position;
		finish = start + new Vector3 (0, 15);
		if (isFire) {
			CD-=Time.deltaTime;
			if (CD <= 0) {
				GetComponent<LineRenderer> ().enabled = true;
				GetComponent<LineRenderer> ().SetPosition (0, start);
				GetComponent<LineRenderer> ().SetPosition (1, finish);
			}
            targets = Physics2D.RaycastAll(start, finish);
            foreach (RaycastHit2D item in targets)
            {
                if (item.collider.tag == "Enemy") {
                    item.collider.SendMessage("ApplyDamage",1f+power*0.2f);
                }

            }
        }
        else
			GetComponent<LineRenderer> ().enabled = false;
	}

	void LevelUp(){
		power++;
        GetComponent<LineRenderer>().SetWidth(0.1f + 0.05f * power, 0.1f + 0.05f * power);

    }
	void Fire(bool state){
		isFire = state;
	}
}
