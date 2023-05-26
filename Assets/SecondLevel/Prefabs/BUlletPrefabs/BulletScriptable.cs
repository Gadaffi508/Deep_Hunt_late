using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class BulletScriptable : ScriptableObject
{
    public GameObject bullet;
    public SpriteRenderer spt;
    public ArrowScripts bulletCurrent;

    public GameObject InstateBullet(Transform bulletPos)
    {
        return Instantiate(bullet, bulletPos.position,bulletPos.rotation);
    }
    public void TextBullet(Text speed,Text Damage, Text Name)
    {
        speed.text = "Gun Speed : " + bulletCurrent.rowSpeed.ToString();
        Damage.text = "Gun Damage : " + bulletCurrent.Damage.ToString();
        Name.text = "Gun Name : " + bulletCurrent.Name;
    }
}
