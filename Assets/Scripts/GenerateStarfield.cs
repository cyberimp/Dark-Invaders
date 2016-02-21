using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//moving starfield generator
public class GenerateStarfield : MonoBehaviour {

	public int starSize = 1;
	public int numStars = 100;
	public float xStarSpeed = 0.5f;
	public float yStarSpeed = 0f;
	private float xOffset = 0;
	private float yOffset = 0;
	private Texture2D texture;


	//Initialization of texture
	void Start () {

        //temporary array for filling texture
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
            texture.SetPixel((int)point.x, (int)point.y, Color.white);
            if (starSize > 1) {
				Color glowColor = Color.white;
				glowColor.a = 0.5f;
                switch (starSize)
                {
                    case 2:
                        texture.SetPixel((int)point.x - 1, (int)point.y, glowColor);
                        texture.SetPixel((int)point.x + 1, (int)point.y, glowColor);
                        texture.SetPixel((int)point.x, (int)point.y - 1, glowColor);
                        texture.SetPixel((int)point.x, (int)point.y + 1, glowColor);
                        break;
                    case 3:
                        texture.SetPixel((int)point.x - 1, (int)point.y, Color.white);
                        texture.SetPixel((int)point.x + 1, (int)point.y, Color.white);
                        texture.SetPixel((int)point.x, (int)point.y - 1, Color.white);
                        texture.SetPixel((int)point.x, (int)point.y + 1, Color.white);
                        texture.SetPixel((int)point.x - 2, (int)point.y, glowColor);
                        texture.SetPixel((int)point.x + 2, (int)point.y, glowColor);
                        texture.SetPixel((int)point.x, (int)point.y - 2, glowColor);
                        texture.SetPixel((int)point.x, (int)point.y + 2, glowColor);
                        texture.SetPixel((int)point.x - 1, (int)point.y - 1, glowColor);
                        texture.SetPixel((int)point.x + 1, (int)point.y + 1, glowColor);
                        texture.SetPixel((int)point.x + 1, (int)point.y - 1, glowColor);
                        texture.SetPixel((int)point.x - 1, (int)point.y + 1, glowColor);
                        break;
                    default:
                        break;
                }
            }
		}
		texture.Apply ();
//		Debug.Log (Application.dataPath);
//		System.IO.File.WriteAllBytes (Application.dataPath + "/texture.png", texture.EncodeToPNG ());
		gameObject.GetComponent<RawImage> ().texture = texture;
//        GetComponent<Canvas>().sortingLayerName = "Background";
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
