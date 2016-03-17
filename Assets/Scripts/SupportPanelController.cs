using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SupportPanelController : MonoBehaviour {

    private GameObject prefab;
    private GameObject mainPanel;
    public int selectionChange;
    private bool isVisible;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Visible(bool state)
    {
        isVisible = state;
        if (state && prefab.name == "Null Gun")
            return;
        Show(state);
    }

    void Show(bool state)
    {
        GetComponent<Image>().enabled = state;
        transform.GetChild(0).gameObject.GetComponent<Image>().enabled = state;

    }

    void SetPrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
        Sprite icon = null;
        if (prefab.name != "Null Gun")
        {
            icon = prefab.GetComponent<SpriteRenderer>().sprite;
        }
        if (isVisible)
            Show(icon != null);
        transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icon;
    }

    void SetMain(GameObject newMain)
    {
        mainPanel = newMain;
    }

    public void OnClick()
    {
        mainPanel.SendMessage("MoveSelection", selectionChange);
    }
}
