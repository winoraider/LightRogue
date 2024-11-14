using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Prisms;
    [SerializeField]
    private GameObject RelicObject;

    private GameObject Obj;

    private int num;
    // Start is called before the first frame update
    void Start()
    {
        if (Prisms.Count == 0)
        {
            Destroy(this.gameObject);
        }
        num = Random.Range(0, Prisms.Count);
        while (true)
        {
            if (Prisms[num] == null)
            {
                continue;
            }
            Obj = Instantiate(Prisms[num], transform.position, Quaternion.identity);
            Obj.transform.parent = RelicObject.transform;
            break;
        }
    }
}
