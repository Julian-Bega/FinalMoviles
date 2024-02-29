using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Shopper", menuName = "ScriptableObjects/ShopScriptableObject", order = 1)]
public class Shopper : ScriptableObject
{
    public int ID;
    public Sprite carSprite;
    public int price;
    public bool selectable;
}
