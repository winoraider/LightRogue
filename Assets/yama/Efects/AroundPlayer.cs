using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundPlayer : MonoBehaviour
{
    [SerializeField] Transform around;
    [SerializeField] float angleSpeed;
    [SerializeField] float angle = 0.0f;
    [SerializeField] float radius = 2.0f;
    [SerializeField] GameObject center;

    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        //transform.position = center.transform.position;
        around.position = RotateAroundZ(center.transform.position, angle, radius);
        angle += angleSpeed * Time.deltaTime;
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

    public void SetAngle(float angle)
    {
        this.angle = angle;
    }

    public void Active()
    {
        around.gameObject.SetActive(true);
        isActive = true;
    }
}
