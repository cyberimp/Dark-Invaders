using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour {

    public GameObject Music;
    private Canvas canvas;
	private bool visible;
    private bool isLocked = false;
    public GameObject firstItem;

    // Use this for initialization
    void Start () {
		visible = false;
		canvas = gameObject.GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Cancel")&&!isLocked){
			visible = !visible;
            if (visible)
            {
                Time.timeScale = 0;
                Music.GetComponent<AudioSource>().Pause();
                EventSystem.current.SetSelectedGameObject(firstItem);
            }
            else
            {
                Time.timeScale = 1;
                Music.GetComponent<AudioSource>().UnPause();
                EventSystem.current.SetSelectedGameObject(null);
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

    void Lockdown(bool state)
    {
        isLocked = state;
    }
}
