using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    private Transform bulletPos;
    public float speed;
    private float ScreenOffset = 5.5f;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletPos = GetComponent<Transform>();

        BulletMovement();
    }
    void Update()
    {
        BulletDestroyer();
    }
    private void BulletMovement()
    {
        if (bulletRb)
        {
            bulletRb.AddForce(new Vector2(0, speed * Time.deltaTime), ForceMode2D.Impulse);
            bulletRb.gravityScale = 0;
        }
    }
    private void BulletDestroyer()
    {
        if (bulletPos.transform.position.y >= ScreenOffset)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
