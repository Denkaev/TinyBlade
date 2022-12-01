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

    [SerializeField]
    private float speed = 25f;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    private Vector3 newtrans;
    void Start()
    {
        targetZoom = cam.orthographicSize;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        newtrans = transform.position;
    }

    private void FixedUpdate()
    {
        //if (GlobalVariables.FreeCam)
        //{
        //    newtrans.x = player.transform.position.x + offset.x;
        //    newtrans.y = player.transform.position.y + offset.y;
        //    transform.position = newtrans;
        //}

        //Ќадо разобрать почему не работает сразу , а только после движени€ мышкой
        //“еперь дергаетс€ делает сдвиг и возвращаетс€ на прежнюю позицию сразу , и движение по ос€м надо делать в общих координатах
        //“олько один сдвиг
        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        ////—лишком резко
        //if (Input.GetKeyDown(KeyCode.Q))
        ////            transform.rotation = Quaternion.Euler(0f, 0f, 10f);
        ////¬роде работает но надо тут ключ активировать а не само вращение делать
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
        MoveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Mouse ScrollWheel"));

        //if (GlobalVariables.RotateTimer > 0)
        //    transform.Rotate(0f, 0f, GlobalVariables.RotateCam, Space.World);
        //        //transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
        //        transform.rotation = Quaternion.Euler(0f, 0f , 100f * Time.deltaTime);
        //    //else if (Input.GetKey(KeyCode.E))
        //    ////transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
        //    //transform.rotation = Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);

       //Zoom
        targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, speed * Time.deltaTime);
        cam.orthographicSize = newSize;

    }

    void MoveCamera(float x, float y, float z)
    {
        Vector3 movementAmount = new Vector3(x, y, z) * speed * Time.deltaTime;
        transform.Translate(movementAmount);
        if (!(z == 0))
        transform.Translate(Vector3.forward * z);
    }
}
