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
    [SerializeField] GameObject Ebullet; //ìGÇÃÇΩÇ‹(ÉJÅ[Éh)
    [SerializeField] GameObject Boss;

    [SerializeField] List<GameObject> eSpawmers = new List<GameObject>();

    [SerializeField] float elapsedTime;//åoâﬂéûä‘
    [SerializeField] float durationTime;//Å™êßå¿

    [SerializeField]int waves = 0;
    [SerializeField]float currentTime = 0.0f;
    
    [SerializeField] List<Data> hp = new List<Data>();

    [SerializeField] List<SpawnDeray> SpawnDeray = new List<SpawnDeray>();

    private float nPower;

    private float eCount;
    public float ECount
    {
        get { return this.eCount; }
        set { this.eCount = value; }
    }

    private bool boss = false;
    private float Timer = 0.0f;

    private void Start()
    {
        
    }
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
            }

            if (eCount <= 3)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[0].min, SpawnDeray[0].max);
                durationTime = dR;
                //Debug.Log("1Å`3");
            }
            else if (eCount <= 6)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[1].min, SpawnDeray[1].max);
                durationTime = dR;
                //Debug.Log("4Å`6");
            }
            else if (eCount <= 9)
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[2].min, SpawnDeray[2].max);
                durationTime = dR;
                //Debug.Log("7Å`9");
            }
            else
            {
                float dR = UnityEngine.Random.Range(SpawnDeray[3].min, SpawnDeray[3].max);
                durationTime = dR;
                //Debug.Log("10à»è„");
            }
        }
        

        //É{ÉXè¢ä´
        Timer += Time.deltaTime;
        if (Timer >= 60.0f)
        {
            boss = true;
            GameObject BossObj = Instantiate(Boss, eSpawmers[4].transform.position, Quaternion.identity);
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
