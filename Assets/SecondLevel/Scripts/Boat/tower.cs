using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tower : BoatTowerController
{
    public GameObject TowerPanel;

    private void Start()
    {
        TowerPanel = GameObject.FindGameObjectWithTag("PanelTwo").gameObject;
    }

    public override void CloseTower()
    {
        if (TowerPanel != null)
        {
            TowerPanel.transform.DOMoveY(1500, 1);
            TowerPanel.GetComponent<TowerButtonController>().SetTower(null);
        }
    }

    public override void TowerBuilt()
    {
        if (TowerPanel != null)
        {
            TowerPanel.transform.DOMoveY(950,1);
            TowerPanel.GetComponent<TowerButtonController>().SetTower(this);
        }
    }

    public GameObject TowerBuilt(GameObject _Tower)
    {
        CloseTower();
        Destroy(gameObject); 
        return Instantiate(_Tower,transform.position,Quaternion.identity);
    }
}
