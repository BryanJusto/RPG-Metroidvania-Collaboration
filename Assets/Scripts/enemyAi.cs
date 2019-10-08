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
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){

    }

    // Update is called once per frame
    void FixedUpdate(){


        LayerMask hu = LayerMask.GetMask("playerLayer");
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, Vector2.right, 10, hu);
        Debug.DrawRay(originPoint.position, (Vector2.right * 10));
        if (hit)
        {
            Debug.Log("hit");
            if(Vector3.Distance(transform.position,target.position) > 1){
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            }
        }

    }
}
