using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    Card card;
    [SerializeField]
    public GameObject[] cards;

    [SerializeField]
    private GameObject cardobj;

    private GameObject cloneCard;

    [SerializeField]
    private GameObject Spawner01;
    [SerializeField]
    private GameObject Spawner02;
    [SerializeField]
    private GameObject Spawner03;

    private int num;

    public bool pos01card = false;
    public bool pos02card = false;
    public bool pos03card = false;
    private void Update()
    {

        if (!pos01card)
        {
            num = Random.Range(0, cards.Length);
            cloneCard = Instantiate(cards[num], Spawner01.transform.position, Quaternion.identity);
            cloneCard.gameObject.GetComponent<Card>().pos01card = true;
            pos01card = true;

        }
        if (!pos02card)
        {
            num = Random.Range(0, cards.Length);
            cloneCard = Instantiate(cards[num], Spawner02.transform.position, Quaternion.identity);
            cloneCard.gameObject.GetComponent<Card>().pos02card = true;
            pos02card = true;
        }
        if (!pos03card)
        {
            num = Random.Range(0, cards.Length);
            cloneCard = Instantiate(cards[num], Spawner03.transform.position, Quaternion.identity);
            cloneCard.gameObject.GetComponent<Card>().pos03card = true;
            pos03card = true;
        }
    }
}
