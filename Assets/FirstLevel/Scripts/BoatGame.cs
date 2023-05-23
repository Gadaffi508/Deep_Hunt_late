using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatGame : MonoBehaviour
{
    public BoatDataBase boatdbs;

    public GameObject artworkObject;

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
        Instantiate(artworkObject,transform.position,Quaternion.identity);
    }

    private void UpdateBoat(int selectedOption)
    {
        BoatChoose boatChoose = boatdbs.GetBoat(selectedOption);
        artworkObject = boatChoose.boat;
    }

    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOption");
    }
}
