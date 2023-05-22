using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArcherTower : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Transform ArcherRotation;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] public float bps = 1f;//bullet per second

    private Transform target;
    private float timeUntilFire;
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateArcherTarget();
        if (!CheckTargetInRange())
        {
            target = null;
            
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f /bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
       
    }

    private void Shoot()
    {
        GameObject row = Instantiate(bulletPrefab,firingPoint.position,Quaternion.identity);
        ArrowScripts arrowScripts = row.GetComponent<ArrowScripts>();
        arrowScripts.SetTarget(target);

    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,attackRange,(Vector2)transform.position,0f,enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetInRange() {
        return Vector2.Distance(target.position, transform.position) <= attackRange;
    }
    private void RotateArcherTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        ArcherRotation.rotation = Quaternion.RotateTowards(ArcherRotation.rotation,targetRotation,rotationSpeed * Time.deltaTime);
        //ArcherRotation.rotation = targetRotation;
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position,transform.forward,attackRange);
    }
}
