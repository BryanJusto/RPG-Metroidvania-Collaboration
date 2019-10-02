using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private Rigidbody2D rb;
    public int speed;

    private float elementTimer = 1000;
    private float fireDamage = 1;
    private float freezeSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);


        rb.velocity = new Vector2(Mathf.Sin(Time.time * speed), 0);
    }

    public void elementEffect(BulletType bulletType)
    {
        switch(bulletType)
        {
            case BulletType.fireBullet:
                StartCoroutine(Burn());
                break;
            case BulletType.iceBullet:
                StartCoroutine(Freeze());
                break;
            case BulletType.none:
                return;
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    IEnumerator Burn()
    {
        for (int i = 0; i < 2; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("Fire Damage " + i);
            takeDamage((int)fireDamage);
            yield return new WaitForSeconds(2);
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Freeze()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        speed -= (int)freezeSpeed;
        Debug.Log("Start Freeze");
        yield return new WaitForSeconds(3);
        Debug.Log("Stop Freeze");
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        speed += (int)freezeSpeed;
    }
}