using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiBullet : Projectile
{
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
}