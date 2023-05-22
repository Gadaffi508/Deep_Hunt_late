using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour
{
    public BoatDataBase boatdbs;
    public Text nameText;
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

    public void NextOption()
    {
        selectOption++;

        if (selectOption >= boatdbs.boatCount)
        {
            selectOption = 0;
        }
        UpdateBoat(selectOption);
        Save();
    }

    public void BackOption()
    {
        selectOption--;

        if (selectOption < 0)
        {
            selectOption = boatdbs.boatCount - 1;
        }
        UpdateBoat(selectOption);
        Save();
    }

    private void UpdateBoat(int selectedOption)
    {
        BoatChoose boatChoose = boatdbs.GetBoat(selectedOption);
        artworkSprite.sprite = boatChoose.boatSprite;
        nameText.text = boatChoose.boatName;
    }

    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectOption", selectOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
