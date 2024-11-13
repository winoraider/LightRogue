using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Runtime.CompilerServices;

[Serializable]
public struct Data 
{
    public float min;
    public float max;
}

[Serializable]
public struct bData
{
    public float hp;
}

[Serializable]
public struct SpawnDeray
{
    public float min;
    public float max;
}


public class ECardSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> eSpawmers = new List<GameObject>();//スポーン場所
    
    [SerializeField] List<Data> hp = new List<Data>();//敵のhp
    [SerializeField] List<bData> bhp = new List<bData>();//ボスのhp
    [SerializeField] List<SpawnDeray> SpawnDeray = new List<SpawnDeray>();//スポーンレート

    [SerializeField] GameObject Ebullet; //通常時の敵のたま(カード)
    [SerializeField] GameObject Boss;

    [SerializeField] float elapsedTime;//経過時間
    [SerializeField] float durationTime;//↑制限

    [SerializeField] int waves = 0;
    [SerializeField] float currentTime = 0.0f;

    [SerializeField] private Timelimit timelimit;

    private float eCount;//画面にいる敵の数
    public float ECount
    {
        get { return this.eCount; }
        set { this.eCount = value; }
    }

    private bool boss = false;
    private bool SpawnedBoss = false;
    private int currentBoss = 0;

    void Update()
    {
        WaveCount();
        EnemyCardSpawn();

    }

    void EnemyCardSpawn()
    {
        ActiveBoss();//1分経ったかの判定
        if (!boss)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= durationTime)
            {
                Vector2 scale = Vector2.one;
                int r = UnityEngine.Random.Range(0, 3);
                elapsedTime = 0.0f;
                float enemyValue = GenerateEnemy();
                GameObject enemyObj = Instantiate(Ebullet, eSpawmers[r].transform.position, Quaternion.identity);
                EnemyNumController enemyNumController = enemyObj.GetComponent<EnemyNumController>();
                enemyNumController.SetManager(this);
                enemyNumController.NowPower = enemyValue;
                enemyObj.transform.localScale = scale * (0.8f + 0.4f * enemyValue / hp[waves].max);
                r = 0;
                eCount++;
            }

            if (eCount <= 3)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[0].min, SpawnDeray[0].max);
                durationTime = dR;
                //Debug.Log("1～3");
            }
            else if (eCount <= 6)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[1].min, SpawnDeray[1].max);
                durationTime = dR;
                //Debug.Log("4～6");
            }
            else if (eCount <= 9)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[2].min, SpawnDeray[2].max);
                durationTime = dR;
                //Debug.Log("7～9");
            }
            else
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[3].min, SpawnDeray[3].max);
                durationTime = dR;
                //Debug.Log("10以上");
            }
        }
        else
        {
            Debug.Log("Boss");
            if (!SpawnedBoss)
            {
                GameObject BossObj = Instantiate(Boss, eSpawmers[3].transform.position, Quaternion.identity);
                BossEnemyNumController bossNumController = BossObj.GetComponent<BossEnemyNumController>();
                bossNumController.SetManager(this);
                bossNumController.BossNowPower = bhp[currentBoss].hp;
                currentBoss++;
                SpawnedBoss = true;
            }
        }
    }

    private void ActiveBoss()
    {
        if(timelimit.Minutes <= 0 && timelimit.Seconds <= 0)
        {
            elapsedTime = 0;
            durationTime = 100.0f;
            boss = true;
        }
    }

    private void WaveCount()
    {
        currentTime += Time.deltaTime;
        waves = (int)currentTime / 60;
    }
    int GenerateEnemy()
    {
        return UnityEngine.Random.Range((int)hp[waves].min,(int)hp[waves].max+1);
    }
}
