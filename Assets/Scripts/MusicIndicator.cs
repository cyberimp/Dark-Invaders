using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SetMusic("xenobeat\n\tgoreshit");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void SetMusic(string trackinfo)
    {
        Text tx = GetComponent<Text>();
        tx.text = "♫" + trackinfo;
    }
}
