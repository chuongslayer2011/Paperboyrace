using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform obstaclesParentTransform;
    





    public Transform GetObstaclesParentTransform()
    {
        return obstaclesParentTransform;
    }
}
