using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("Village")]
    public List<GameObject> villages = new List<GameObject>();
    public List<GameObject> crossRoadVillages = new List<GameObject>();
    public GameObject roadTile_Village;
}
