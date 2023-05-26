using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Try : BoatTowerController
{
    [Header("Text")]
    public GameObject gun›nformation;

    [Space]
    [Header("Controller")]
    public float _Speed = 5;
    public float _Strengh = 30;

    private void Start()
    {
        gun›nformation = GameObject.FindGameObjectWithTag("Panel").gameObject.GetComponent<RectTransform>().gameObject;
    }

    public override void CloseTower()
    {
        gun›nformation.transform.DOMoveY(1500, 1);
    }

    public override void TowerBuilt()
    {
        if (gun›nformation != null)
        {
            gun›nformation.transform.DOMoveY(900, 1);

        }
    }
}

