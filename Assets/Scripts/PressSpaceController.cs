using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressSpaceController : MonoBehaviour {
	private Text text;
	private float alpha;
	private float alphaSpeed = 1f;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		alpha += alphaSpeed*Time.deltaTime;
		if (alpha > 1 || alpha < 0)
			alphaSpeed = -alphaSpeed;
		alpha = Mathf.Clamp (alpha, 0, 1);
		Color temp = text.color;
		text.color = new Color (temp.r, temp.g, temp.b, alpha);
		if (Input.GetButtonUp ("Start"))
			SceneManager.LoadScene ("Shop");

	}
}
