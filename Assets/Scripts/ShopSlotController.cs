using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlotController : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler {

    public GameObject weaponPrefab;
	Vector3 startPosition;

    public static GameObject itemDragged;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
        itemDragged = weaponPrefab;
		startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
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
    }

    #endregion

    // Use this for initialization
    void Start () {

        GetComponent<Image>().sprite = weaponPrefab.GetComponent<SpriteRenderer>().sprite;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
