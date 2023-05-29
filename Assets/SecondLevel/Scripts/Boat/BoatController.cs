using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatController : MonoBehaviour
{
    public static BoatController current;
    [Header("Controller")]
    [Space]
    public Rigidbody2D rb;
    public float speed;
    public int direction;
    public bool isFacingRight = true;

    public int Health;
    public int damage;


    [Space]
    [Header("UI")]
    [Space]
    public Text healthText;
    public Text GoldText;

    [Space]
    [Header("Gold")]
    public  int gold;


    private void Awake()
    {
        GoldText = GameObject.FindGameObjectWithTag("Gold").gameObject.GetComponent<Text>();
        healthText = GameObject.FindGameObjectWithTag("healthText").gameObject.GetComponent<Text>();
        current = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        healthText.text = "Boat Health :" + Health.ToString();
        GoldText.text = "Gold : " + gold.ToString();

        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        } transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    public void Regeneraiton()
    {
        if (Health < 100)
        {
            Health += 5;
        }
        else
        {
            Health = 100;
        }
    }
    IEnumerator StartHealth()
    {
       yield return new WaitForSeconds(2);
        Regeneraiton();
        StartCoroutine(StartHealth());
    }
    IEnumerator DamageSlowTýme()
    {
        yield return new WaitForSeconds(2);
        DamageSlow(damage);
        StartCoroutine(DamageSlowTýme());

    }
    public void DamageSlow(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            //Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("kuleA"))
        {
            other.transform.parent = transform;
            Destroy(other.rigidbody);
        }
        if (other.gameObject.CompareTag("EnemyArrow"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyArrow"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -direction;
        transform.localScale = scale;
    }

}
