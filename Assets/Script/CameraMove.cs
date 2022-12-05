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
    private Vector3 offset;
    private Vector3 newtrans;
    //Home
    private bool GoHome = false;
    private float speedHome = 30f; 
    void Start()
    {
        targetZoom = cam.orthographicSize;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        newtrans = transform.position;
        rotateAngle = transform.rotation.z;
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    offset.x = transform.position.x - player.transform.position.x;
        //    offset.y = transform.position.y - player.transform.position.y;
        //    offset.y = transform.position.z;
        //    newtrans = Vector3.MoveTowards(transform.position, offset, speed);
        //    GetComponent<Rigidbody2D>().MovePosition(newtrans);
        //}

        if(rotateCam)
        transform.Rotate(0f, 0f, rotateSpeed, Space.World);

        //if (GlobalVariables.FreeCam)
        //{
        //    newtrans.x = player.transform.position.x + offset.x;
        //    newtrans.y = player.transform.position.y + offset.y;
        //    transform.position = newtrans;
        //}

        //Надо разобрать почему не работает сразу , а только после движения мышкой
        //Теперь дергается делает сдвиг и возвращается на прежнюю позицию сразу , и движение по осям надо делать в общих координатах
        //Только один сдвиг
        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        ////Слишком резко
        //if (Input.GetKeyDown(KeyCode.Q))
        ////            transform.rotation = Quaternion.Euler(0f, 0f, 10f);
        ////Вроде работает но надо тут ключ активировать а не само вращение делать
        //{
        //    GlobalVariables.RotateTimer = 10;
        //    GlobalVariables.RotateCam = 1f;
        //}
        //else if (GlobalVariables.RotateTimer > 0)
        //    GlobalVariables.RotateTimer -= 1;
        //else if (Input.GetKeyDown(KeyCode.E))
        //    transform.rotation = Quaternion.Euler(0f, 0f, -10f);
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //    rb.velocity = new Vector3(0f, 0f, 10f * speed);
        //else if (Input.GetKeyDown(KeyCode.LeftControl))
        //    rb.velocity = new Vector3(0f, 0f, -10f * speed);

    }

    private void LateUpdate()
    {
        //if (!Input.anyKey||Input.anyKeyDown)
        //if (!Input.anyKey)
        //if(GlobalVariables.FreeCam)
        //{
        //    newtrans.x = player.transform.position.x + offset.x;
        //    newtrans.y = player.transform.position.y + offset.y;
        //    transform.position = newtrans;
        //}
        //    if (Input.GetKey(KeyCode.Q))
        //        transform.rotation = Quaternion.Euler(0f, 0f, 100f * Time.deltaTime);
        //    else if (Input.GetKey(KeyCode.E))
        //    transform.rotation = Quaternion.Euler(0f, 0f, -100f * Time.deltaTime);

    }

    private void Update()
    {
        MoveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //if (GlobalVariables.RotateTimer > 0)
        //    transform.Rotate(0f, 0f, GlobalVariables.RotateCam, Space.World);
        //        //transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
        //        transform.rotation = Quaternion.Euler(0f, 0f , 100f * Time.deltaTime);
        //    //else if (Input.GetKey(KeyCode.E))
        //    ////transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
        //    //transform.rotation = Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
        //Home
        if (Input.GetKey(KeyCode.H))
        {
            //Что не так ?
          //  MoveCamera(player.transform.position.x, player.transform.position.y);
            //Повернуть как было
            //cam.transform.Rotate(transform.rotation.x, transform.rotation.y, rotateAngle, Space.World);
//            transform.Rotate(0f, 0f, 0f, Space.World);
            transform.rotation = Quaternion.Euler(0, 0, rotateAngle);
            //Debug.Log("Presed H");
            GoHome = true;
        }
        if (GoHome)
        {
            var step = speedHome * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
            {
//                player.transform.position *= -1.0f;
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
        //if (!(z == 0))
        //    transform.Translate(Vector3.forward * z);
    }
}
