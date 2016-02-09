using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShopSlotController : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector3 startPosition;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		startPosition = transform.localPosition;
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
        transform.position = Input.mousePosition;

    }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		transform.localPosition = startPosition;
	}

	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
