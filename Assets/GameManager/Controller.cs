using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int jump; 
    public float speed;
    float x, sx;
    Animator am;
    Rigidbody2D rb;

    // Start คือฟังก์ชันที่เรียกใช้ก่อนการอัพเดตครั้งแรก
    void Start()
    {
        jump = 0;
        am = GetComponent<Animator>(); // แก้ไขให้ระบุประเภทคอมโพเนนต์
        rb = GetComponent<Rigidbody2D>(); // แก้ไขให้ระบุประเภทคอมโพเนนต์
        sx = transform.localScale.x;
    }

    // Update คือฟังก์ชันที่เรียกใช้ในทุกเฟรม
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        am.SetFloat("speed", Mathf.Abs(x)); // ใช้ Mathf.Abs สำหรับค่าสัมบูรณ์
        if(Input.GetButtonDown("Jump") && jump <4)

        if (Input.GetButtonDown("Jump"))
        {
                jump++;
            am.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (x > 0) // แก้ไขการเปรียบเทียบให้ถูกต้อง
        {
            transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
        }
        else if (x < 0) // แก้ไขให้เป็น else if
        {
            transform.localScale = new Vector3(-sx, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        am.SetBool("jump", false);
        jump= 0;
    }

    float Abs(float x)
    {
        return x >= 0f ? x : -x; // แก้ไขการเปรียบเทียบให้ถูกต้อง
    }
}
