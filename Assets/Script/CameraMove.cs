using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    private Vector3 newtrans;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        newtrans = transform.position;
    }

    private void FixedUpdate()
    {
        if (GlobalVariables.FreeCam)
        {
            newtrans.x = player.transform.position.x + offset.x;
            newtrans.y = player.transform.position.y + offset.y;
            transform.position = newtrans;
        }

        //Надо разобрать поччему не работает сразу , а только после движения мышкой
        //Теперь дергается делает сдвиг и возвращается на прежнюю позицию сразу
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        //Слишком резко
        if (Input.GetKey(KeyCode.Q))
            transform.rotation = Quaternion.Euler(0f, 0f, 100f);
        else if (Input.GetKey(KeyCode.E))
            transform.rotation = Quaternion.Euler(0f, 0f, -100f);
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
        if (Input.GetKey(KeyCode.Q))
            //transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f , 100f * Time.deltaTime);
        //else if (Input.GetKey(KeyCode.E))
        ////transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
        //transform.rotation = Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
    }
}
