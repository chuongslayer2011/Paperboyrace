using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareToThrowZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player.Ins.DisplayNewPaperOnHand();
    }
}
