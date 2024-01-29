using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DeleteChildren;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Data")]
    public int playerBalance = 1000;
    public int bankAccountBalance = 3000;
    
    [SerializeField] private ShopData shopData;

    [Header("InventoryItems")]
    [SerializeField] private GameObject menuItem;

    [HideInInspector] public List<Item> shopItems1;
    [HideInInspector] public List<Item> shopItems2;
    [HideInInspector] public List<Item> PlayerItems = new List<Item>();

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerBalanceValue;
    [SerializeField] private TextMeshProUGUI bankBalanceValue;
    [SerializeField] private GameObject shopItems1Parent;
    [SerializeField] private GameObject shopItems2Parent;
    [SerializeField] private GameObject playerItemsParent;

    public GameObject shopkeepr1;
    public GameObject shopkeepr2;

    void Awake()
    {
        Instance = this;
        shopItems1 = new List<Item>(shopData.shopItems1);
        shopItems2 = new List<Item>(shopData.shopItems2);
    }

    void Start()
    {
        UpdateGameUI();
    }

    public void UpdateGameUI()
    {
        playerBalanceValue.text = playerBalance.ToString();
        bankBalanceValue.text = bankAccountBalance.ToString();
    }

    public void OpenShopKeeper1Inventory()
    {
        TransformExtension.ClearChildren(shopItems1Parent.transform);
        if (shopItems1.Count != 0)
        {
            foreach (Item item in shopItems1)
            {
                GameObject newItem = Instantiate(menuItem) as GameObject;
                newItem.transform.SetParent(shopItems1Parent.transform);
                newItem.GetComponent<MenuItem>().Initialize(item);
            }
        }
    }

    public void OpenShopKeeper2Inventory()
    {
        TransformExtension.ClearChildren(shopItems2Parent.transform);
        if (shopItems2.Count != 0)
        {
            foreach (Item item in shopItems2)
            {
                GameObject newItem = Instantiate(menuItem) as GameObject;
                newItem.transform.SetParent(shopItems2Parent.transform);
                newItem.GetComponent<MenuItem>().Initialize(item);
            }
        }
    }

    public void OpenPlayerInventory()
    {
        TransformExtension.ClearChildren(playerItemsParent.transform);
        if (PlayerItems.Count != 0)
        {
            foreach (Item item in PlayerItems)
            {
                GameObject newItem = Instantiate(menuItem) as GameObject;
                newItem.transform.SetParent(playerItemsParent.transform);
                newItem.GetComponent<MenuItem>().Initialize(item);
                newItem.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
            }
        }
    }

    public void Refresh()
    {
        TransformExtension.ClearChildren(shopItems1Parent.transform);
        TransformExtension.ClearChildren(shopItems2Parent.transform);
        TransformExtension.ClearChildren(playerItemsParent.transform);
        OpenShopKeeper1Inventory();
        OpenShopKeeper2Inventory();
        OpenPlayerInventory();
        UpdateGameUI();
    }
}