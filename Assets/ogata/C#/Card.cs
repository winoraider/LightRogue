using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    GameManager gameM;

    [SerializeField]
    private float num; //カードの数字
    public int SendNum; //カードの情報を送る用

    [SerializeField]
    private GameObject ObjectColor;

    private bool leftMouseKey = false;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject BattleLane_01;
    [SerializeField]
    private GameObject BattleLane_02;
    [SerializeField]
    private GameObject BattleLane_03;

    [SerializeField] 
    private GameObject Spawner_01;
    [SerializeField]
    private GameObject Spawner_02;
    [SerializeField]
    private GameObject Spawner_03;
    
    [SerializeField]
    private TextMeshProUGUI numText;

    [SerializeField]
    private bool Lane_01 = false;
    [SerializeField]
    private bool Lane_02 = false;
    [SerializeField]
    private bool Lane_03 = false;

    Vector2 MousePos;

    public bool isRed = false;
    public bool isGreen = false;
    public bool isBlue = false;

    private GameObject Cardcolor;


    public Card(bool _red, bool _green, bool _blue){

        isRed = _red; 
        isGreen = _green;
        isBlue = _blue;
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

            if (collision.gameObject.name == "BattleLane_01")
            {
                Lane_01 = true;
                Lane_02 = false;
                Lane_03 = false;
            }
            else if (collision.gameObject.name == "BattleLane_02")
            {
                Lane_01 = false;
                Lane_02 = true ;
                Lane_03 = false;
            }
            else if (collision.gameObject.name == "BattleLane_03")
            {
                Lane_01 = false;
                Lane_02 = false;
                Lane_03 = true;
            }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BattleLane_01")
        {
            Lane_01 = false;
        }
        else if (collision.gameObject.name == "BattleLane_02")
        {
            Lane_02 = false;
        }
        else if (collision.gameObject.name == "BattleLane_03")
        {
            Lane_03 = false;
        }
    }

    void Start()
    {
        gameM = GameObject.FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisColor();
        numText.text = ""+num;

        if (leftMouseKey)
        {
            Vector2 tmpPos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(tmpPos);
            transform.position = MousePos; 
        }

        if (Input.GetMouseButtonUp(0)&& leftMouseKey)
        {
            leftMouseKey = false;
        }


    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftMouseKey = true;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) && leftMouseKey)
        {
            gameM.BulletNum = num;
            leftMouseKey = false;

            gameM.isRed = isRed;
            gameM.isGreen = isGreen;
            gameM.isBlue = isBlue;

            if (Lane_01)
            {
                Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else if (Lane_02)
            {
                Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else if (Lane_03)
            {
                Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    private void IsRed()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }

    private void IsGreen()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    private void IsBlue()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
    }

    private void IsYellow()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
    }

    private void IsMagenta()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
    }
    private void IsCyan() {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);
    }

    private void IsWhite() {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    private void ThisColor()
    {
        if (isRed && !isGreen && !isBlue)
        {
            IsRed();
        }else if (!isRed && isGreen && !isBlue)
        {
            IsGreen();
        }
        else if (!isRed && !isGreen && isBlue)
        {
            IsBlue();
        }else if(isRed && isGreen && !isBlue)
        {
            IsYellow();
        }else if (isRed && !isGreen && isBlue)
        {
            IsMagenta();
        }else if (!isRed && isGreen && isBlue)
        {
            IsCyan();
        }else if(isRed && isGreen && isBlue)
        {
            IsWhite();
        }
        else
        {
            ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
    }
}
