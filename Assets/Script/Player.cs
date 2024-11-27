using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Singleton<Player>
{
    [Header("Movement Settings")]
    public float maxRange = 2f;         // khoảng cách tối đa sang 2 phía mà player có thể di chuyển
    public float limitValue = 1.5f;     // tốc độ di chuyển sang 2 bên
    public float movingSpeed = 15f;     // tốc độ di chuyển về phía trước, không đổi
    public float brakingSpeed = 0.1f;   // tốc độ hãm lại của player
    public float jumpForce = 5f;        // lực nhảy

    public Vector3 direcJump;

    [Header("Delivery")]
    public Transform newPaperOnHandTransformParent;
    public GameObject newPaperPrefab;


    private Rigidbody rigidbody;
    private Animator animator;


    private NewPaper newPaperOnHand;
    private string currentAnimName;
    private bool isPlay = false;
    private bool isDelivery = false;
    private bool isJumping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {   
        if (!isPlay) return;

        Vector3 movement = Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            float haftScreen = Screen.width / 2f;
            float xPos = (Input.mousePosition.x - haftScreen) / haftScreen;
            float finalXPos = Mathf.Clamp(xPos * limitValue, -limitValue, limitValue);
            movement = new Vector3(finalXPos, 0, 1f);
            Moving(movement);

        }else if (Input.GetMouseButtonUp(0))
        {
            movement = new Vector3(0, 0, -brakingSpeed);
            Stop(movement);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.J) )
        {
            isJumping = false;
            JumpOnTrampoline();
        }
    }

    private void Moving(Vector3 movement)
    {
        animator.SetBool("isRunning", true);
        if((transform.position.x >= maxRange && movement.x > 0) || (transform.position.x <= -maxRange && movement.x < 0))
        {
            movement.x = 0f;
        }
        rigidbody.velocity = new Vector3(movement.x * movingSpeed, rigidbody.velocity.y, movement.z * movingSpeed);

    }

    private void Stop(Vector3 movement)
    {
        animator.SetBool("isRunning", false);
        rigidbody.velocity = new Vector3(0, 0, rigidbody.velocity.z);
        if (rigidbody.velocity.z > 0f)
        {
            rigidbody.velocity += movement;
        }

    }
    public void JumpOnTrampoline()
    {
        if(isJumping == false) 
        {
            rigidbody.AddForce(direcJump * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("jump");
            isJumping = true;
        }
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
        rigidbody.velocity = Vector3.zero;
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
