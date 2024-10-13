using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    bool hit = false;
    [SerializeField] int pPower;
    int counter = 0;
    private string objName;
    public int biggerPower;
    // Start is called before the first frame update
    void Start()
    {
        biggerPower = pPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (pPower <= 0)
        {
            Destroy(gameObject);
        }

        if (hit)
        {
            if(objName == "enemy")
            {
                counter++;
                if (counter >= 60)//1�b��������
                {
                    pPower -= biggerPower / 3;
                    counter = 0;
                    Debug.Log("�v���C���[�F" + pPower);
                }
            }
        }
        else
        {
            transform.position += new Vector3(0, 1.0f, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveEnemy moveEnemy;
        objName = collision.gameObject.name;
        if(collision.gameObject.GetComponent<MoveEnemy>())//�G�ꂽ�I�u�W�F�N�g��MoveEnemy�̃R���|�[�l���g�������Ă�����
        {

        }
        GameObject obj = GameObject.Find(objName);
        moveEnemy = obj.GetComponent<MoveEnemy>();
        if (pPower < moveEnemy.comparePower)
        {
            biggerPower = moveEnemy.comparePower;
        }
        else
        {
            biggerPower = pPower;
        }
        Debug.Log("�傫�����̐���" + biggerPower);
        hit = true;
        /*if(collision.gameObject.tag == "enemy")
        {
        
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objName = "";
        hit = false;
        biggerPower = pPower;
    }
}
