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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
      
        if (currentHealth <= 0)
        {
            GameManager.Instance.Gold += 20;
            Destroy(gameObject);

        }
    }
 
}
