using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemData
{
    [SerializeField] private int price;
    public int GetPrice()
    {
        return price;
    }
}
