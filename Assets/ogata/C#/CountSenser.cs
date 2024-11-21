using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSenser : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> CountSensers = new List<GameObject>();
    private int num;

    private GameObject Obj;

    [SerializeField]
    private GameObject RelicObject;
    // Start is called before the first frame update
    void Start()
    {
        if (CountSensers.Count == 0)
        {
            Destroy(this.gameObject);
        }
        num = Random.Range(0, CountSensers.Count);
        while (true)
        {
            if (CountSensers[num] == null)
            {
                continue;
            }
            Obj = Instantiate(CountSensers[num], transform.position, Quaternion.identity);
            Obj.transform.parent = this.transform.parent;
            break;
        }
    }
    private void OnDestroy()
    {
       Destroy (Obj);
    }
}
