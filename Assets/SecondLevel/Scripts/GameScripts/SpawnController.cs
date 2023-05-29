using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("WaveChekc")]
    [SerializeField] private bool waveSend;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private int howManyWaves = 10;

    [Header("SpawnPoints")]
    [SerializeField] private Transform[] spawnPointsFLY;
    [SerializeField] private Transform[] spawnPointsSwim;
    [SerializeField] private Transform[] spawnPointsSea;

    [Header("Enemys")]
    [SerializeField] private GameObject enemyFLY;
    [SerializeField] private GameObject enemySwim;
    [SerializeField] private GameObject enemyLittleSwim;
    [SerializeField] private GameObject enemyClamb;
    [SerializeField] private GameObject drunkEnemy;

    [Header("WaveNumber")]
    [SerializeField] private int swimEnemy;
    [SerializeField] private int littleSwim;
    [SerializeField] private int flyEnemy;
    [SerializeField] private int clambEnemy;

    private int random;
    private int random1;
    private int vaweControl = 1;
    private bool WaveCheck;
    void Start()
    {
        StartCoroutine(Timer());
       
    }
    IEnumerator Timer()
    {
        if (waveSend)
        {
            for (int i = 0; i <= howManyWaves; i++)
            {
              
                if (i <= howManyWaves / 2)
                {
                    for (int c = 0; c < littleSwim; c++)
                    {
                        random = Random.Range(0, spawnPointsSwim.Length);
                        Instantiate(enemyLittleSwim, spawnPointsSwim[random].position, Quaternion.identity);
                        random1 = Random.Range(0, 15);
                        //if (random == 3)
                        //{
                        //    Instantiate(drunkEnemy, spawnPointsFLY[random].position, Quaternion.identity);
                        //}
                        yield return new WaitForSeconds(1.75f);
                    }
                    for (int e = 0; e < swimEnemy; e++)
                    {
                        random = Random.Range(0, spawnPointsSwim.Length);
                        Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                       
                        random1 = Random.Range(0, 15);
                        //if (random == 3)
                        //{
                        //    Instantiate(drunkEnemy, spawnPointsFLY[random].position, Quaternion.identity);
                        //}
                        yield return new WaitForSeconds(2.75f);
                    }
                }
                else if (i >= howManyWaves / 2)
                {
                   
                    for (int c = 0; c < swimEnemy; c++)
                    {
                        random = Random.Range(0, spawnPointsSwim.Length);
                        Instantiate(enemySwim, spawnPointsSwim[random].position, Quaternion.identity);
                        random1 = Random.Range(0, 15);
                        //if (random1 == 3)
                        //{
                        //    Instantiate(drunkEnemy, spawnPointsFLY[random].position, Quaternion.identity);
                        //}
                        yield return new WaitForSeconds(2f);
                    }
                    yield return new WaitForSeconds(2.75f);
                    for (int a = 0; a < flyEnemy; a++)
                    {
                        random = Random.Range(0, spawnPointsFLY.Length);
                        Instantiate(enemyFLY, spawnPointsFLY[random].position, Quaternion.identity);
                        random1 = Random.Range(0, 15);
                        //if (random1 == 3)
                        //{
                        //    Instantiate(drunkEnemy, spawnPointsFLY[random].position, Quaternion.identity);
                        //}
                        yield return new WaitForSeconds(1.5f);
                    }
                }
                Instantiate(drunkEnemy, spawnPointsFLY[random].position, Quaternion.identity);
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }

        StartCoroutine(Timer());

    }
}
