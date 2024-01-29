using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Data", menuName = "Shop")]
public class ShopData  : ScriptableObject
{
    public List<Item> shopItems1;
    public List<Item> shopItems2;
}