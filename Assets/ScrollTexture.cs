using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollTexture : MonoBehaviour {
    public float xSpeed;
    public float ySpeed = 0.1f;
    private float xOffset;
    private float yOffset;

    // Use this for initialization
    void Start () {
        GetComponent<RawImage>().texture.wrapMode = TextureWrapMode.Repeat;
	
	}
	
	// Update is called once per frame
	void Update () {
        xOffset += xSpeed * Time.deltaTime;
        yOffset += ySpeed * Time.deltaTime;
        Rect offRect = gameObject.GetComponent<RawImage>().uvRect;
        offRect.x = xOffset;
        offRect.y = yOffset;
        gameObject.GetComponent<RawImage>().uvRect = offRect;


    }
}
