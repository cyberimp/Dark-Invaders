using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBarController : MonoBehaviour {

    public Sprite left;
    public Sprite right;
    public Sprite center;
    public Rect position;
    private Image rectImage;

	// Use this for initialization
	void Start () {
        rectImage = GetComponent<Image>();
        //position.x += transform.position.x;
        //position.y += transform.position.y;


    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnGUI()
    {
        position = rectImage.GetPixelAdjustedRect();
        position.x += transform.position.x;
        position.y += transform.position.y;
        GUI.Box(position, center.texture);

    }
}
