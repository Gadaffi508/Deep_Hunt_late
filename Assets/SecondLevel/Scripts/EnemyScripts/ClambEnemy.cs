using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClambEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;

    [Header("Attribute")]
    [SerializeField] private float speed;
    [SerializeField] private float maxHeight = -5.5f;
    [Space]
    [SerializeField] private int damage;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    
    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        if(transform.position.y < maxHeight)
        {
            rb.velocity = -Vector2.down * speed;
        }
    }

    public void OnTrigger(BoatController boat)
    {
        //Set Damage
        boat.DamageSlow(damage);

        //SetParent
        transform.SetParent(boat.gameObject.transform);

        //Set Static
        rb.bodyType = RigidbodyType2D.Kinematic;
        speed = 0;

        Destroy(this);
    }
}
