using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Try : BoatTowerController
{
    private ArcherTower tower;

    [Header("Text")]
    public GameObject gunInfoPanel;

    private void Start()
    {
        tower = transform.GetComponentInParent<ArcherTower>();
        gunInfoPanel = GameObject.FindGameObjectWithTag("Panel").gameObject;
    }

    public override void CloseTower()
    {
        gunInfoPanel.transform.DOMoveY(1500, 1);
    }

    public override void TowerBuilt()
    {
        if (gunInfoPanel != null)
        {
            gunInfoPanel.transform.DOMoveY(900, 1);
            gunInfoPanel.GetComponentInChildren<ButtonController>().SetTower(tower);
        }
    }
}

