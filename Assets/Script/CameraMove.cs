using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMove : MonoBehaviour
{
    //Zoom
    public Camera cam;
    public float maxZoom = 5;
    public float minZoom = 20;
    public float sensitivity = 1;
    float targetZoom;
    //Rotate
    private bool rotateCam = false;
    private float rotateSpeed = 0f;
    private float rotateAngle;

    [SerializeField]
    private float speed = 25f;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject player;
    //private Vector3 offset;
    //private Vector3 newtrans;
    //Home
    private bool GoHome = false;
    private float speedHome = 30f;
    void Start()
    {
        targetZoom = cam.orthographicSize;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        //offset.x = transform.position.x - player.transform.position.x;
        //offset.y = transform.position.y - player.transform.position.y;
        //newtrans = transform.position;
        rotateAngle = transform.rotation.z;
    }

    private void FixedUpdate()
    {
        if (rotateCam)
            transform.Rotate(0f, 0f, rotateSpeed, Space.World);
    }

    private void Update()
    {
        MoveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Home
        if (Input.GetKey(KeyCode.H))
        {
            transform.rotation = Quaternion.Euler(0, 0, rotateAngle);
            GoHome = true;
        }
        if (GoHome)
        {
            var step = speedHome * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
            {
                GoHome = false;
            }
        }
        //Zoom
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
        //Rotate
        if (Input.GetKey(KeyCode.Q))
        {
            rotateCam = true;
            rotateSpeed = 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotateCam = true;
            rotateSpeed = -1f;
        }
        if (Input.GetKeyUp(KeyCode.Q))
            rotateCam = false;
        if (Input.GetKeyUp(KeyCode.E))
            rotateCam = false;
    }

    void MoveCamera(float x, float y)
    {
        Vector3 movementAmount = new Vector3(x, y, 0f) * speed * Time.deltaTime;
        transform.Translate(movementAmount);
    }
}
