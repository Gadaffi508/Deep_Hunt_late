using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    public float OverlapRadius = 2.0f;

    public Transform nearestEnemy;
    private int enemyLayer;

    public Transform rotateFire;

    public BulletScriptable Bullet;
    public Transform FirePos;
    public Transform BulletRotate;

    public float nextPrefab;

    BoatController boat;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        boat = GameObject.FindGameObjectWithTag("Ship").gameObject.GetComponent<BoatController>();
        
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

            if (nextPrefab >= 0.40f)
            {
                ProjectTileFire(enemy);
                nextPrefab = 0;

            }

            Facing(enemy);
            

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, OverlapRadius);
    }

    public void ProjectTileFire(Transform target)
    {
        GameObject row = Bullet.InstateBullet(FirePos, BulletRotate);
        ArrowScripts arrowScripts = row.GetComponent<ArrowScripts>();
        arrowScripts.SetTarget(target);

    }
    public void Facing(Transform enemy)
    {
        Vector3 barrelPosition = rotateFire.transform.position;

        Vector3 targetDirection = enemy.position - barrelPosition;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        rotateFire.rotation = Quaternion.Euler(0f, 0f, targetAngle);

        if (targetAngle < -90 || targetAngle > 90)
        {

            if (rotateFire.transform.eulerAngles.y == 0)
            {
                rotateFire.transform.localRotation = Quaternion.Euler(180, 0, -targetAngle);
            }
            else if (rotateFire.transform.eulerAngles.y == 180)
            {
                rotateFire.transform.localRotation = Quaternion.Euler(180, 180, -targetAngle);
            }

        }

        if (boat.isFacingRight)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
