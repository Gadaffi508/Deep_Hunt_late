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
        if(!target) Destroy(gameObject);
        transform.position = Vector2.MoveTowards(transform.position, target.position, rowSpeed * Time.deltaTime);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
