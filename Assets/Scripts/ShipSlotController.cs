using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShipSlotController : MonoBehaviour, IDropHandler
{
    public ShopSlotController.ItemType accept; 
    public GameObject weaponPrefab;
    public GameObject playerDemo;
    public Text label;

    // Use this for initialization
    void Start()
    {
        WeaponUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateColor()
    {
        if (ShopSlotController.itemDragged != null && ShopSlotController.typeDragged == accept)
            GetComponent<Image>().color = Color.green;
        else
            GetComponent<Image>().color = Color.white;

    }

    private void WeaponUpdate()
    {
        if (weaponPrefab != null)
        { 
            GetComponentsInChildren<Image>()[1].sprite = weaponPrefab.GetComponent<SpriteRenderer>().sprite;
            if (accept == ShopSlotController.ItemType.weapon)
            {
                label.SendMessage("SetText", weaponPrefab.name);
                playerDemo.SendMessage("SetWeapon", weaponPrefab);
            }
            else
                playerDemo.SendMessage("SetUtility", weaponPrefab);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (ShopSlotController.itemDragged != null && ShopSlotController.typeDragged == accept)
        {
            weaponPrefab = ShopSlotController.itemDragged;
            WeaponUpdate();
        }
    }
}
