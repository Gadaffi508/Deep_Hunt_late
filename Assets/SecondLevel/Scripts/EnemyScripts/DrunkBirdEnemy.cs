using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkBirdEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;

    [Header("Attribute")]
    [SerializeField] private float AttackDistance = 15f;
    [SerializeField] private float MoveSpeed = 75f;
    [SerializeField] private float Force = 100f;

    private float randomMove;
    private Vector2 shipPosition;
    private Vector2 tansformPosition;
    private float Distance;
    private EnemyHealtAndAttackScripts script;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<EnemyHealtAndAttackScripts>();
    }

    
    void Update()
    {

        Move();
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,AttackDistance);

        if (hit.collider == null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }
        else if (hit.collider.CompareTag("Ship"))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Invoke("Attack", 1f);
            MoveSpeed = 0f;
        }
        else if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
    }
    //public float speed = 0.2f;
    //public float amplitude = 0.5f;
    //public float frequency = 0.1f;
    
    private void Move()
    {

       

        //Vector3 direction = (target.position - transform.position).normalized;
        //transform.position += direction * speed * Time.deltaTime;

        //float y = Mathf.Sin(Time.time * frequency) * amplitude;
        //transform.position += new Vector3(0, y, 0);

        Distance = Vector2.Distance(transform.position, tansformPosition);
        if (Distance <= 0)
        {
            randomMove = Random.Range(1f, 4f);
        }
        tansformPosition = new Vector2(transform.position.x, randomMove);
        shipPosition = new Vector2(target.position.x, randomMove);
        transform.position = Vector2.MoveTowards(transform.position, shipPosition, MoveSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, tansformPosition, MoveSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        rb.velocity = new Vector2(rb.velocity.x,-Force * Time.deltaTime);
    }
  
  
}
