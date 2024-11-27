using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private SO_ZoneSegment zoneData;
    [SerializeField] private SO_TownObstacleFrequence townObstacleFrequence;
    [SerializeField] private int currentLevelRoad = 0;
    [SerializeField] private ZoneType currentZone = ZoneType.TownZone;
    [SerializeField] private Road currentRoad;
    [SerializeField] private int obtainCoinAmountOnCurrentMap = 0;
    private List<GameObject> roadList = new List<GameObject>();
    private int deliveriedMailOnCurrentZone = 0;
    public int deliveriedMaillOnCurrentMap = 0;
    public void SpawnRoad()
    {   
        if (currentLevelRoad == 3)
        {
            return;
        }
        Vector3 spawnPos = townObstacleFrequence.GetRoadSpawnPosition(currentLevelRoad);
        GameObject _tmp = Instantiate(zoneData.GetZoneTile(currentZone), spawnPos, Quaternion.Euler(0,0,0));
        currentRoad = _tmp.GetComponent<Road>();
        
        
        if(currentLevelRoad == 1)
        {
            SpawnMailDeliveryArea();
            SpawnChunk();
        }
        else
        {
            Spawn();
            SpawnObstacle();
            if(currentLevelRoad == 2)
            {
                SpawnFinishPoint();
            }
        }
        
        currentLevelRoad++;
        roadList.Add(currentRoad.gameObject);
    }
    public void SpawnChunk()
    {
        GameObject rightChunk, leftChunk;
        for(int i =0; i < 3; i++)
        {
            rightChunk = Instantiate(zoneData.GetRandomChunk(currentZone), new Vector3(20.5f, currentRoad.transform.position.y, 20 + currentRoad.transform.position.z + i * 40), Quaternion.Euler(0, 0, 0), currentRoad.GetObstaclesParentTransform());
            leftChunk = Instantiate(zoneData.GetRandomChunk(currentZone), new Vector3(-20.5f, currentRoad.transform.position.y, 20 + currentRoad.transform.position.z + i * 40), Quaternion.Euler(0, 180, 0), currentRoad.GetObstaclesParentTransform());
            if(rightChunk.GetComponent<Chunk>())
                rightChunk.GetComponent<Chunk>().RotateHouse();
        }
 
    }
    public void SpawnChunkCross()
    {
        GameObject rightChunk, leftChunk;
        for (int i = 1; i < 3; i++)
        {
            rightChunk = Instantiate(zoneData.GetRandomChunk(currentZone), new Vector3(20.5f, currentRoad.transform.position.y, 20 + currentRoad.transform.position.z + i * 40), Quaternion.Euler(0, 0, 0), currentRoad.GetObstaclesParentTransform());
            leftChunk = Instantiate(zoneData.GetRandomChunk(currentZone), new Vector3(-20.5f, currentRoad.transform.position.y, 20 + currentRoad.transform.position.z + i * 40), Quaternion.Euler(0, 180, 0), currentRoad.GetObstaclesParentTransform());
            if(rightChunk.GetComponent<Chunk>())
                rightChunk.GetComponent<Chunk>().RotateHouse();
        }

    }
    public void SpawnObstacle()
    {
        
       GameObject tmp;
       for(int i = 0; i < townObstacleFrequence.GetObstacleCount(); i++)
       {
            tmp = townObstacleFrequence.GetRandomObstacle();
            Vector3 roadSpawnPosition = townObstacleFrequence.GetObstacleSpawnPosition(i) + new Vector3(0, 0, currentLevelRoad * 120);
            Instantiate(tmp, roadSpawnPosition, Quaternion.Euler(0, 0, 0), currentRoad.GetObstaclesParentTransform());       
       }
    }
    public void SpawnMailDeliveryArea()
    {
        GameObject tmp = Instantiate(townObstacleFrequence.GetMailDeliveryArea(MapManager.Ins.currentZone), currentRoad.transform.position, Quaternion.Euler(0, 0, 0),currentRoad.GetObstaclesParentTransform());

    }
    public void SpawnCrossRoad()
    {
        Instantiate(townObstacleFrequence.crossRoad, currentRoad.transform.position + new Vector3(0,0,40), Quaternion.Euler(0, -90, 0), currentRoad.GetObstaclesParentTransform());
    }
    public void SpawnFinishPoint()
    {
        GameObject tmp = Instantiate(townObstacleFrequence.finishPoint, townObstacleFrequence.finishPointPosition, Quaternion.Euler(0, 0,0), currentRoad.GetObstaclesParentTransform());
    }
    public void ObtainCoin()
    {
        obtainCoinAmountOnCurrentMap++;
    }
    public void ObtainCoinByDelivery()
    {
        obtainCoinAmountOnCurrentMap += 30;
        deliveriedMaillOnCurrentMap += 1;
    }
    public void ResetCoin()
    {
        obtainCoinAmountOnCurrentMap = 0;
    }
    public int GetObtainCoinOnCurrentMap()
    {
        return obtainCoinAmountOnCurrentMap;
    }
    public void ResetRoad()
    {
        for(int i = 0; i < roadList.Count; i++)
        {
            Destroy(roadList[i]);
        }
        roadList.Clear();
        currentLevelRoad = 0;
        obtainCoinAmountOnCurrentMap = 0;
        deliveriedMaillOnCurrentMap = 0;
        SpawnRoad();
        Player.Ins.ResetPosition();
    }
    public void ChangeZone()
    {
        ZoneType zone;
        do
        {
            int i = Random.Range(0, 2);
            zone = (ZoneType)i;
        }
        while (zone == currentZone);
        currentZone = zone;
    }
    public int GetDeliveriedMailQuantityOnCurrentLevel()
    {
        return deliveriedMaillOnCurrentMap;
    }
    public int GetDeliveriedMailQuantityOnCurrentZone()
    {
        return deliveriedMailOnCurrentZone;
    }
    public void UpdateDeliveriedMailQuantityOnCurrentZone()
    {
        deliveriedMailOnCurrentZone += 1;
        if(deliveriedMailOnCurrentZone >= 10)
        {
            deliveriedMailOnCurrentZone -= 10;
            ChangeZone();
        }
    }
    public void Spawn()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                SpawnChunk();
                break;
            case 1:
                SpawnChunkCross();
                SpawnCrossRoad();
                break;
        }
    }
}