using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : BoatTowerController
{
    public GameObject Tower;

    public override void CloseTower()
    {
       
    }

    public override void TowerBuilt()
    {
        Instantiate(Tower,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
