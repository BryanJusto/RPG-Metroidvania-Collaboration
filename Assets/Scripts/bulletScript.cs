using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;

    public LayerMask whatIsEnemy;
    public LayerMask whatIsCrit;
    public int damage;
    public BulletType currentBullet;

    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = GameObject.Find("player").GetComponent<playerControl>().facingRight;
    }

    // Update is called once per frame
    void Update()
    {
        if(facingRight)
            rb.velocity = new Vector2(velX, velY);
        else
            rb.velocity = new Vector2(-velX, velY);

        //For Continous projectiles
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<CircleCollider2D>().radius, whatIsEnemy);
        Collider2D[] enemiesToCrit = Physics2D.OverlapCircleAll(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<CircleCollider2D>().radius, whatIsCrit);
        
        if(enemiesToCrit.Length > 0)
        {
            //Currently, critBox is a child of parent, so have to access parent's health to deal damage
            for (int i = 0; i < enemiesToCrit.Length; i++)
            {
                enemiesToCrit[i].GetComponent<Transform>().parent.GetComponent<enemy>().takeDamage(damage * 3);
                enemiesToDamage[i].GetComponent<enemy>().elementEffect(gameObject.GetComponent<bulletScript>().currentBullet);
                //Makes projectiles stop on contact
                Destroy(gameObject);
            }
        }

        //Normal damage
        else if(enemiesToDamage.Length > 0)
        {
            for (int j = 0; j < enemiesToDamage.Length; j++)
            {
                enemiesToDamage[j].GetComponent<enemy>().takeDamage(damage);
                enemiesToDamage[j].GetComponent<enemy>().elementEffect(gameObject.GetComponent<bulletScript>().currentBullet);
                Destroy(gameObject);
            }

        }

        Destroy(gameObject, 2f);
    }
}