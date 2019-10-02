using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyAi : MonoBehaviour
{
    
    public float speed;
    public float height;
    public Transform originPoint;
    public float range;
    public Transform target;
    private Vector2 dir = new Vector2(1, 0); //because facing left first (?)
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
//        rb.velocity=new Vector2(speed, rb.velocity.y);
        Debug.DrawRay(originPoint.position, (dir * range));
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        if (hit == true)
        {
            Debug.Log("true");
            if (hit.collider.CompareTag("ground"))
            {
                //flip him and don't forget to flip his raycast as well
            }
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit");
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, height), new Vector2(target.position.x, height), speed * Time.deltaTime);
            }
        }
    }
}
