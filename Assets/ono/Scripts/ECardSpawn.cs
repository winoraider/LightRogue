using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;
using Unity.VisualScripting;

[Serializable]
public struct Data 
{
    public float min;
    public float max;
}

public class ECardSpawn : MonoBehaviour
{
    [SerializeField] GameObject Ebullet; //ìGÇÃÇΩÇ‹(ÉJÅ[Éh)

    [SerializeField] GameObject ESpawner_01;Å@//íeÇÃSpawnà íu(1Å`3)
    [SerializeField] GameObject ESpawner_02;
    [SerializeField] GameObject ESpawner_03;

    [SerializeField] float elapsedTime;//åoâﬂéûä‘
    [SerializeField] float durationTime;//Å™êßå¿

    [SerializeField]int waves = 0;
    [SerializeField]float currentTime = 0.0f;
    
    [SerializeField] List<Data> hp = new List<Data>();

    [SerializeField] TextMeshProUGUI numText;

    void Start()
    {
    }

    void Update()
    {
        
        WaveCount();
        EnemyCardSpawn();
    }

    void EnemyCardSpawn()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= durationTime)
        {

            int r =UnityEngine. Random.Range(1, 4);
            elapsedTime = 0.0f;
            Debug.Log(r);
            if (r == 1)
            {
                float enemyValue = GenereteEnemy();
                GameObject enemyObj = Instantiate(Ebullet, ESpawner_01.transform.position, Quaternion.identity);
                EnemyNumController enemyNumController = Ebullet.GetComponent<EnemyNumController>();
                enemyNumController.nowPower = enemyValue;
                numText.text = "" + enemyNumController.nowPower;
                r = 0;
            }
            else if (r == 2)
            {
                float enemyValue = GenereteEnemy();
                GameObject enemyObj = Instantiate(Ebullet, ESpawner_01.transform.position, Quaternion.identity);
                EnemyNumController enemyNumController = Ebullet.GetComponent<EnemyNumController>();
                enemyNumController.nowPower = enemyValue;
                numText.text = "" + enemyNumController.nowPower;
                r = 0;
            }
            else if (r == 3)
            {
                float enemyValue = GenereteEnemy();
                GameObject enemyObj = Instantiate(Ebullet, ESpawner_01.transform.position, Quaternion.identity);
                EnemyNumController enemyNumController = Ebullet.GetComponent<EnemyNumController>();
                enemyNumController.nowPower = enemyValue;
                numText.text = "" + enemyNumController.nowPower;
                r = 0;
            }
        }
    }

    private void WaveCount()
    {
        currentTime += Time.deltaTime;
        waves = (int)currentTime / 60;
        Debug.Log(waves);
    }
    int GenereteEnemy()
    {
        return UnityEngine.Random.Range((int)hp[waves].min, (int)hp[waves].max);
    }
}
