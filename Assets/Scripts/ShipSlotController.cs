using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShipSlotController : MonoBehaviour, IMoveHandler
{
    public ShopSlotController.ItemType accept;
    private GameObject weaponPrefab;
    public GameObject playerDemo;
    public Text label;
    public GameObject[] weaponPrefabs;
    public GameObject leftPanel;
    public GameObject rightPanel;
    private int selection = 0;
    private bool isChoosing = false;
    private GameObject nullGun;
    public Text gunDescription;

    // Use this for initialization
    void Start()
    {
        leftPanel.SendMessage("Visible", false);
        rightPanel.SendMessage("Visible", false);
        leftPanel.SendMessage("SetMain", gameObject);
        rightPanel.SendMessage("SetMain", gameObject);
        nullGun = Resources.Load("Guns/Null Gun") as GameObject;
        FillPrefabs();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FillPrefabs()
    {
        if (selection == 0)
            leftPanel.SendMessage("SetPrefab", nullGun);
        else
            leftPanel.SendMessage("SetPrefab", weaponPrefabs[selection - 1]);
        if (selection == weaponPrefabs.Length - 1)
            rightPanel.SendMessage("SetPrefab", nullGun);
        else
            rightPanel.SendMessage("SetPrefab", weaponPrefabs[selection + 1]);
        WeaponUpdate();
        GunDescription gunDesc = weaponPrefabs[selection].GetComponent<GunDescription>();
        gunDescription.text = gunDesc.description;
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
        weaponPrefab = weaponPrefabs[selection];
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

    public void OnClick()
    {
        isChoosing = !isChoosing;
        leftPanel.SendMessage("Visible", isChoosing);
        rightPanel.SendMessage("Visible", isChoosing);
    }

    void MoveSelection(int amount)
    {
        selection += amount;
        FillPrefabs();
    }

    public void ShowPanels()
    {
        isChoosing = true;
        leftPanel.SendMessage("Visible", true);
        rightPanel.SendMessage("Visible", true);

    }

    public void HidePanels(BaseEventData bed)
    {

        isChoosing = false;
        leftPanel.SendMessage("Visible", false);
        rightPanel.SendMessage("Visible", false);

    }

    public void OnMove(AxisEventData eventData)
    {
        if (eventData.moveDir == MoveDirection.Left && leftPanel.GetComponent<Image>().enabled)
            MoveSelection(-1);
        if (eventData.moveDir == MoveDirection.Right && rightPanel.GetComponent<Image>().enabled)
            MoveSelection(1);
    }
}
