using UnityEngine;
using System.Collections;

public class LaserGunController : MonoBehaviour {
	public int MaxCD = 5;
	public int power = 0;
	public bool isFire = false;
	private int CD;

	public Vector3 start;
	public Vector3 finish;

	// Use this for initialization
	void Start () {
		CD = MaxCD;
	}

	// Update is called once per frame
	void Update () {
		start = transform.position;
		finish = start + new Vector3 (0, 15);
		if (isFire) {
			CD--;
			if (CD <= 0) {
				GetComponent<LineRenderer> ().enabled = true;
				GetComponent<LineRenderer> ().SetPosition (0, start);
				GetComponent<LineRenderer> ().SetPosition (1, finish);

			}
		}
		else
			GetComponent<LineRenderer> ().enabled = false;
	}

	void LevelUp(){
		power++;
		switch (power) {
		case 1:
			MaxCD--;
			break;

		}
	}
	void Fire(bool state){
		isFire = state;
	}
}
