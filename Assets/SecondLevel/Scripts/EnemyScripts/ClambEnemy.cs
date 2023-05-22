using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClambEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;

    [Header("Attribute")]
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            speed = 0;
            //transform.position = new Vector2(target.position.x,transform.position.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        //if (collision.gameObject.CompareTag("Ship"))
        //{
        //    speed = 0;
        //    collision.transform.parent = transform;

        //}
        rb.velocity = new Vector2(rb.velocity.x, speed * Time.deltaTime);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            speed = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }


}
