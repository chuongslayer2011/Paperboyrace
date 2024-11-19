using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "so_ZoneSegment", menuName = "Scriptable Object/ZoneSegment")]
public class SO_ZoneSegment : ScriptableObject
{
    [SerializeField] public List<GameObject> townSegmentList;
    [SerializeField] public List<GameObject> villageSegmentList;
    [SerializeField] public GameObject townTile;
    [SerializeField] public GameObject villageTile;
    [SerializeField] public GameObject townBaseLevel;
    [SerializeField] public GameObject villageBaseLevel;
    public GameObject GetZoneTile(ZoneType zoneType)
    {
        switch (zoneType)
        {
            case ZoneType.TownZone: return townTile;
            case ZoneType.VillageZone: return villageTile;
            default: return null;
        }
    }
    public List<GameObject> GetSegmentList(ZoneType zoneType)
    {
        switch (zoneType)
        {
            case ZoneType.TownZone: return townSegmentList;
            case ZoneType.VillageZone: return villageSegmentList;
            default: return null;
        }
    }
    public GameObject GetRandomChunk(ZoneType zoneType)
    {
        int i = Random.Range(0, 4);
        switch (zoneType)
        {
            case ZoneType.TownZone: return townSegmentList[i];
            case ZoneType.VillageZone: return villageSegmentList[i];
            default: return null;
        }
    }
}
