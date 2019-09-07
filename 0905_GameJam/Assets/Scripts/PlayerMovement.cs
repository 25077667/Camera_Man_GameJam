using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    //public GameObject[] ground;
    Vector3 targetPos;
    bool canMove;
    [SerializeField]
    LayerMask mask;
    bool moving=false;
    void Start()
    {
        //ground = GameObject.FindGameObjectsWithTag("Ground");
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(moving)
            return;
        if(Boss.Instance.stageClear)
            return;







        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos = transform.position + Vector3.forward;
            canMove = MoveCheck(targetPos);
            if(canMove)
            {
                transform.DOMove(transform.position+Vector3.forward*0.5f + Vector3.up*0.45f,0.05f).OnComplete(()=> transform.DOMove(transform.position+Vector3.forward*0.5f-Vector3.up*0.45f,0.05f).OnComplete(()=>moving = false));
                transform.DORotate(Vector3.zero,0.1f);
            }
                
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos = transform.position - Vector3.forward;
            canMove = MoveCheck(targetPos);
            if(canMove)
            {
                transform.DOMove(transform.position-Vector3.forward*0.5f + Vector3.up*0.45f,0.05f).OnComplete(()=>transform.DOMove(transform.position-Vector3.forward*0.5f - Vector3.up*0.45f,0.05f).OnComplete(()=>moving = false));
                transform.DORotate(Vector3.up*180,0.1f);
            }
                
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPos = transform.position - Vector3.right;
            canMove = MoveCheck(targetPos);
            if(canMove)
            {
                transform.DOMove(transform.position-Vector3.right*0.5f +Vector3.up*0.45f,0.05f).OnComplete(()=>transform.DOMove(transform.position-Vector3.right*0.5f-Vector3.up*0.45f,0.05f).OnComplete(()=>moving = false));
                transform.DORotate(Vector3.up*270,0.1f);
            }
               
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPos = transform.position + Vector3.right;
            canMove = MoveCheck(targetPos);
            if(canMove)
            {
                transform.DOMove(transform.position+Vector3.right*0.5f + Vector3.up*0.45f,0.05f).OnComplete(()=>transform.DOMove(transform.position+Vector3.right*0.5f - Vector3.up*0.45f,0.05f).OnComplete(()=>moving = false));
                transform.DORotate(Vector3.up*90,0.1f);
            }
                
        }
    }

    bool MoveCheck(Vector3 pos)
    {
        if(Physics.Raycast(pos,Vector3.down,2,mask))
        {
            moving = true;
            return true;
        }
        else
            return false;
    }
}
