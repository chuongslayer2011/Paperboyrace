using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewPaper : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;






    public void Delivery(Vector3 targetPos)
    {
        StartCoroutine(DeliveryRoutine(targetPos));
    }
    public IEnumerator DeliveryRoutine(Vector3 targetPos)
    {
        animator.SetTrigger("Throw");
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            yield return null;
        }
        Destroy(gameObject);
    }
}
