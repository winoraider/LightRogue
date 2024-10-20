using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class EnemyHP : MonoBehaviour
{
    int count = 1;
    int num;
    float elapseTime = 0.0f;
    float durationTime = 60.0f;
    [SerializeField] TextMeshProUGUI numText;
    void Start()
    {
        
    }
    void Update()
    {
        elapseTime += 1 * Time.deltaTime;//Œo‰ß


        if (elapseTime >= durationTime)
        {
            count++;
        }
    }
}
