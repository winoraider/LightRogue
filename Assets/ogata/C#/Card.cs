using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class Card : MonoBehaviour
{
    GameManager gameM;　//GameManagerのスクリプトを参照

    [SerializeField]
    private float num; //カードの数字
    public int SendNum; //カードの情報を送る用

    [SerializeField]
    private GameObject ObjectColor;　//カードの色の情報を送る用

    private bool leftMouseKey = false;　//マウスの左キーが押されているかの判定
    [SerializeField]
    private GameObject bullet; //弾をインスタンスする用

    [SerializeField]
    private GameObject BattleLane_01;　//01レーンの情報
    [SerializeField]
    private GameObject BattleLane_02;  //02レーンの情報
    [SerializeField]
    private GameObject BattleLane_03;　//03レーンの情報

    [SerializeField] 
    private GameObject Spawner_01;　//弾のスポーン場所の設定（01レーン）
    [SerializeField]
    private GameObject Spawner_02;　//弾のスポーン場所の設定（02レーン）
    [SerializeField]
    private GameObject Spawner_03; //弾のスポーン場所の設定（03レーン）

    [SerializeField]
    private TextMeshProUGUI numText; // TextMeshProの取得

    [SerializeField]
    private bool Lane_01 = false;　//01レーンに触れているかの判定用
    [SerializeField]
    private bool Lane_02 = false;　//02レーンに触れているかの判定用
    [SerializeField]
    private bool Lane_03 = false;　//03レーンに触れているかの判定用

    Vector2 MousePos; //カーソルキーの場所の取得用

    public bool isRed = false;　//カードの色が赤
    public bool isGreen = false;　//カードの色が緑
    public bool isBlue = false;　//カードの色が青


    public Card(bool _red, bool _green, bool _blue){　//カードの色を設定する用

        isRed = _red; //赤を設定する用
        isGreen = _green;　//緑を設定する用
        isBlue = _blue;　//青を設定する用
    }



    private void OnTriggerStay2D(Collider2D collision)　//カードがレーンに触れている間用
    {

            if (collision.gameObject.name == "BattleLane_01")　//カードが01レーンに触れたとき
            {
                Lane_01 = true;
                Lane_02 = false;
                Lane_03 = false;
            }
            else if (collision.gameObject.name == "BattleLane_02") //カードが02レーンに触れたとき
            {
                Lane_01 = false;
                Lane_02 = true ;
                Lane_03 = false;
            }
            else if (collision.gameObject.name == "BattleLane_03")　//カードが03レーンに触れたとき
            {
                Lane_01 = false;
                Lane_02 = false;
                Lane_03 = true;
            }
        
    }
    private void OnTriggerExit2D(Collider2D collision) //カードがレーンから離れた時用
    {
        if (collision.gameObject.name == "BattleLane_01")　//カードが01レーンから離れたとき
        {
            Lane_01 = false;
        }
        else if (collision.gameObject.name == "BattleLane_02")　//カードが02レーンから離れたとき
        {
            Lane_02 = false;
        }
        else if (collision.gameObject.name == "BattleLane_03")　//カードが03レーンから離れたとき
        {
            Lane_03 = false;
        }
    }

    void Start()
    {
        gameM = GameObject.FindObjectOfType<GameManager>(); //GameManagerの取得
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisColor();　//カードの色の表示
        numText.text = ""+num;　//数字をカードに表示

        if (leftMouseKey)　//マウスの左キーが押されているとき
        {
            Vector2 tmpPos = Input.mousePosition;　//マウスカーソルの位置をtmpPosに代入
            MousePos = Camera.main.ScreenToWorldPoint(tmpPos);　//tmpPosを使って、マウスカーソルの位置をUnityのカメラに対応させる
            transform.position = MousePos; //カードの位置をマウスカーソルの位置と同期させる
        }

        if (Input.GetMouseButtonUp(0)&& leftMouseKey)　//マウスの左キーを離したとき
        {
            leftMouseKey = false;　//左キーの情報を押されていない状態にする
        }


    }

    private void OnMouseDown()　//カードを選択して、マウスのキーを押したとき
    {
        if (Input.GetMouseButtonDown(0))　//マウスの左キーだった時
        {
            leftMouseKey = true;　//マウスの左キーが押されている状態にする
        }
    }

    private void OnMouseUp() //マウスのキーを離した時
    {
        if (Input.GetMouseButtonUp(0) && leftMouseKey)　//マウスの左キーを離したとき
        {
            gameM.BulletNum = num; //カードの情報をGameManagerに送る
            leftMouseKey = false;　//マウスの左キーを押されていない状態にする

            gameM.isRed = isRed; //カードの赤の情報をGameManagerに送る
            gameM.isGreen = isGreen;　//カードの緑の情報をGameManagerに送る
            gameM.isBlue = isBlue;　//カードの青の情報をGameManagerに送る

            if (Lane_01)　//01レーンで左キーを離したとき
            {
                Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //弾を出す
                Destroy(this.gameObject);　//カードを消す
            }
            else if (Lane_02)　//02レーンで左キーを離したとき
            {
                Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity); //弾を出す
                Destroy(this.gameObject);　//カードを消す
            }
            else if (Lane_03)　//03レーンで左キーを離したとき
            {
                Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity); //弾を出す
                Destroy(this.gameObject);　//カードを消す
            }
        }
    }

    private void IsRed()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); //赤表示
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
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1); //マゼンタ表示
    }
    private void IsCyan() {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);　//空色表示
    }

    private void IsWhite() {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);　//白表示
    }

    private void ThisColor()
    {
        if (isRed && !isGreen && !isBlue) //カードの色の情報が赤だけだった場合
        {
            IsRed();　//赤表示
        }else if (!isRed && isGreen && !isBlue)　//カードの色の情報が緑だけだった場合
        {
            IsGreen();　//緑表示
        }
        else if (!isRed && !isGreen && isBlue)　//カードの色の情報が青だけだった場合
        {
            IsBlue();　//青表示
        }else if(isRed && isGreen && !isBlue)　//カードの色の情報が赤と緑だった場合
        {
            IsYellow();　//黄色表示
        }else if (isRed && !isGreen && isBlue)　//カードの色の情報が赤と青だった場合
        {
            IsMagenta();　//マゼンタ表示
        }else if (!isRed && isGreen && isBlue)　//カードの色の情報が緑と青だった場合
        {
            IsCyan();　//空色表示
        }else if(isRed && isGreen && isBlue)　//カードの色の情報が赤、緑、青だった場合
        {
            IsWhite();　//白表示
        }
        else　//カードの色の情報が何もなかった場合
        {
            ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);　//黒表示
        }
    }
}
