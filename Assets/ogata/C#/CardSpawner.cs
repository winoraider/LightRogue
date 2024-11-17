using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    Card card;
    [SerializeField]
    public List <GameObject> cards;

    public bool[] spawd = new bool[15];

    private GameObject cloneCard;

    [SerializeField]
    private GameObject Spawner01;
    [SerializeField]
    private GameObject Spawner02;
    [SerializeField]
    private GameObject Spawner03;

    [SerializeField]
    private GameObject CanvasObject;

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
        num = Random.Range(0, cards.Count);
        cloneCard = Instantiate(cards[num], Spawner01.transform.position, Quaternion.identity);
        cloneCard.gameObject.GetComponent<Card>().pos01card = true;
        pos01card = true;
        spawd[num] = true;
        while (true)
        {
            num = Random.Range(0, cards.Count);
            if (!spawd[num])
            {
                cloneCard = Instantiate(cards[num], Spawner02.transform.position, Quaternion.identity);
                cloneCard.gameObject.GetComponent<Card>().pos02card = true;
                pos02card = true;
                spawd[num] = true;
                break;
            }
        }
        while (true)
        {
            num = Random.Range(0, cards.Count);
            if (!spawd[num])
            {

                cloneCard = Instantiate(cards[num], Spawner03.transform.position, Quaternion.identity);
                cloneCard.gameObject.GetComponent<Card>().pos03card = true;
                pos03card = true;
                spawd[num] = true;
                break;
            }
        }
        }
        private void Update()
    {

        if (!pos01card)
        {
            coolDown1 += 1 * Time.deltaTime;

            if (coolDown1 >= derayTime)
            {
                


                num = Random.Range(0, cards.Count);
                if (!spawd[num])
                {
                    coolDown1 = 0;
                    cloneCard = Instantiate(cards[num], Spawner01.transform.position, Quaternion.identity);
                    cloneCard.gameObject.GetComponent<Card>().pos01card = true;
                    pos01card = true;
                    spawd[num] = true;
                }
                else
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        if (spawd[i])
                        {
                            if (spawd[cards.Count - 1])
                            {
                                    for (int n = 0; n < cards.Count; n++)
                                    {
                                        spawd[n] = false;
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

        }
        if (!pos02card)
        {
            coolDown2 += 1 * Time.deltaTime;

            if (coolDown2 >= derayTime)
            {

                num = Random.Range(0, cards.Count);
                if (!spawd[num])
                {
                    coolDown2 = 0;
                    cloneCard = Instantiate(cards[num], Spawner02.transform.position, Quaternion.identity);
                    cloneCard.gameObject.GetComponent<Card>().pos02card = true;
                    pos02card = true;
                    spawd[num] = true;
                }
                else
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        if (spawd[i])
                        {
                            if (spawd[cards.Count - 1])
                            {
                                for (int n = 0; n < cards.Count; n++)
                                {
                                    spawd[n] = false;
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
        }
        if (!pos03card)
        {
            coolDown3 += 1 * Time.deltaTime;

            if (coolDown3 >= derayTime)
            {
                num = Random.Range(0, cards.Count);
                if (!spawd[num])
                {
                    coolDown3 = 0;
                    cloneCard = Instantiate(cards[num], Spawner03.transform.position, Quaternion.identity);
                    cloneCard.gameObject.GetComponent<Card>().pos03card = true;
                    spawd[num] = true;
                    pos03card = true;
                }
                else
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        if (spawd[i])
                        {
                            if (spawd[cards.Count - 1])
                            {
                                for (int n = 0; n < cards.Count; n++)
                                {
                                    spawd[n] = false;
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
        }
    }
}
