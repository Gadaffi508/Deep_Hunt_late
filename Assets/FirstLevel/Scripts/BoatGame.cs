using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatGame : MonoBehaviour
{
    public BoatDataBase boatdbs;

    public SpriteRenderer artworkSprite;

    private int selectOption = 0;

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

    private void UpdateBoat(int selectedOption)
    {
        BoatChoose boatChoose = boatdbs.GetBoat(selectedOption);
        artworkSprite.sprite = boatChoose.boatSprite;
    }

    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOption");
    }
}
