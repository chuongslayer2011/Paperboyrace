using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "so_TownObstacleFrequence", menuName = "Scriptable Object/TownObstacleFrequence")]
public class SO_TownObstacleFrequence : ScriptableObject
{
    [SerializeField] public List<Vector3> obstacleFrequenceTownList1;
    [SerializeField] public List<GameObject> obstacleList;
    [SerializeField] public List<Vector3> roadSpawnPosition;
    [SerializeField] public Vector3 finishPointPosition;
    [SerializeField] public List<GameObject> mailDeliveryArea;
    [SerializeField] public GameObject finishPoint;
    [SerializeField] public GameObject crossRoad;
    public GameObject GetRandomObstacle()
    {
        int i = Random.Range(0, obstacleList.Count);
        return obstacleList[i];
    }
    public Vector3 GetRoadSpawnPosition(int index)
    {
        return roadSpawnPosition[index];
    }
    public int GetObstacleCount()
    {
        return obstacleFrequenceTownList1.Count;
    }
    public Vector3 GetObstacleSpawnPosition(int index)
    {
        return obstacleFrequenceTownList1[index];
    }
    public GameObject GetMailDeliveryArea()
    {
        int i = Random.Range(0, mailDeliveryArea.Count);
        return mailDeliveryArea[i];
    }
    public GameObject GetCrossRoad()
    {
        return crossRoad;
    }
}
