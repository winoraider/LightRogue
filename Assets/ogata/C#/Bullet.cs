using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2Dの取得
    GameManager gameM;　//GameManagerのスクリプトを取得


    BulletBehind tmpColor;　//色を送るためのスクリプトを取得

    [SerializeField]
    private GameObject ObjectColor; //色を変えるオブジェクトを取得

    [SerializeField]
    private float speed; //弾のスピード
    public float numBullet; //弾の数字

    [SerializeField]
    private TextMeshProUGUI numText;　//テキストのコンポーネントを取得

    public bool isRed = false;　//赤が入っているか判定
    public bool isGreen = false;　//緑が入っているか判定
    public bool isBlue = false;　//青が入っているか判定

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.GetComponent<BulletBehind>())　//触れたのがBulletだったとき実行
            {
            collision.gameObject.GetComponent<BulletBehind>().tmpNum(numBullet); //このBulletの数字を、触れたBulletに送る
            collision.gameObject.GetComponent<BulletBehind>().tmpColor(isRed,isGreen,isBlue);　//このBulletの色の情報を、触れたBulletに送る
                Destroy(this.gameObject);　//このオブジェクトを削除する
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

        numBullet = gameM.BulletNum;　//数字の情報をGameManagerから受け取る
    }

    void Update()
    {
        ThisColor();　//カラーの表示をする
        numText.text = "" + numBullet;　//弾に数字を表示させる


        if(numBullet <= 0)
        {
            Destroy(this.gameObject);　//弾の数字が0になったら消える
        }

        rb.velocity = new Vector2(0,speed);　//弾の動き
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
}
