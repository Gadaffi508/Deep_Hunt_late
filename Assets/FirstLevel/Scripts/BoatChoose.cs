using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoatChoose
{
    public string boatName;
    public GameObject boat;
    public Sprite boatRender;
    public Collider2D boatCollider;
    public int direction;
}
