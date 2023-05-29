using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuilTower : MonoBehaviour
{
    public GameObject towerP;
    public SpriteRenderer TowerRenderer;
    public Image TowerSprite;

    //Events
    public event Action<GameObject> OnButtonClick;

    //private variables
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);

        //TowerSprite.sprite = TowerRenderer.sprite;
    }
    //Mouse on click
    public void OnClick()
    {
        if (OnButtonClick != null)
            OnButtonClick(towerP);
    }
}
