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
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }

    private void LateUpdate()
    {
        //if (!Input.anyKey||Input.anyKeyDown)
        if (!Input.anyKey)
        {
            newtrans.x = player.transform.position.x + offset.x;
            newtrans.y = player.transform.position.y + offset.y;
            transform.position = newtrans;
        }
    }

}
