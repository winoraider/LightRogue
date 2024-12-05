using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    [SerializeField] Vector3 center = Vector3.zero;
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] float period = 2.0f;
    [SerializeField] float distance = 0.1f;
    void Update()
    {
        Vector3 direction = (transform.position - center).normalized;  // 現在位置から中心へのベクトルを正規化
        transform.position = center + direction * distance;  // 指定の距離だけ離す

        transform.RotateAround(center, axis, 360 / period * Time.deltaTime);       
    }
}
