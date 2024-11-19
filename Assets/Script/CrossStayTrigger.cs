using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossStayTrigger : MonoBehaviour
{

    [SerializeField] private CrossroadTrainGenerator crossroadTrainGenerator;
    public float spawnInterval = 5f;
    public Animator trafficLightAnimator1;
    public Animator trafficLightAnimator2;
    private bool isPlayerInCollider = false;

    private void OnTriggerEnter(Collider other)
    {
            isPlayerInCollider = true;
            StartCoroutine(SpawnObjects());
    }

    private void OnTriggerExit(Collider other)
    {
            isPlayerInCollider = false;
            StopCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (isPlayerInCollider)
        {
            crossroadTrainGenerator.SpawnTrain();
            trafficLightAnimator1.SetTrigger("active");
            trafficLightAnimator2.SetTrigger("active");
            yield return new WaitForSeconds(spawnInterval);
            trafficLightAnimator1.SetTrigger("inactive");
            trafficLightAnimator2.SetTrigger("inactive");
        }
    }
}
