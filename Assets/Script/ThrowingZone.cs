using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingZone : MonoBehaviour
{
    [SerializeField] private Transform throwingDestination;
    [SerializeField] private Animator letterBoxAnimator;
    [SerializeField] private Animator checkAnimator;
    [SerializeField] private GameObject checkBox;
    private bool isDeliveried = false;
    private void Start()
    {
        letterBoxAnimator.SetTrigger("Idle");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDeliveried) return;
        Player.Ins.DeliveryNewPaper(throwingDestination.position);
        StartCoroutine(PlayAnim());
        MapManager.Ins.ObtainCoinByDelivery();
        EventManager.CallDeliveryMailEvent();
        isDeliveried = true;
    }
    private IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(0.75f);
        letterBoxAnimator.SetTrigger("Play");
        checkBox.SetActive(true);
        checkAnimator.SetTrigger("Bounce");
    }
}
