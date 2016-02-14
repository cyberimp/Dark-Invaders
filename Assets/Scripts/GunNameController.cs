using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunNameController : MonoBehaviour {

    void SetText(string newText)
    {
        GetComponent<Text>().text = newText;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
