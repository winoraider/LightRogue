using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionAnimator : MonoBehaviour
{
    [SerializeField] GameObject OptionImage;
    [SerializeField] float speed;
    void Update()
    {
        OptionImage.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
