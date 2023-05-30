using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    Transform targetPos;
    public float speed = 2.0f;
    public Vector3 delayAmount;
    private Vector3 targetVector;
    [Space]
    private bool titremeDevamEdiyor = false;
    private Vector3 orijinalPozisyon;
    private float titremeSiddeti = 0.5f;
    private float titremeSure = 0.3f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        targetPos = GameObject.FindGameObjectWithTag("Ship").transform;
        // Karakter ile kamera arasýndaki baþlangýç mesafesini belirlemek için kullanýlýr.
        delayAmount = transform.position - targetPos.position;
    }

    void LateUpdate()
    {
        if(targetPos != null)
            targetVector = targetPos.position + delayAmount;

        Vector3 yumusatilmisPozisyon = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);

        transform.position = yumusatilmisPozisyon;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            BaslatTitreme();
        }
    }

    void BaslatTitreme()
    {
        if (!titremeDevamEdiyor)
        {
            orijinalPozisyon = transform.position;
            titremeDevamEdiyor = true;
            InvokeRepeating("TitremeEfekti", 0f, 0.01f);
            Invoke("DurdurTitreme", titremeSure);
        }
    }

    void TitremeEfekti()
    {
        float titremeX = Random.Range(-titremeSiddeti, titremeSiddeti);
        float titremeY = Random.Range(-titremeSiddeti, titremeSiddeti);
        float titremeZ = Random.Range(-titremeSiddeti, titremeSiddeti);

        transform.position = new Vector3(orijinalPozisyon.x + titremeX, orijinalPozisyon.y + titremeY, orijinalPozisyon.z + titremeZ);
    }

    void DurdurTitreme()
    {
        titremeDevamEdiyor = false;
        CancelInvoke("TitremeEfekti");
        transform.position = orijinalPozisyon;
    }
}
