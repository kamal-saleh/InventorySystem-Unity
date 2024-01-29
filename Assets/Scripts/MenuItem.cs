using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Button buyAndSellButton;
    [SerializeField] private ShopData shopData;

    private Item item;

    public void Initialize(Item item)
    {
        this.item = item;
        nameText.text = item.itemName;
        price.text = item.itemPrice.ToString();
    }

    public void ButtonPressed()
    {
        if (buyAndSellButton.GetComponentInChildren<TextMeshProUGUI>().text == "Buy")
        {
            Buy();
        }
        else
        {
            Sell();
        }
    }

    private void Buy()
    {
        if (GameManager.Instance.playerBalance > item.itemPrice)
        {
            GameManager.Instance.playerBalance -= item.itemPrice;

            if (GameManager.Instance.shopItems1.Contains(item))
            {
                GameManager.Instance.shopItems1.Remove(item);
            }
            else if (GameManager.Instance.shopItems2.Contains(item))
            {
                GameManager.Instance.shopItems2.Remove(item);
            }

            GameManager.Instance.PlayerItems.Add(item);
            GameManager.Instance.Refresh();
        }
    }

    private void Sell()
    {

        if (shopData.shopItems1.Contains(item) && GameManager.Instance.shopkeepr1.activeSelf)
        {
            GameManager.Instance.shopItems1.Add(item);
            SellItem();
        }
        else if (shopData.shopItems2.Contains(item) && GameManager.Instance.shopkeepr2.activeSelf)
        {
            GameManager.Instance.shopItems2.Add(item);
            SellItem();
        }

        
    }

    private void SellItem()
    {
        GameManager.Instance.playerBalance += item.itemPrice;
        GameManager.Instance.PlayerItems.Remove(item);
        GameManager.Instance.Refresh();
    }
}