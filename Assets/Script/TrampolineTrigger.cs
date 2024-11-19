using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {   
        Player.Ins.JumpOnTrampoline();
    }
}
