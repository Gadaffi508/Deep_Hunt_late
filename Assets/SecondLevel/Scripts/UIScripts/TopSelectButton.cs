using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopSelectButton : MonoBehaviour, IPointerEnterHandler
{
    public BulletScriptable bullet;
    public Image BulletSprite;

    //Events
    public event Action<BulletScriptable> OnButtonClick;
    public event Action<BulletScriptable> OnButtonEnter;

    //private variables
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);

        BulletSprite.sprite = bullet.spt.sprite;
    }


    //Mouse on Button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnButtonEnter != null)
            OnButtonEnter.Invoke(bullet);
    }
    //Mouse on click
    public void OnClick()
    {
        if (OnButtonClick != null)
            OnButtonClick(bullet);
    }
}
