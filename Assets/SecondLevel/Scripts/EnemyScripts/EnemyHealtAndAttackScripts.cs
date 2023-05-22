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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(EnemyAttack);
        }
       
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
      
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Bu adma öldü");
        }
    }
}
