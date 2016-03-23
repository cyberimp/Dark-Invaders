using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class MusicController : MonoBehaviour {

    public Text infoLabel;
    public Slider BGMSlider;
    public Slider SNDSlider;
    public AudioMixer mixer;

	// Use this for initialization
	void Start () {
        BGMSlider.value = PlayerPrefs.GetFloat("BGM", 0);
        SNDSlider.value = PlayerPrefs.GetFloat("SND", 0);
        mixer.SetFloat("BGM", BGMSlider.value);
        mixer.SetFloat("SND", SNDSlider.value);

    }

    // Update is called once per frame
    void Update () {
	
	}

    void SetMusic(GameObject music)
    {
        MusicInfo info = music.GetComponent<MusicInfo>();
        GetComponent<AudioSource>().clip = info.sound;
        infoLabel.SendMessage("SetMusic", info.songName + "\r\n\t" + info.songAuthor);
        GetComponent<AudioSource>().Play();
    }

    public void sliderChange()
    {
        mixer.SetFloat("BGM",BGMSlider.value);
        mixer.SetFloat("SND", SNDSlider.value);
        PlayerPrefs.SetFloat("BGM", BGMSlider.value);
        PlayerPrefs.SetFloat("SND", SNDSlider.value);
        PlayerPrefs.Save();
    }
}
