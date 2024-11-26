using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [Header("Movement Settings")]
    public float maxRange = 3f;         // khoảng cách tối đa sang 2 phía mà player có thể di chuyển
    public float limitValue = 2.6f;     // tốc độ di chuyển sang 2 bên
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float movingSpeed = 15f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform newPaperOnHandTransformParent;
    [SerializeField] private GameObject newPaperPrefab;
    private NewPaper newPaperOnHand;
    private string currentAnimName;
    private bool isPlay = false;
    private bool isDelivery = false;
    private bool isJumping = false;
    private void FixedUpdate()
    {
        if (!isPlay) return;
        Moving();
    }

    private void Moving()
    {
        Vector3 movementDirection = new Vector3(joystick.Horizontal, 0, 1);
        if (movementDirection.x != 0 && Input.GetMouseButton(0))
        {
            playerRigidbody.velocity = movementDirection * movingSpeed + playerRigidbody.velocity.y * Vector3.up;
            if (!isDelivery && !isJumping)
            {
                ChangeAnim("run");
            }
        }
        else
        {
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);
            if (!isDelivery && !isJumping)
            {
                ChangeAnim("idle");
            }
        }
        if (Mathf.Abs(transform.position.x) > 2.7)
        {
            float direct = transform.position.x / Mathf.Abs(transform.position.x);
            transform.position = new Vector3(direct * 2.7f, transform.position.y, transform.position.z);
        }
    }
    public void JumpOnTrampoline()
    {
        isJumping = true;
        ChangeAnim("jump");
        playerRigidbody.AddForce(new Vector3(0, 0.75f,10) * jumpForce, ForceMode.Impulse);
        Invoke(nameof(ResetJumpAnim), 1.55555f);
    }
    public void SetPlayingState(bool isPlaying)
    {
        isPlay = isPlaying;
    }
    public void ResetPosition()
    {
        transform.position = new Vector3(0, 1, -16f);
    }
    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            animator.ResetTrigger(animName);
            currentAnimName = animName;
            animator.SetTrigger(currentAnimName);
        }
    }
    public void StopMoving()
    {
        playerRigidbody.velocity = Vector3.zero;
    }
    public void DisplayNewPaperOnHand()
    {
        GameObject _tmp = Instantiate(newPaperPrefab, newPaperOnHandTransformParent);
        newPaperOnHand = _tmp.GetComponentInChildren<NewPaper>(); 
    }

    public void DeliveryNewPaper(Vector3 targetPos)
    {
        isDelivery = true;
        ChangeAnim(Cache.DELIVERY_ANIM);
        newPaperOnHand.transform.parent = null;
        newPaperOnHand.Delivery(targetPos);
        Invoke(nameof(ResetDeliveryAnim),0.6f);
    }
    public float GetZPosition()
    {
        return transform.position.z;
    }
    public void ResetDeliveryAnim()
    {
     
        isDelivery = false;
    }
    public void ResetJumpAnim()
    {

        isJumping = false;
    }
}
