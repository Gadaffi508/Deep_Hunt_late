using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Try : BoatTowerController
{
    [Header("Text")]
    public GameObject gunİnformation;

    [Space]
    [Header("Controller")]
    public float _Speed = 5;
    public float _Strengh = 30;

    private void Start()
    {
        gunİnformation = GameObject.FindGameObjectWithTag("Panel").gameObject.GetComponent<RectTransform>().gameObject;
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

        }
    }
}

