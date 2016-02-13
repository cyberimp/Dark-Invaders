using UnityEngine;
using System.Collections;

public class AfterglowController : MonoBehaviour {

    private LineRenderer line;
    public float fadeTime = 0.1f;
    private float alpha = 1;


	// Use this for initialization
	void Start () {

	    
	}
	
	// Update is called once per frame
	void Update () {
        line = GetComponent<LineRenderer>();
        line.SetColors(new Color(1,0,0,alpha), new Color(1, 0, 0, alpha));
        fadeTime -= Time.deltaTime;
        alpha -= Time.deltaTime*10f;
        if(fadeTime < 0.0f)
        {
            Destroy(gameObject);
        }    
	
	}
}
