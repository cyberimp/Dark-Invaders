using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicController : MonoBehaviour {

    public Text infoLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetMusic(string fileName)
    {
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(fileName);
        infoLabel.SendMessage("SetMusic", "o'er the flood\r\tgoreshit");
        GetComponent<AudioSource>().Play();
    }
}
