using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public float maxSpeed = 10f;
//	public GameObject bullet;

	public GameObject GunSlot1;
    public GameObject UtilitySlot1;
    public GameObject HPBar;

	private GameObject[] inventory;
    //	public float xShip; 
    //	public int maxCoolDown = 2;
    //	private int CD=1;
    private Rigidbody2D myBody;
	private Vector2 startPosition;

	private float GodmodeCD = 5.0f;
	private float alpha = 0.0f;
	private float alphaSpeed = 1f;
    public int HP = 10;


    // Use this for initialization
    void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		startPosition = myBody.position;
        Restart();
    }
    
    void Restart()
    {
        inventory = new GameObject[2];
        myBody.MovePosition(startPosition);
        myBody.velocity = Vector2.zero;
        GameObject[] stateInventory = StateController.Inventory();
        if (stateInventory != null)
        {
            if(stateInventory[0] != null)
                GunSlot1 = stateInventory[0];
            if (stateInventory[1] != null)
                UtilitySlot1 = stateInventory[1];
        }

        if (GunSlot1 != null)
        {
            GunSlot1.GetComponent<AudioSource>().enabled = true;
            inventory[0] = Instantiate(GunSlot1);
            inventory[0].transform.SetParent(transform);
            inventory[0].transform.localPosition = Vector3.zero;
        }
        if (UtilitySlot1 != null)
        {
            UtilitySlot1.GetComponent<AudioSource>().enabled = true;
            inventory[1] = (GameObject)Instantiate(UtilitySlot1, Vector3.zero, Quaternion.identity);
            inventory[1].transform.SetParent(transform);
            inventory[1].transform.localPosition = Vector3.zero;
        }
        HPBar.SendMessage("SetHealth", HP);
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
        if (Input.GetButtonDown("Fire"))
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", true);
            inventory[0].SendMessage("Fire", true);
        }

        if (Input.GetButtonUp("Fire"))
        {
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            inventory[0].SendMessage("Fire", false);
        }
        //CD--;
    }
    void GetBonus(int num){
		inventory[0].SendMessage ("LevelUp");
	}

	void Die(int times){
		if (GodmodeCD > 0)
			return; //Ignore death signals when in god mode
                    //		myBody.position = startPosition;
        for (int i = 0; i < times; ++i)
            HPBar.SendMessage("ChipOut");
		GodmodeCD = 0.5f;
	}

}
