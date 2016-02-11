using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponIndicator : MonoBehaviour {


    private Image imageComponent;
	// Use this for initialization
	void Start () {
        imageComponent = GetComponent<Image>();
        UpdateImage();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateImage()
    {
        GameObject gun = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>().Gun1;
        imageComponent.sprite = gun.GetComponent<SpriteRenderer>().sprite;
    }
}
