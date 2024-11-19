using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "so_ItemData", menuName = "Scriptable Object/ItemData")]
public class SO_ItemData : ScriptableObject
{
    [SerializeField] private List<ItemData> itemDatas = new List<ItemData>();
    [SerializeField] private List<Material> pantMaterials = new List<Material>();





    public Material GetPantMaterial(Pant pant)
    {
        return pantMaterials[(int)pant -1];
    }
}
