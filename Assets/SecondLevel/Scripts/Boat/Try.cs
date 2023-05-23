using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Try : BoatTowerController
{
    [Header("Text")]
    public GameObject gunİnformation;
    public Text Strengh;
    public Text Speed;

    [Space]
    [Header("Controller")]
    public float _Speed = 5;
    public float _Strengh = 30;

    private void Start()
    {
        gunİnformation = GameObject.FindGameObjectWithTag("Panel").gameObject.GetComponent<RectTransform>().gameObject;
        Speed = GameObject.FindGameObjectWithTag("Text1").gameObject.GetComponent<Text>();
        Strengh = GameObject.FindGameObjectWithTag("Text2").gameObject.GetComponent<Text>();

    }

    public override void CloseTower()
    {
        gunİnformation.transform.DOMoveY(1500, 1);
    }

    public override void TowerBuilt()
    {
        if (gunİnformation != null)
        {
            gunİnformation.transform.DOMoveY(900, 1);
            Speed.text = "Gun Speed : " + _Speed;
            Strengh.text = "Gun Strengh : " + _Strengh;

        }
    }
}

