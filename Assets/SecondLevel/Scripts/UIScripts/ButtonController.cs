using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Text ButtonName;
    public Text GunSpeed;
    public Text GunDamage;
    public Text GunName;

    [SerializeField] TopSelectButton[] allButtons;

    private ArcherTower currentTower;
    public ArcherTower SetTower(ArcherTower tower) => currentTower = tower;

    //Event Implements
    private void OnEnable()
    {
        foreach(var button in allButtons)
        {
            button.OnButtonEnter += ButtonEnter;
            button.OnButtonClick += ButtonClick;
        }
    }
    private void OnDisable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonEnter -= ButtonEnter;
            button.OnButtonClick -= ButtonClick;
        }
    }

    //Event Methods
    private void ButtonEnter(BulletScriptable bullet)
    {
        GunSpeed.text = "Gun Speed : " + bullet.bulletCurrent.rowSpeed.ToString();
        GunDamage.text = "Gun Damage : " + bullet.bulletCurrent.Damage.ToString();
        GunName.text = "Gun Name : " + bullet.bulletCurrent.Name;
    }
    private void ButtonClick(BulletScriptable bullet)
    {
        if(currentTower != null)
        {
           currentTower.Bullet = bullet;
        }
    }
}
