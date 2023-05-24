using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ArcherTower : MonoBehaviour
{
    public float OverlapRadius = 2.0f;

    public Transform nearestEnemy;
    private int enemyLayer;

    public GameObject Bullet;
    public Transform FirePos;

    public float nextPrefab;

    public float sagaDonmeAcisi = 20f;
    public float solaDonmeAcisi = 120f;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");

    }

    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, OverlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider2D collider in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
            }
        }

        nextPrefab += Time.deltaTime;
        if (nearestEnemy != null)
        {
            Transform enemy = nearestEnemy.GetComponent<Transform>();
            
            if (nextPrefab >= 1.5f)
            {
                ProjectTileFire(enemy);
                nextPrefab = 0;

            }

            Vector3 directionToCircle = nearestEnemy.position - transform.position;
            float angle = Mathf.Atan2(directionToCircle.y, directionToCircle.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, OverlapRadius);
    }
    public void ProjectTileFire(Transform target)
    {
        GameObject row = Instantiate(Bullet, FirePos.position, FirePos.rotation);
        ArrowScripts arrowScripts = row.GetComponent<ArrowScripts>();
        arrowScripts.SetTarget(target);

    }
}
