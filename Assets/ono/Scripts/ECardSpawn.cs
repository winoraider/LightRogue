using System.Collections.Generic;
using UnityEngine;
using System;

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
            float enemyValue = GenerateEnemy();
            GameObject enemyObj = Instantiate(Ebullet, eSpawmers[r].transform.position, Quaternion.identity);
            EnemyNumController enemyNumController = enemyObj.GetComponent<EnemyNumController>();
            enemyNumController.SetManager(this);
            enemyNumController.NowPower = enemyValue;
            enemyObj.transform.localScale = scale * (0.8f + 0.4f * enemyValue / hp[waves].max);
            r = 0;
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
