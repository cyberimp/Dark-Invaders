using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject Music;
    private Canvas canvas;
	private bool visible;
	// Use this for initialization
	void Start () {
		visible = false;
		canvas = gameObject.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Cancel")){
			visible = !visible;
            if (visible)
            {
                Time.timeScale = 0;
                Music.GetComponent<AudioSource>().Pause();
            }
            else
            {
                Time.timeScale = 1;
                Music.GetComponent<AudioSource>().UnPause();
            }
            canvas.enabled = visible;
		}
	
	}

	public void Quit(){
		Application.Quit ();
	}

	public void MainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene("Zastavka");
	}
}
