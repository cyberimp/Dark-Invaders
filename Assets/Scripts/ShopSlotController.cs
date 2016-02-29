using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ShopSlotController : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler {

    public enum ItemType
    {
        weapon,
        utility
    }

    public GameObject weaponPrefab;
    public ItemType itemType;
	Vector3 startPosition;

    public static GameObject itemDragged;
    public static ItemType typeDragged;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
        itemDragged = weaponPrefab;
        typeDragged = itemType;
		startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
        foreach (GameObject item in slots)
        {
            item.SendMessage("UpdateColor");
        }
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
        transform.position = Input.mousePosition;
//        transform.position = GetComponentInParent<Canvas>().worldCamera.ScreenToWorldPoint(eventData.position);

    }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
        itemDragged = null;
		transform.position = startPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
        foreach (GameObject item in slots)
        {
            item.SendMessage("UpdateColor");
        }

    }

    #endregion

    // Use this for initialization
    void Start () {

    //    GetComponent<Image>().sprite = weaponPrefab.GetComponent<SpriteRenderer>().sprite;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
