using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private Vector3 target;
    //private Rigidbody2D rb;
        
    void Start()
    {
        target = transform.position;
        Debug.Log("Start");
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            GlobalVariables.FreeCam = true;
        }
        //как узнать что у нас колизия ?
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (Input.GetMouseButtonUp(1))
        {
            GlobalVariables.FreeCam = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bum");
        target = transform.position;
        //rb.velocity = Vector3.zero;
        //transform.position = Vector3.zero;
    }
    
}
