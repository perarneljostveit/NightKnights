using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : MonoBehaviour
{

    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWith;
    


    void Start()
    {
        myTrans = transform;
        myBody = GetComponent<Rigidbody2D>();
        myWith = GetComponent<SpriteRenderer>().bounds.extents.x;
    }
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWith;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        if(!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
    void Update()
    {
       
      
    }

    void lookAtPlayer()
    {
        
    }
}