using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private List<GameObject> houseList = new List<GameObject>();

    public void RotateHouse()
    {
        if (houseList.Count == 0) return;
            for(int i = 0; i < houseList.Count; i++)
            {
                houseList[i].transform.rotation = Quaternion.Euler(0,0,0);
            }
            
    }
}
