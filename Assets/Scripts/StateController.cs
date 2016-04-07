using UnityEngine;
using System.Collections;

public class StateController : MonoBehaviour {

    public static StateController instance;
    private int levelNo { get { return _level; } }
    [SerializeField]
    private int _level = 0;
    private GameObject[] inventory;
    void Awake()
    {
        if (instance != null && this != instance)
        {
            Destroy(transform.gameObject);
            return;
        }
        DontDestroyOnLoad(transform.gameObject);
        instance = this;
    }

    // Use this for initialization
    void Start () {
        inventory = new GameObject[2];
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int GetLevel()
    {
        return instance.levelNo;       
    }

    public static int IncLevel()
    {
        instance._level++;
        return instance.levelNo;
    }

    public static void Equip(GameObject what, ShopSlotController.ItemType type)
    {
        int slotNo = 0;
        if (type == ShopSlotController.ItemType.utility)
            slotNo = 1;
        instance.inventory[slotNo] = what;
    }

    public static GameObject[] Inventory()
    {
        return instance.inventory;
    }
}
