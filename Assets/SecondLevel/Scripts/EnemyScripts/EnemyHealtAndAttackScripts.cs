using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtAndAttackScripts : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] public float EnemyHealth = 100;
    [SerializeField] public float EnemyAttack = 15;

    private float currentHealth;
    void Start()
    {
        currentHealth = EnemyHealth;
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
      
        if (currentHealth <= 0)
        {
            BoatController.current.gold += 20;
            Destroy(gameObject,0.5f);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(20);
        }
    }
}
