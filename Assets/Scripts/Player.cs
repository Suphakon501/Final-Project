using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;
    private float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            KunaiBullet kunai = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity).GetComponent<KunaiBullet>(); ;
            kunai.SetShooter(this.transform);
            kunai.SetTargetTag();
            shootCounter = shootTime;
        }
       

        shootCounter -= Time.deltaTime;
    }
}