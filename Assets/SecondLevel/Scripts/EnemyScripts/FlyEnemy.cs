using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private Transform ship;

    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float bps = 1f;//bullet per second

    private Transform target;
    private float timeUntilFire;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
    private void Start()
    {
        enemyMove = GetComponent<EnemyMove>();

        Physics2D.queriesStartInColliders = true;
    }
    void Update()
    {
        if (transform.position.x > ship.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < ship.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (target == null)
        {
            FindTarget();
            return;
        }
       
        if (!CheckTargetInRange())
        {
            target = null;
            enemyMove.moveSpeed = enemyMove.prevMoveSpeed;
        }
        else
        {
            enemyMove.moveSpeed = 0f;
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }

    }
    private void Shoot()
    {
        GameObject row = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        ArrowScripts arrowScripts = row.GetComponent<ArrowScripts>();
        arrowScripts.SetTarget(target);

    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= attackRange;
    }
  
   
}


