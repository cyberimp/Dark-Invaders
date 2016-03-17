using UnityEngine;
using System.Collections;

public class NullGunController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        throw new MissingReferenceException();
	}
}
