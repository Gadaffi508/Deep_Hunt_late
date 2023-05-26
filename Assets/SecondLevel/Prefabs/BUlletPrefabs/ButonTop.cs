using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButonTop : MonoBehaviour, IPointerEnterHandler
{
    public BulletScriptable Bullet;
    public Text ButtonName;
    public Text GunSpeed;
    public Text GunDamage;
    public Text GunName;

    public Image thisButton;

    private void Start()
    {
        thisButton.sprite = Bullet.spt.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Bullet.TextBullet(GunSpeed, GunDamage, GunName);
    }
}
