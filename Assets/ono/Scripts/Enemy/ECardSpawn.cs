using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

[Serializable]
public struct Data 
{
    public float min;
    public float max;
}

[Serializable]
public struct bossData
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

    [SerializeField] List<bossData> bhp = new List<bossData>();//ボスのhp
    [SerializeField] List<SpawnDeray> SpawnDeray = new List<SpawnDeray>();//スポーンレート4
    
    [SerializeField] private int LowMiddle = 30;
    [SerializeField] private int MiddleHigh = 60;

    [SerializeField] GameObject[] Ebullet; //通常時の敵のたま(カード)
    [SerializeField] GameObject Boss;

    [SerializeField] int maxRndEnemy = 12; //出現する敵を決めるときの最大母数
    [SerializeField] int normalEnemy = 10; //↑のうちのノーマルエネミーが出る確率（常に10）

    [SerializeField] float elapsedTime;//経過時間
    [SerializeField] float durationTime;//↑制限

    [SerializeField] int waves = 0;
    [SerializeField] float currentTime = 0.0f;

    [SerializeField] private Timelimit timelimit;
    [SerializeField] private Timer timer;

    [SerializeField] Image Image1;

    private float eCount;//画面にいる敵の数
    public float ECount
    {
        get { return this.eCount; }
        set { this.eCount = value; }
    }

    private bool boss = false;
    public bool BOSS
    {
        get { return this.boss; }
        set { this.boss = value; }
    }

    private bool SpawnedBoss = false;
    public bool spawnedBoss
    {
        get { return SpawnedBoss; }
        set { this.SpawnedBoss = value;}
    }

    private bool DeadBoss = false;
    public bool deadBoss
    {
        get { return DeadBoss; }
        set { this.DeadBoss = value; }
    }
    private int currentBoss = 0;

    public float FastSpeed;
    public float SlowSpeed;
    public int AttackDamage;
    public float KnockBack;
    void Update()
    {
        ActiveBoss();//1分経ったかの判定
        WaveCount();
        EnemyCardSpawn();
        //Debug.Log("boss + " + boss) ;
    }

    void EnemyCardSpawn()
    {
        if (!boss)
        {
            SpawnedBoss = false;
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= durationTime)
            {
                Vector2 scale = Vector2.one;
                //Debug.Log("出現場所:" + r + "LowMiddle:" + LowMiddle + "MiddleHigh" + MiddleHigh + "rnd:" + rnd);
                elapsedTime = 0.0f;
                float enemyValue = GenerateEnemy();
                GameObject enemyObj = Instantiate(Ebullet[DecideSpawnEnemy()], eSpawmers[SpawnLaneManager()].transform.position, Quaternion.identity);
                EnemyNumController enemyNumController = enemyObj.GetComponent<EnemyNumController>();
                enemyNumController.SetManager(this);
                enemyNumController.NowPower = enemyValue;
                enemyObj.transform.localScale = scale * (0.8f + 0.4f * enemyValue / hp[waves].max);
                eCount++;
            }

            if (eCount <= 3)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[0].min, SpawnDeray[0].max);                durationTime = dR;
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
            if (!SpawnedBoss)
            {
                RelicNum();
                Relic();
                GameObject BossObj = Instantiate(Boss, eSpawmers[3].transform.position, Quaternion.identity);
                BossEnemyNumController bossNumController = BossObj.GetComponent<BossEnemyNumController>();
                bossNumController.EcardSetManager(this);
                bossNumController.BossNowPower = bhp[currentBoss].hp;
                currentBoss++;
                SpawnedBoss = true;
            }else if(DeadBoss)
            {
                timelimit.Minutes = 1;
                Image1.fillAmount = 0f;
                DeadBoss = false;
            }
        }
        
    }

    private void ActiveBoss()
    {
        if (timelimit.Minutes <= 0 && timelimit.Seconds <= 0)
        {
            elapsedTime = 0;
            durationTime = 100.0f;
            boss = true;
        }
        else
        {
            boss = false;
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

<<<<<<< HEAD
    private int DecideSpawnEnemy() //出現する敵を決める関数
    {
        int enemyNum;
        if(waves >= 10) //母数の大きさを決める
        {
            maxRndEnemy = 202;
        }
        else
        {
            maxRndEnemy = waves * 2;
        }

        if(normalEnemy >= UnityEngine.Random.Range(1, 11 + maxRndEnemy)) //出現する敵を決める
        {
            enemyNum =  2;
        }
        else
        {
            if(waves < 5)
            {
                //ウェーブが４以下の時は出てくる特殊エネミーの種類が少ない
                enemyNum = UnityEngine.Random.Range(1,3);
            }
            else
            {
                enemyNum = UnityEngine.Random.Range(1, 4);
            }
        }
        /*
        if(enemyNum == 0)
        {
            Debug.Log("ノーマル");
        }
        else if (enemyNum == 1)
        {
            Debug.Log("ファスト");
        }
        else if (enemyNum == 2)
        {
            Debug.Log("ブラインド");
        }
        else if (enemyNum == 3)
        {
            Debug.Log("ブラックアウト");
        }
        */ //どの敵が出たかのデバッグ
        return enemyNum;
    }

    private int SpawnLaneManager() //敵の出現レーンを決める関数
    {
        int rndMin = 0;
        int rndMax = 90;
        int rnd = UnityEngine.Random.Range(rndMin, rndMax);
        int lane = 0; //敵の出現場所を決める変数
        if (rnd >= rndMin && rnd < LowMiddle)//出現場所を決める＆確率の変更
        {
            lane = 0;
            LowMiddle -= 10;
            MiddleHigh -= 5;
        }
        else if (rnd >= LowMiddle && rnd < MiddleHigh)
        {
            lane = 1;
            LowMiddle += 5;
            MiddleHigh -= 5;
        }
        else if (rnd >= MiddleHigh && rnd < rndMax)
        {
            lane = 2;
            LowMiddle += 5;
            MiddleHigh += 10;
        }
        if (LowMiddle < rndMin + 5)
        {
            LowMiddle = rndMin + 5;
        }
        if (MiddleHigh > rndMax - 5)
        {
            MiddleHigh = rndMax - 5;
        }

        return lane;
    }

=======
   public void Relic()
    {
        if (RelicNum() == 0)
        {
            FastSpeed = 1.2f;
        }
        if (RelicNum() == 1)
        {
            SlowSpeed = 0.8f;
        }
        if(RelicNum() == 2)
        {
            AttackDamage = 100;
        }
        if(RelicNum() == 3)
        {
            KnockBack = 5f;
        }
    }

    int RelicNum()
    {
        return UnityEngine.Random.Range(0, 5);
    }
>>>>>>> kanta
}
