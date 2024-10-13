using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    Card card;
    [SerializeField]
    public GameObject[] cards;

    public bool[] spawd = new bool[15];

    private GameObject cloneCard;

    [SerializeField]
    private GameObject Spawner01;
    [SerializeField]
    private GameObject Spawner02;
    [SerializeField]
    private GameObject Spawner03;

    private int num;

    
    private float coolDown1;
    private float coolDown2;
    private float coolDown3;

    public bool pos01card = false;
    public bool pos02card = false;
    public bool pos03card = false;

    [SerializeField]
    private float derayTime;

    private void Start()
    {
        cloneCard = Instantiate(cards[num], Spawner01.transform.position, Quaternion.identity);
        cloneCard.gameObject.GetComponent<Card>().pos01card = true;
        pos01card = true;
        spawd[num] = true;
        cloneCard = Instantiate(cards[num], Spawner02.transform.position, Quaternion.identity);
        cloneCard.gameObject.GetComponent<Card>().pos02card = true;
        pos01card = true;
        spawd[num] = true;
        cloneCard = Instantiate(cards[num], Spawner01.transform.position, Quaternion.identity);
        cloneCard.gameObject.GetComponent<Card>().pos01card = true;
        pos01card = true;
        spawd[num] = true;
    }
    private void Update()
    {

        if (!pos01card)
        {
            coolDown1 += 1 * Time.deltaTime; 

            if(coolDown1 < derayTime)
            {
                return;
            }

            num = Random.Range(0, cards.Length);
            if (!spawd[num])
            {
                cloneCard = Instantiate(cards[num], Spawner01.transform.position, Quaternion.identity);
                cloneCard.gameObject.GetComponent<Card>().pos01card = true;
                pos01card = true;
                spawd[num] = true;
            }
            else
            {
                for(int i = 0; i < cards.Length; i++)
                {
                    if (spawd[i])
                    {
                        if (spawd[cards.Length -1])
                        {
                            if (!pos01card && !pos02card && !pos03card)
                            {
                                for (int n = 0; n < cards.Length; n++)
                                {
                                    spawd[n] = false;
                                }
                            }
                        }
                        continue;
                    }
                    else
                    {
                        break;
                    }
                    
                }
                return;
            }

        }
        if (!pos02card)
        {
            coolDown2 += 1 * Time.deltaTime;

            if (coolDown2 < derayTime)
            {
                return;
            }
            num = Random.Range(0, cards.Length);
            if (!spawd[num])
            {
                cloneCard = Instantiate(cards[num], Spawner02.transform.position, Quaternion.identity);
                cloneCard.gameObject.GetComponent<Card>().pos02card = true;
                pos02card = true;
                spawd[num] = true;
            }
            else
            {
                return;
            }
        }
        if (!pos03card)
        {
            coolDown3 += 1 * Time.deltaTime;

            if (coolDown3 < derayTime)
            {
                return;
            }
            num = Random.Range(0, cards.Length);
                if (!spawd[num])
                {
                    cloneCard = Instantiate(cards[num], Spawner03.transform.position, Quaternion.identity);
                    cloneCard.gameObject.GetComponent<Card>().pos03card = true;
                spawd[num] = true;
                pos03card = true;
                }
                else
                {
                    return;
                }
        }
    }
}
