using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Goldtext;
    public Text HealthText;

    public int Gold;
    public int Health;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        HealthText.text = "Health : " + Health.ToString();
        Goldtext.text = "Gold : " + Gold.ToString();
    }
}
