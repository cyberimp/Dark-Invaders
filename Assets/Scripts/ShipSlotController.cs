using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShipSlotController : MonoBehaviour, IDropHandler
{

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

    private void WeaponUpdate()
    {
        if (weaponPrefab != null)
        {
            GetComponentsInChildren<Image>()[1].sprite = weaponPrefab.GetComponent<SpriteRenderer>().sprite;
            label.SendMessage("SetText", weaponPrefab.name);
            playerDemo.SendMessage("SetWeapon", weaponPrefab);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {

        weaponPrefab = ShopSlotController.itemDragged;
        WeaponUpdate();
    }
}
