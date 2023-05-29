using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;


    [Header("Attribute")]
    [SerializeField] public float moveSpeed = 3f;


    public float prevMoveSpeed;
    private EnemyHealtAndAttackScripts script;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<EnemyHealtAndAttackScripts>();
    }

    void Start()
    {
        Physics2D.queriesStartInColliders = true;
        prevMoveSpeed = moveSpeed;
        if (transform.position.x > target.position.x)
        {
            moveSpeed *= -1;
            transform.localScale = new Vector3(1,1,1f);
        }
        else
        {
            moveSpeed *= 1;
            transform.localScale = new Vector3(-1, 1, 1f);
        }
    }
    private void Update()
    {

        prevMoveSpeed = moveSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime,rb.velocity.y);
    }

   
}
