using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelUpUi;
    LevelUpUi levelUi;
    // Start is called before the first frame update

    //private void OnMouseDown()　//カードを選択して、マウスのキーを押したとき
    //{
    //    Debug.Log("呼び出されています");
    //    levelUi = FindObjectOfType<LevelUpUi>();
    //    if(levelUi != null)
    //    {
    //        Destroy(levelUi.CloneAlow);
    //    }
    //    levelUi.CloneAlow = Instantiate(levelUi.Alow, new Vector2(transform.position.x,transform.position.y + 50),Quaternion.identity);
    //    levelUi.CloneAlow.transform.parent = LevelUpUi.transform;
    //}
}
