using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBarController : MonoBehaviour {

    public GameObject chip;
    public int starthp=10;
    private Stack bar;
    private float timer = 1;

	// Use this for initialization
	void Start () {
        bar = new Stack();
        GameObject foo;
        for (int i = 0; i < starthp; i++)
        {
            foo = Instantiate(chip);
            foo.transform.SetParent(gameObject.transform,false);
            foo.GetComponent<Image>().color = Color.HSVToRGB((float)i / (float)starthp * 0.4f, 
                                                                0.9f, 0.9f);
            bar.Push(foo);
        }
    }

    // Update is called once per frame
    void Update () {
        //timer -= Time.deltaTime;
        //if (timer < 0)
        //{
        //    ChipOut();
        //    timer = 1;
        //}
	}

    void OnGUI()
    {

    }

    void ChipOut()
    {
        if (bar.Count > 0)
        {
            GameObject bad = bar.Pop() as GameObject;
            // bad.transform.parent = null;
            bad.SendMessage("FlyOut");
        }
        else
        {
            //TODO: Gameover!
        }
    }
}
