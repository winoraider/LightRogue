using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;
using Unity.VisualScripting;
using JetBrains.Annotations;

[Serializable]
public struct Data 
{
    public float min;
    public float max;
}

public class ECardSpawn : MonoBehaviour
{
    [SerializeField] GameObject Ebullet; //敵のたま(カード)

    [SerializeField] List<GameObject> eSpawmers = new List<GameObject>();

    [SerializeField] float elapsedTime;//経過時間
    [SerializeField] float durationTime;//↑制限

    [SerializeField]int waves = 0;
    [SerializeField]float currentTime = 0.0f;
    
    [SerializeField] List<Data> hp = new List<Data>();

    private float nPower;

    public float NPower
    {
        get { return nPower; }
        set { nPower = value; }
    }

    [SerializeField] EnemyNumController enemyNumController;

    void Awake()
    {
        enemyNumController = FindObjectOfType<EnemyNumController>();
        if (enemyNumController == null)
        {
            Debug.LogError("EnemyNumController not found!");
        }
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
            Vector2 scale = Vector2.one;
            int r = UnityEngine. Random.Range(0, 3);
            elapsedTime = 0.0f;
            Debug.Log("レーン" + r);

            float enemyValue = GenereteEnemy();
            GameObject enemyObj = Instantiate(Ebullet, eSpawmers[r].transform.position, Quaternion.identity);
            nPower = enemyNumController.NowPower;
            Debug.Log("NowPower type: " + enemyNumController.NowPower.GetType());
            nPower = enemyValue;
            Debug.Log("value " + enemyValue + "max" + hp[waves].max + "nowpower" + nPower) ;
            enemyObj.transform.localScale = scale * (0.8f + 0.4f * enemyValue / hp[waves].max);
            Debug.Log("Enemy scale: " + enemyObj.transform.localScale);
            r = 0;
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
        return UnityEngine.Random.Range((int)hp[waves].min,(int)hp[waves].max+1);
    }
}
