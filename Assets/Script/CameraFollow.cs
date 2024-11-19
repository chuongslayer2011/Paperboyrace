using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    public Transform target;
    public Vector3 offset;
    public float speed = 5;
    public Camera Camera;
    // Start is called before the first frame update
    private void Awake()
    {

        Camera = Camera.main;
    }
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.fixedDeltaTime * speed);
    }
    public void SetCameraOnVictory()
    {
        offset = new Vector3(0, 4, -6);
    }
    public void SetCameraOnMenu()
    {
        offset = new Vector3(0, 3, -4);
    }
    public void SetCameraOnPlay()
    {
        offset = new Vector3(0, 6.2f, -4.9f);
    }
}
