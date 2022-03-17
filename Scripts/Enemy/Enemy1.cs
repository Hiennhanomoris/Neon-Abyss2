using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAbstract
{
    // private bool isMovingRight;
    // private RaycastHit2D groundInfor;
    // [SerializeField] Transform groundDetection;

    // public override void Start()
    // {
    //     base.Start();
    //     isMovingRight = true;
    // }

    // private void Update() 
    // {
    //     this.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

    //     groundInfor = Physics2D.Raycast(groundDetection.position, Vector2.down, moveDistance);
    //     if(groundInfor.collider == false)
    //     {
    //         if(isMovingRight == true)
    //         {
    //             transform.eulerAngles = new Vector3(0f, -180f, 0f);
    //             isMovingRight = false;
    //         }
    //         else 
    //         {
    //             transform.eulerAngles = new Vector3(0, 0, 0);
    //             isMovingRight = true;
    //         }
    //     }
    // }


    [SerializeField] private float xMin, xMax;
    private int dir = 1;
    private void FixedUpdate() 
    {
        Moving();
    }

    private void Moving()
    {
        if(transform.position.x < xMin)
        {
            dir *= -1;
            FlipToRight();
        }
        if(transform.position.x > xMax)
        {
            dir *= -1;
            FlipToLeft();
        }
        enemyRb.velocity = new Vector2(moveSpeed * dir, enemyRb.velocity.y);
    }

    private void FlipToLeft()
    {
        Vector3 temp = transform.localScale;
        temp.x = -1f;
        transform.localScale = temp;
    }
    private void FlipToRight()
    {
        Vector3 temp = transform.localScale;
        temp.x = 1f;
        transform.localScale = temp;
    }
}
