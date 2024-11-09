using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[Serializable]
public struct Data 
{
    public float min;
    public float max;
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

    [SerializeField] List<SpawnDeray> SpawnDeray = new List<SpawnDeray>();//�X�|�[�����[�g

    [SerializeField] GameObject Ebullet; //�ʏ펞�̓G�̂���(�J�[�h)
    [SerializeField] GameObject Boss;

    [SerializeField] float elapsedTime;//�o�ߎ���
    [SerializeField] float durationTime;//������

    [SerializeField] int waves = 0;
    [SerializeField] float currentTime = 0.0f;

    [SerializeField] private Timelimit timelimit;

    private float eCount;//��ʂɂ���G�̐�
    public float ECount
    {
        get { return this.eCount; }
        set { this.eCount = value; }
    }

    private bool boss = false;

    void Update()
    {
        WaveCount();
        EnemyCardSpawn();

    }

    void EnemyCardSpawn()
    {
        if(!boss)
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

                ActiveBoss();//1���o�������̔���
            }

            if (eCount <= 3)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[0].min, SpawnDeray[0].max);
                durationTime = dR;
                //Debug.Log("1�`3");
            }
            else if (eCount <= 6)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[1].min, SpawnDeray[1].max);
                durationTime = dR;
                //Debug.Log("4�`6");
            }
            else if (eCount <= 9)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[2].min, SpawnDeray[2].max);
                durationTime = dR;
                //Debug.Log("7�`9");
            }
            else
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[3].min, SpawnDeray[3].max);
                durationTime = dR;
                //Debug.Log("10�ȏ�");
            }
        }else
        {
            boss = true;
            Debug.Log("boss is true" + boss);
            GameObject BossObj = Instantiate(Boss, eSpawmers[4].transform.position, Quaternion.identity);
        }


    }

    private void ActiveBoss()
    {
        if(timelimit.Minutes <= 0 && timelimit.Seconds <= 0)
        {
            Debug.Log("1��������" + timelimit.Minutes);
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
