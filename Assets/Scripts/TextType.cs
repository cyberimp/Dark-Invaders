using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextType : MonoBehaviour {

    private Text thisText;
    private float cursorCD = 0;
    [SerializeField]
    private float maxCursorCD = 0.5f;
    private float typeCD = 0;
    [SerializeField]
    private float maxTypeCD = 0.1f;
    private float tempTypeCD;
    private bool isCursor = true;
    private string typeBuffer = "Lorem Ipsum Dolor Sit Amet";
    private int curSymbol = 0;


    // Use this for initialization
    void Start () {
        thisText = GetComponent<Text>();
        tempTypeCD = maxTypeCD;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire"))
            tempTypeCD = 0.01f;
	
	}

    void FixedUpdate() {
        cursorCD -= Time.fixedDeltaTime;
        typeCD -= Time.fixedDeltaTime;
        if (cursorCD <= 0)
        {
            if (isCursor)
                thisText.text = thisText.text.Remove(thisText.text.Length-1);
            else
                thisText.text += "_";
            cursorCD = maxCursorCD;
            isCursor = !isCursor;
        }
        if (typeCD <=0 && curSymbol<typeBuffer.Length)
        {
            if (isCursor)
                thisText.text = thisText.text.Remove(thisText.text.Length - 1);
            thisText.text += typeBuffer[curSymbol];
            curSymbol++;
            if (isCursor)
                thisText.text += "_";
            typeCD = tempTypeCD;
        }
    }

    void TypeThis (string str)
    {
        typeBuffer = str;
        thisText.text = "_";
        tempTypeCD = maxTypeCD;
        typeCD = maxTypeCD;
        cursorCD = maxCursorCD;
        isCursor = true;
    }
}
