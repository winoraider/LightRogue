using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2Dの取得
    GameManager gameM;　//GameManagerのスクリプトを取得
    public bool tmp = false;

    BulletBehind tmpColor;　//色を送るためのスクリプトを取得

    [SerializeField]
    private GameObject ObjectColor; //色を変えるオブジェクトを取得

    [SerializeField]
    private float speed; //弾のスピード
    public float numBullet; //弾の数字

    private int nBToText;//テキスト表示上の弾の数字

    [SerializeField]
    private TextMeshProUGUI numText;　//テキストのコンポーネントを取得

    public bool isRed = false;　//赤が入っているか判定
    public bool isGreen = false;　//緑が入っているか判定
    public bool isBlue = false;　//青が入っているか判定
    

    float posY;

    public bool min;
    public bool mid;
    public bool max;

    public bool Bubble = false;
    public float BubbleCount = 0;
    public int  BubbleCount2 = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<BulletBehind>()) //触れたのがBulletだったとき実行
        {
            
            collision.gameObject.GetComponent<BulletBehind>().tmpState(isRed, isGreen, isBlue, numBullet); //このBulletの色の情報を、触れたBulletに送る
           
            
        }

        else
        {
            return;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            //Vector2 force = new Vector2(0, -3);
            //rb.AddForce(force);
            //transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            ////numBullet -= 1;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        

        gameM = FindObjectOfType<GameManager>();　//GameManagerを参照する
        rb = GetComponent<Rigidbody2D>();　//Rigidbodyを参照する

        isRed = gameM.isRed;　//色の情報をGameManagerから受け取る
        isGreen = gameM.isGreen;　//色の情報をGameManagerから受け取る
        isBlue = gameM.isBlue;　//色の情報をGameManagerから受け取る

        //numBullet = gameM.BulletNum;　//数字の情報をGameManagerから受け取る
    }

    void Update()
    {
        nBToText = Mathf.CeilToInt(numBullet);
        if(Bubble)
        {
            BubbleCount += 1 * Time.deltaTime;
            if (BubbleCount >= 1)
            {
                numBullet = numBullet * 1.3f;
                numBullet = Mathf.CeilToInt(numBullet);
                BubbleCount = 0;
                BubbleCount2++;
            }
            if (BubbleCount2 >= 10)
            {
                Destroy(this.gameObject);
            }
        }

        ThisColor();　//カラーの表示をする
        numText.text = "" + nBToText;　//弾に数字を表示させる

        if (this.gameObject.transform.position.y > 3.5f)
        {
            transform.position = new Vector2(transform.position.x,3.5f);
        }
        else
        {
            if (gameM.SpeedUpper)
            {
                rb.velocity = new Vector2(0, speed * 1.2f);
            }
            else
            {
                rb.velocity = new Vector2(0, speed);
            }
        }
        if (numBullet <= 0)
        {
            Destroy(this.gameObject);　//弾の数字が0になったら消える
        }
            
        
        if(numBullet <= 19 && !min) {

            transform.localScale = new Vector2(0.8f, 0.8f);
            if (mid)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
                mid = false;
            }
            if (max)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
                max = false;
            }          
            min = true;
        }else if (numBullet <= 31 && numBullet >= 20 && !mid)
        {
            transform.localScale = new Vector2(1f, 1f);
            posY = transform.position.y;
            if (max)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
                max = false;
            }else if (min)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
                min = false;
            }
            mid = true;

        }
        else if (numBullet >=32 && !max)
        {                
            transform.localScale = new Vector2(1.2f,1.2f);
            if (min)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y -0.2f);
                min = false;
            }
            if (mid)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
                mid = false;
            }
            max = true;
        }
    }

    private void IsRed()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);　//赤表示
    }

    private void IsGreen()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);　//緑表示
    }

    private void IsBlue()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);　//青表示
    }

    private void IsYellow()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);　//黄表示
    }

    private void IsMagenta()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);　//マゼンタ表示
    }
    private void IsCyan()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);　//空色表示
    }

    private void IsWhite()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);　//白表示
    }

    private void ThisColor()
    {
        if (isRed && !isGreen && !isBlue)　//弾の色の情報が赤だけだった場合
        {
            IsRed();　//弾を赤にする
        }
        else if (!isRed && isGreen && !isBlue)　//弾の色の情報が緑だけだった場合
        {
            IsGreen();　//弾を緑にする
        }
        else if (!isRed && !isGreen && isBlue)　//弾の色の情報が青だけだった場合
        {
            IsBlue(); //弾を青にする
        }
        else if (isRed && isGreen && !isBlue)　//弾の色の情報が赤と緑だった場合
        {
            IsYellow(); //弾を黄にする
        }
        else if (isRed && !isGreen && isBlue) //弾の色の情報が赤と青だった場合
        {
            IsMagenta(); //弾をマゼンタにする
        }
        else if (!isRed && isGreen && isBlue) //弾の色の情報が緑と青だった場合
        {
            IsCyan(); //弾を空色にする
        }
        else if (isRed && isGreen && isBlue) //弾の色の情報が赤、緑、青が揃っていた場合
        {
            IsWhite();　//弾の色を城にする
        }
        else //弾の色の情報が不明だった場合
        {
            ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);　//弾の色を黒にする
        }
    }
    public void isDestroy()
    {
        Destroy(this.gameObject);
    }
    //private char calc(float num)
    //{
    //    char Text;

    //    return 
    //}
}
