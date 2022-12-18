using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private Vector3 target;
    private Vector2 destinct;
    private bool playerGo = false;
    private Rigidbody2D rb;

    void Start()
    {
        target = transform.position;
        destinct.Set(target.x, target.y);
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = transform.position.z;
            GlobalVariables.FreeCam = true;
            //destinct.Set(target.x, target.y);
            destinct = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerGo = true;

        }
        //как узнать что у нас колизия ?
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (playerGo)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, destinct, speed * Time.deltaTime));
            if (Vector2.Distance(transform.position, destinct) < 0.01)
            {
                playerGo = false;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            GlobalVariables.FreeCam = false;
        }
    }

    private void FixedUpdate()
    {
        //rb.AddForce(destinct);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bum");
        ////target = transform.position;
        //rb.velocity = Vector3.zero;
        //transform.position = Vector3.zero;
    }
    
}
