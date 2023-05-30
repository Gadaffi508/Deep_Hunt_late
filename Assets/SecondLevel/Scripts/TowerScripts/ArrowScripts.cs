using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScripts : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;

    [Header("Attributes")]
    public float rowSpeed = 5f;
    public int Damage;
    public string Name;

    private Transform target;
    private EnemyHealtAndAttackScripts script;

    private void Start()
    {
        //script = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealtAndAttackScripts>();

        Destroy(gameObject, 1.5f);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void FixedUpdate()
    {
        if (target)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, rowSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            script.TakeDamage(script.EnemyAttack);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            script.TakeDamage(script.EnemyAttack);
            Destroy(gameObject);
        }
    }
}
