using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHP : MonoBehaviour {
    private Image bar;
	// Use this for initialization
	void Start () {
        bar = GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetHp(float amount)
    {
        if (amount <= 0)
            Destroy(transform.parent.gameObject);
        bar.fillAmount = amount;
    }
}
