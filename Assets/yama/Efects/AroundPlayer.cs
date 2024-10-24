using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundPlayer : MonoBehaviour
{
    [SerializeField] float angleSpeed;
    [SerializeField] float angle = 0.0f;
    [SerializeField] float radius = 2.0f;
    [SerializeField] GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = center.transform.position;
        transform.position = RotateAroundZ(center.transform.position, angle, radius);
        angle += angleSpeed;
    }

    // ZŽ²‰ñ“]
    static Vector3 RotateAroundZ(Vector3 original_position, float angle, float radius)
    {
        Vector3 v = original_position;
        v.y += radius;
        float a = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(a) * v.x - Mathf.Sin(a) * v.y;
        float y = Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.y;
        float z = v.z;
        return new Vector3(x, y, z);
    }
}
