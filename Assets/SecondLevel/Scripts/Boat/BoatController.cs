using System.Collections;
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

    [Space]
    [Header("Data")]
    public BoatDataBase boatdbs;
    public Collider2D boatCollider;
    public GameObject artworkObject;
    public SpriteRenderer artworkSprite;

    private int selectOption = 0;


    private void Awake()
    {
        current = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectOption = 0;
        }
        else
        {
            Load();
        }

        UpdateBoat(selectOption);
    }

    void FixedUpdate()
    {
        //healthText.text = "Boat Health :" + Health.ToString();
        // GoldText.text = "Gold : " + gold.ToString();

        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);

        if (horizontal > 0)
        {
            transform.localScale = new Vector2(direction, 1);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(direction*-1, 1);
        }
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
    }

    private void UpdateBoat(int selectedOption)
    {
        BoatChoose boatChoose = boatdbs.GetBoat(selectedOption);
        artworkObject = boatChoose.boat;
        artworkSprite.sprite = boatChoose.boatRender;
        direction = boatChoose.direction;
        boatCollider = boatChoose.boatCollider;
    }

    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOption");
    }

}
