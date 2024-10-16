using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ECardSpawn : MonoBehaviour
{
    [SerializeField] GameObject Ebullet; //�G�̂���(�J�[�h)

    [SerializeField] GameObject ESpawner_01;�@//�e��Spawn�ʒu(1�`3)
    [SerializeField] GameObject ESpawner_02;
    [SerializeField] GameObject ESpawner_03;

    [SerializeField] float elapsedTime;//�o�ߎ���
    [SerializeField] float durationTime;//������

    void Start()
    {
    }

    void Update()
    {
        EnemyCardSpawn();
    }

    void EnemyCardSpawn()
    {
        elapsedTime = elapsedTime + Time.deltaTime;
        if (elapsedTime >= durationTime)
        {

            int r = Random.Range(1, 4);
            elapsedTime = 0.0f;
            Debug.Log(r);
            if (r == 1)
            {
                Instantiate(Ebullet, ESpawner_01.transform.position, Quaternion.identity);
                r = 0;
            }
            else if (r == 2)
            {
                Instantiate(Ebullet, ESpawner_02.transform.position, Quaternion.identity);
                r = 0;
            }
            else if (r == 3)
            {
                Instantiate(Ebullet, ESpawner_03.transform.position, Quaternion.identity);
                r = 0;
            }
        }
    }
}
