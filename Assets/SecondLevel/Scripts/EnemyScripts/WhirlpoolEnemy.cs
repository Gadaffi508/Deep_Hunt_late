using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WhirlpoolEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask shipLayer;
    [SerializeField] private GameObject Ship;


    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float Force;
    [SerializeField] private float Speed;

    private Rigidbody2D rb;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > target.position.x)
        {
            rb.velocity = new Vector2(-Speed * Time.deltaTime, rb.velocity.y);
        }
        else if (transform.position.x < target.position.x)
        {
            rb.velocity = new Vector2(Speed * Time.deltaTime, rb.velocity.y);
        }
        RaycastHit2D hits = Physics2D.CircleCast(transform.position, attackRange, (Vector2)transform.position, 0f, shipLayer);

        if (hits)
        {
            Whirlpool();
            Speed = 0;
        }
        else 
        {
            
            Speed = 250;
        }
    }


    private void Whirlpool()
    {
        if (transform.position.x > target.position.x)
        {
            Ship.transform.Translate(Force,0,0);
        }
        else if (transform.position.x < target.position.x)
        {
            Ship.transform.Translate(-Force, 0, 0);
        }
    }

  
}
