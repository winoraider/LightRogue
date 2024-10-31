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
        num = Random.Range(0, Prisms.Count);
        Obj = Instantiate(Prisms[num], transform.position, Quaternion.identity);
        Obj.transform.parent = RelicObject.transform;
    }

    private void OnDestroy()
    {
        Destroy(Obj);
    }
}
