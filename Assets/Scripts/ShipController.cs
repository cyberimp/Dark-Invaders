using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public float maxSpeed = 10f;
//	public GameObject bullet;

	public GameObject Gun1;

	private GameObject Gun;

//	public float xShip; 
//	public int maxCoolDown = 2;
//	private int CD=1;
	private Rigidbody2D myBody;
	private Vector2 startPosition;

	private float GodmodeCD = 5.0f;
	private float alpha = 0.0f;
	private float alphaSpeed = 1f;


	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		startPosition = myBody.position;
        if (PlayerDemoController.weaponPrefab!=null)
            Gun1 = PlayerDemoController.weaponPrefab;
        Gun1.GetComponent<AudioSource>().enabled = true;
		Gun = (GameObject) Instantiate (Gun1,Vector3.zero, Quaternion.identity);
		Gun.transform.SetParent (transform);
		Gun.transform.localPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		xShip = myBody.position.x - startPosition.x;
//		gameObject.GetComponent<AudioSource> ().panStereo = (myBody.position.x-startPosition.x)/7;
		myBody.velocity = new Vector2 (Input.GetAxis("Horizontal")*maxSpeed,Input.GetAxis("Vertical")*maxSpeed);
        if (GodmodeCD > 0)
        {
            GodmodeCD -= Time.deltaTime;
            alpha += alphaSpeed * Time.deltaTime;
            if (alpha > 1 || alpha < 0)
                alphaSpeed = -alphaSpeed;
            alpha = Mathf.Clamp(alpha, 0, 1);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            if (GodmodeCD <= 0)
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", true);
            Gun.SendMessage("Fire", true);
        }

        if (Input.GetButtonUp("Jump"))
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            Gun.SendMessage("Fire", false);
        }
        //CD--;
    }
    void GetBonus(int num){
		Gun.SendMessage ("LevelUp");
	}

	void Die(){
		if (GodmodeCD > 0)
			return; //Ignore death signals when in god mode
		myBody.position = startPosition;
		GodmodeCD = 5.0f;
	}
}
