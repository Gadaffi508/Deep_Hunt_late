using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScripts : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float rowSpeed = 5f;

    private Transform target;

    private void Start()
    {
        Destroy(gameObject,3f);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void FixedUpdate()
    {
        if(!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * rowSpeed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        
    }
}
