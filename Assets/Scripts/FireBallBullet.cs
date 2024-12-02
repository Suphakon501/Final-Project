using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBullet : Projectile
{
    public float acceleration = 2f;
    public float currentSpeed;

    protected override void SetDirection()
    {
        if (shooterTransform.localScale.x < 0)
        {
            rb.velocity = new Vector2(-speed, 0); // ถ้าผู้เล่นหันไปทางซ้าย
        }
        else
        {
            rb.velocity = new Vector2(speed, 0); // ถ้าผู้เล่นหันไปทางขวา
        }
    }
    protected override void Start()
    {
        //  โค้ดอื่นๆ
        base.Start();
        currentSpeed = speed;
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("is target null " + (targetTransform == null));
    }
    private void Update()
    {
        currentSpeed += acceleration * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, currentSpeed * Time.deltaTime);
        Debug.Log("has target");
    }
}