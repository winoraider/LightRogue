using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    [SerializeField] private float minScale;
    [SerializeField] private float changeScale;
    private void Update()
    {
        Vector3 oneVector = new Vector3(minScale * 2f, minScale, minScale);
        Vector3 clac = Vector3.one * changeScale * Mathf.Abs(Mathf.Sin(Time.time * 2));
        transform.localScale = oneVector + clac;
    }
}