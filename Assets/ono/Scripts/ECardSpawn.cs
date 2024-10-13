using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ECardSpawn : MonoBehaviour
{
    [SerializeField] GameObject Ebullet; //ìGÇÃÇΩÇ‹(ÉJÅ[Éh)

    [SerializeField] GameObject ESpawner_01;Å@//íeÇÃSpawnà íu(1Å`3)
    [SerializeField] GameObject ESpawner_02;
    [SerializeField] GameObject ESpawner_03;

    [SerializeField] float elapsedTime = 0.0f;
    [SerializeField] float durationTime = 5.0f;
    [SerializeField] float force = -0.2f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
