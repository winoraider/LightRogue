using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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
    [SerializeField] List<GameObject> eSpawmers = new List<GameObject>();//�X�|�[���ꏊ

    [SerializeField] List<Data> hp = new List<Data>();//�G��hp

    [SerializeField] List<bossData> bhp = new List<bossData>();//�{�X��hp
    [SerializeField] List<SpawnDeray> SpawnDeray = new List<SpawnDeray>();//�X�|�[�����[�g4
    
    [SerializeField] private int LowMiddle = 30;
    [SerializeField] private int MiddleHigh = 60;

    [SerializeField] GameObject[] Ebullet; //�ʏ펞�̓G�̂���(�J�[�h)
    [SerializeField] GameObject Boss;

    [SerializeField] int maxRndEnemy = 12; //�o������G�����߂�Ƃ��̍ő�ꐔ
    [SerializeField] int normalEnemy = 10; //���̂����̃m�[�}���G�l�~�[���o��m���i���10�j

    [SerializeField] float elapsedTime;//�o�ߎ���
    [SerializeField] float durationTime;//������

    [SerializeField] int waves = 0;
    [SerializeField] float currentTime = 0.0f;

    [SerializeField] private Timelimit timelimit;
    [SerializeField] private Timer timer;

    [SerializeField] Image Image1;
    [SerializeField] private Result result;

    private float eCount;//��ʂɂ���G�̐�
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

    private int BossRelicNum;
    public int bossRelicNum
    {
        get { return BossRelicNum; }
        set { this.BossRelicNum = value; }
    }

    private GameObject BossObj;
    public GameObject bossObj
    {
        get { return BossObj; }
        set { BossObj = value; }
    }

    private GameObject EnemyObj;
    public GameObject enemyObj
    {
        get { return EnemyObj; }
        set { EnemyObj = value; }
    }
    private int currentBoss = 0;

    public float FastSpeed;
    public float SlowSpeed;
    public int AttackDamage;
    public float KnockBack;
    void Update()
    {
        ActiveBoss();//1���o�������̔���
        WaveCount();
        EnemyCardSpawn();
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
                elapsedTime = 0.0f;
                float enemyValue = GenerateEnemy();
                EnemyObj = Instantiate(Ebullet[DecideSpawnEnemy()], eSpawmers[SpawnLaneManager()].transform.position, Quaternion.identity);
                EnemyNumController enemyNumController = EnemyObj.GetComponent<EnemyNumController>();
                enemyNumController.SetManager(this);

                GameOverVersion gameOverVersion = EnemyObj.GetComponent<GameOverVersion>();
                gameOverVersion.ResultSetManager(result);

                enemyNumController.NowPower = enemyValue;
                EnemyObj.transform.localScale = scale * (0.8f + 0.4f * enemyValue / hp[waves].max);
                eCount++;
            }

            if (eCount <= 3)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[0].min, SpawnDeray[0].max);                
                durationTime = dR;
            }
            else if (eCount <= 6)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[1].min, SpawnDeray[1].max);
                durationTime = dR;
            }
            else if (eCount <= 9)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[2].min, SpawnDeray[2].max);
                durationTime = dR;
            }
            else
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[3].min, SpawnDeray[3].max);
                durationTime = dR;
            }
        }
        else
        {
            if (!SpawnedBoss)
            {
                BossObj = Instantiate(Boss, eSpawmers[3].transform.position, Quaternion.identity);
                GameOver gameover = BossObj.GetComponent<GameOver>();
                gameover.ResultSetManager(result);
                BossEnemyNumController bossNumController = BossObj.GetComponent<BossEnemyNumController>();
                bossNumController.EcardSetManager(this);
                bossNumController.BossNowPower = bhp[currentBoss].hp;
                BossMove bossMove = BossObj.GetComponent<BossMove>();
                bossMove.EcardSetManager(this);
                currentBoss++;
                SpawnedBoss = true;
            }
            if(DeadBoss)
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
    private int DecideSpawnEnemy() //�o������G�����߂�֐�
    {
        int enemyNum;
        if(waves >= 10) //�ꐔ�̑傫�������߂�
        {
            maxRndEnemy = 202;
        }
        else
        {
            maxRndEnemy = waves * 2;
        }

        if(normalEnemy >= UnityEngine.Random.Range(1, 11 + maxRndEnemy)) //�o������G�����߂�
        {
            enemyNum =  0;
        }
        else
        {
            if(waves < 5)
            {
                //�E�F�[�u���S�ȉ��̎��͏o�Ă������G�l�~�[�̎�ނ����Ȃ�
                enemyNum = UnityEngine.Random.Range(1,3);
            }
            else
            {
                enemyNum = UnityEngine.Random.Range(1, 4);
            }
        } 
        //�ǂ̓G���o�����̃f�o�b�O
        return enemyNum;
    }

    private int SpawnLaneManager() //�G�̏o�����[�������߂�֐�
    {
        int rndMin = 0;
        int rndMax = 90;
        int rnd = UnityEngine.Random.Range(rndMin, rndMax);
        int lane = 0; //�G�̏o���ꏊ�����߂�ϐ�
        if (rnd >= rndMin && rnd < LowMiddle)//�o���ꏊ�����߂違�m���̕ύX
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
}
