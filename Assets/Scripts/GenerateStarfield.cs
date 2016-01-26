using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GenerateStarfield : MonoBehaviour {

	public int starSize = 1;
	public int numStars = 100;
	public float xStarSpeed = 0.5f;
	public float yStarSpeed = 0f;
	private float xOffset = 0;
	private float yOffset = 0;
	private Texture2D texture;


	// Use this for initialization
	void Start () {
		Color[] fillColor; 
		texture = new Texture2D (256, 256);
		texture.wrapMode = TextureWrapMode.Repeat;
		fillColor = texture.GetPixels ();
		for (int i = 0; i < fillColor.Length; ++i)
			fillColor[i] = new Color(0,0,0,0);
		texture.SetPixels (fillColor);
		for (int i = 0; i < numStars; ++i) {
			Vector2 point = new Vector2 (Random.Range (0, 256),Random.Range (0, 256));
//			texture.SetPixel ((int)point.x, (int)point.y, Color.white);
			if (starSize > 0) {
				Color glowColor = Color.white;
				glowColor.a = 0.5f;
				for (int size =0; size<starSize; ++size)
				for (int glowX = (int)point.x - size; glowX <= (int)point.x + size; ++glowX)
					for (int glowY = (int)point.y - size; glowY <= (int)point.y + size; ++glowY)
						texture.SetPixel (glowX, glowY, glowColor);
			}
			texture.SetPixel ((int)point.x, (int)point.y, Color.white);
		}
		texture.Apply ();
//		Debug.Log (Application.dataPath);
//		System.IO.File.WriteAllBytes (Application.dataPath + "/texture.png", texture.EncodeToPNG ());
		gameObject.GetComponent<RawImage> ().texture = texture;
	}
	
	// Update is called once per frame
	void Update () {
		xOffset += xStarSpeed * Time.deltaTime;
		yOffset += yStarSpeed * Time.deltaTime;
		Rect offRect = gameObject.GetComponent<RawImage> ().uvRect;
		offRect.x = xOffset;
		offRect.y = yOffset;
		gameObject.GetComponent<RawImage> ().uvRect = offRect;
//		gameObject.GetComponent<RawImage> ().
	}
}
