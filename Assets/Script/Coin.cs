using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MapManager.Ins.ObtainCoin();
        gameObject.SetActive(false);
    }
}
