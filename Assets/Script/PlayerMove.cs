using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private Vector3 target;
    

    void Start()
    {
        target = transform.position;
    }

    private void Update()
    {
            if (Input.GetMouseButtonDown(1))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                GlobalVariables.FreeCam = true;
            }
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    
        if (Input.GetMouseButtonUp(1))
            {
                GlobalVariables.FreeCam = false;
            }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "EndMapLeft")
    //        transform.position = transform.position + Vector3.right;
    //}
}
