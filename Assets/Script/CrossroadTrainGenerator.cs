using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UIElements;

public class CrossroadTrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject obstacleTrainPrefab;
    [SerializeField] private Transform leftSpawnPosition;
    [SerializeField] private Transform rightSpawnPosition;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private float speed;
    [SerializeField] private Transform rightCollector;
    [SerializeField] private Transform leftCollector;
    public void SpawnTrain()
    {
        int i = Random.Range(0, 2);
        CrossDirection crossDirection = (CrossDirection) i;
        GameObject crossTrain;
        switch (crossDirection)
        {
            case CrossDirection.Left:
                crossTrain = Instantiate(obstacleTrainPrefab, leftSpawnPosition.position, Quaternion.Euler(0, 90, 0), parentTransform);
                StartCoroutine(MoveRoutine(crossTrain, rightCollector.position));
                break;
            case CrossDirection.Right:
                crossTrain = Instantiate(obstacleTrainPrefab, rightSpawnPosition.position, Quaternion.Euler(0, -90, 0), parentTransform);
                StartCoroutine(MoveRoutine(crossTrain, leftCollector.position));
                break;
            default:
                break;
        }
        
    }
    public IEnumerator MoveRoutine(GameObject gameObject,  Vector3 targetPos)
    {
        while (Vector3.Distance(gameObject.transform.position, targetPos) > 0.1f)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, speed * Time.deltaTime);

            yield return null;
        }
        Destroy(gameObject);
    }
}
