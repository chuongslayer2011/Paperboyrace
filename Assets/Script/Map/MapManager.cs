using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeMap
{
    Village,
}

public class MapManager : Singleton<MapManager>
{
    public LevelData data;
    public TypeMap typeMap = TypeMap.Village;

    public GameObject currentMap;
    public GameObject currentRoad;

    private int maxMapLength = 10;
    private int crossRoadPos;
    private int level = 1;

    private void Start()
    {
        SpawnMap();
    }

    public void SpawnMap()
    {
        // get data level

        // 10 level đầu sẽ không có đường chạy qua hoặc tàu hoả
        if(level > 10)
        {
            crossRoadPos = Random.RandomRange(2, maxMapLength - 1);
        }
        for(int i = 1; i <= maxMapLength; i++)
        {
            if(i != crossRoadPos)
            {
                GameObject go = GetRandomChunk(typeMap);
                go = Instantiate(go, new Vector3(0, -0.2f, 40f * (i - 1)), Quaternion.identity);
                go.transform.SetParent(currentMap.transform, false);
            }
            else
            {
                GameObject go = GetRandomCrossRoad(typeMap);
                go = Instantiate(go, new Vector3(0, -0.2f, 40f * (i - 1)), Quaternion.identity);
                go.transform.SetParent(currentMap.transform, false);

            }
            
            GameObject roadTile = GetRoadTile(typeMap);
            
            
            for(int j = -3; j <= 3; j++)
            {
                GameObject tile = Instantiate(roadTile, new Vector3(0, 0, 40f * (i - 1) + 6 * j), Quaternion.identity);
                tile.transform.SetParent(currentRoad.transform, false);
                
            }

            
        }
    }

    private GameObject GetRandomChunk(TypeMap type)
    {
        switch(type)
        {
            case TypeMap.Village:
                int i = Random.Range(0,data.villages.Count); 
                return data.villages[i];
                break;
        }
        return data.villages[0];
    }

    private GameObject GetRandomCrossRoad(TypeMap type)
    {
        switch (type)
        {
            case TypeMap.Village:
                int i = Random.Range(0, data.crossRoadVillages.Count);
                return data.crossRoadVillages[i];
                break;
        }
        return data.crossRoadVillages[0];
    }

    private GameObject GetRoadTile(TypeMap type)
    {
        switch (type)
        {
            case TypeMap.Village:
                return data.roadTile_Village;
                break;
        }
        return data.roadTile_Village;
    }



    /*
    [SerializeField] private SO_ZoneSegment zoneData;
    [SerializeField] private SO_TownObstacleFrequence townObstacleFrequence;
    [SerializeField] private int currentLevelRoad = 0;
    [SerializeField] private ZoneType currentZone = ZoneType.TownZone;
    [SerializeField] private Road currentRoad;
    [SerializeField] private int obtainCoinAmountOnCurrentMap = 0;
    private List<GameObject> roadList = new List<GameObject>();
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
        GameObject tmp = Instantiate(townObstacleFrequence.GetMailDeliveryArea(), currentRoad.transform.position, Quaternion.Euler(0, 0, 0),currentRoad.GetObstaclesParentTransform());

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
        SpawnRoad();
        Player.Ins.ResetPosition();
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
    */
}