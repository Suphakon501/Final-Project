using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Character
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1;
    public float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFormPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFormPlayer < lineOfSite && distanceFormPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFormPlayer < shootingRange && nextFireTime < Time.time)
        {
            GameObject fireballInstance = Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            FireBallBullet fireball = fireballInstance.GetComponent<FireBallBullet>();
            fireball.SetShooter(this.transform);
            fireball.SetTargetTag();
            nextFireTime = Time.time + fireRate;
        }
        // เช็คทิศทางเพื่อหันหน้าศัตรู
        if (player.position.x < transform.position.x)
        {
            // หันหน้าศัตรูไปทางซ้าย
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // หันหน้าศัตรูไปทางขวา
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}