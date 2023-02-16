using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class BFMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector3 dest = Vector3.zero;
    private int indexInMoveList;
    [SerializeField]
    //private GameObject camera;
    private bool turnUnit = false;
    private bool moveUnit = true;
    [SerializeField]
    private int moveSteps = 3;
    static private GameObject[] UnitProperties;
    void Start()
    {
        dest = transform.position;
        indexInMoveList = BFGlobalVariables.AddNew(gameObject);
        UnitProperties = GameObject.FindGameObjectsWithTag("UnitProperties");
        SetStepsRemain();
    }

    private void FixedUpdate()
    {
        Vector3 p = Vector3.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody>().MovePosition(p);
    }

    private void Update()
    {
        //Are i move ?
        if (indexInMoveList == BFGlobalVariables.ListIndex)
        {
            //Тут ставим свой цвет
            //GameObject Parent = GameObject.Find("ParentObject");
            //for (int x = 0; x > Parent.transform.childCount; x++) ;
            //{
            //    Parent.transform.GetChild(x).GetComponent<Renderer>().material.color = Color.red;
            //}
            //foreach (var item in UnitProperties)
            //{
            //    item.GetComponent<Font>();
            //    //gameObject.GetComponent<Renderer>().material.color = Color.red;
            //}
                       
            if (turnUnit)
            {
                BFGlobalVariables.Next();
                turnUnit = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                    turnUnit = true;
            }
            MoveUnit(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            SetStepsRemain();
            if (Input.GetKeyUp(KeyCode.W))
                OneStep();
            if (Input.GetKeyUp(KeyCode.S))
                OneStep();
            if (Input.GetKeyUp(KeyCode.A))
                OneStep();
            if (Input.GetKeyUp(KeyCode.D))
                OneStep();           
        }

    }

    void MoveUnit(float x, float y)
    {
        if (y > 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.forward;
                moveUnit = false;
            }
        if (y < 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.back;
                moveUnit = false;
            }
        if (x < 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.left;
                moveUnit = false;
            }
        if (x > 0)
            if (moveUnit)
            {
                dest = (Vector3)transform.position + Vector3.right;
                moveUnit = false;
            }
    }

    public void SetStepsRemain()
    {
        foreach (var item in UnitProperties)
        {
            var text = item.GetComponent<Text>();
            text.text = moveSteps.ToString();
            text.color = gameObject.GetComponent<Renderer>().material.color;
            //Debug.Log(text.text);
        }
    }

    public void OneStep()
    {
        if (moveSteps != 0)
        {
            moveUnit = true;
            moveSteps -= 1;
            //SetStepsRemain();
        }
    }
}
