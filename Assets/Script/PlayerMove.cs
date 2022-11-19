using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private Vector3 target;
    [SerializeField]
    private GameObject maincamera;


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
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //maincamera.transform.position = new Vector3(transform.position.x, transform.position.y);
        //maincamera.transform.position = Vector3.MoveTowards(maincamera.transform.position, target + maincamera.transform.position.z , speed * Time.deltaTime);
    }
}
