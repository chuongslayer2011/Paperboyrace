using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem coffetti1;
    [SerializeField] private ParticleSystem coffetti2;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Ins.OnVictory();
        coffetti1.Play();
        coffetti2.Play();
    }
}
