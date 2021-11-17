using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Button1 : MonoBehaviour
{
    //オブジェクト
    GameObject card;
    GameObject storyCard;
    GameObject Te0;
    GameObject Te1;
    GameObject Te2;
    GameObject Te3;
    GameObject Te4;
    GameObject Te5;
    GameObject Te6;
    GameObject Te7;

    private Text text;

    public Sprite[] tarotImage;                  //配列ｽﾌﾟﾗｲﾄ 消すと消える
    public List<Sprite> images;                  //Listｽﾌﾟﾗｲﾄ

    //タイマー
    float span = 0.1f;                           //0.1秒間隔
    float delta = 0;
    int count = 0;
    //スタートストップ
    public bool moving;
    public bool one = false;

    //乱数・ボタン３用
    public int random1;
    //ストーリー進行num
    public int sNum;
    //ストーリー進行bool
    public bool walk = true;

    // Start is called before the first frame update
    void Start()
    {
        //Find
        this.card = GameObject.Find("card");
        this.storyCard = GameObject.Find("storyCard");
        this.Te0 = GameObject.Find("Te0");
        this.Te1 = GameObject.Find("Te1");
        this.Te2 = GameObject.Find("Te2");
        this.Te3 = GameObject.Find("Te3");
        this.Te4 = GameObject.Find("Te4");
        this.Te5 = GameObject.Find("Te5");
        this.Te6 = GameObject.Find("Te6");
        this.Te7 = GameObject.Find("Te7");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && one == false)
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span && count < 21)
            {
                this.delta = 0;
                card.GetComponent<SpriteRenderer>().sprite = tarotImage[count];
                count++;
            }
            else if (this.delta > this.span && count == 21)
            {
                count = 0;
                this.delta = 0;
                card.GetComponent<SpriteRenderer>().sprite = tarotImage[count];
                count++;
            }
        }
        else if (moving == false && one == true)
        {
            card.GetComponent<SpriteRenderer>().sprite = tarotImage[count];
            ChooseTarot(count);
        }
    }

    public void StartClick()
    {
        moving = true;
    }
    public void StopClick()
    {
        if (moving == true && one == false)
        {
            moving = false;
            one = true;
            walk = true;
        }
    }
    public void StoryClick()
    {
        if (one)
        {
            random1 = Random.Range(1, 4);
            //int random1 = 2;   //ストーリーcardデバッグ用
            sNum += random1;

            if (sNum < 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[sNum];
                //walk = false;
            }
            else if (sNum >= 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[42];
            }
        }
    }

    public class Status
    {
        public int hp;

        public int str; public int vit;

        public int mg; public int res;

        public int agi; public int dex; public int luc;

        //public int wt = 510; //WT = クラス基本値+510-AGI+装備重量

        public int eHp;

        public int eAtt; public int eDef;

        public int eRes; public int eAgi;

    }

    List<Status> select = new List<Status>
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30},
                new Status {hp = 30, str = 10, vit = 10, mg = 40, res = 30,agi = 10,dex =20,luc = 15},
                new Status {hp = 30, str = 15, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30},

                new Status {hp = 30, str = 20, vit = 15, mg = 25, res = 20,agi = 10,dex =15,luc = 15},
                new Status {hp = 35, str = 30, vit = 20, mg = 15, res = 10,agi = 10,dex =15,luc = 15},
                new Status {hp = 30, str = 10, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30},

                new Status {hp = 35, str = 20, vit = 20, mg = 20, res = 15,agi = 15,dex =20,luc = 10},
                new Status {hp = 50, str = 40, vit = 30, mg = 0, res = 0,agi = 5,dex =10,luc = 10},
                new Status {hp = 45, str = 50, vit = 25, mg = 5, res = 5,agi = 15,dex =25,luc = 15},
                new Status {hp = 40, str = 25, vit = 15, mg = 20, res = 15,agi = 10,dex =5,luc = 10},

                new Status {hp = 40, str = 30, vit = 20, mg = 25, res = 20,agi = 15,dex =15,luc = 15},
                new Status {hp = 40, str = 35, vit = 20, mg = 15, res = 10,agi = 15,dex =10,luc = 10},
                new Status {hp = 45, str = 35, vit = 20, mg = 10, res = 10,agi = 10,dex =10,luc = 5},
                new Status {hp = 35, str = 45, vit = 25, mg = 20, res = 15,agi = 20,dex =20,luc = 10},

                new Status {hp = 45, str = 25, vit = 20, mg = 25, res = 20,agi = 15,dex =30,luc = 15},
                new Status {hp = 35, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =15,luc = 10},
                new Status {hp = 35, str = 40, vit = 20, mg = 10, res = 10,agi = 10,dex =15,luc = 5},
                new Status {hp = 40, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =20,luc = 20},

                new Status {hp = 60, str = 35, vit = 20, mg = 30, res = 25,agi = 10,dex =20,luc = 20},
                new Status {hp = 55, str = 40, vit = 20, mg = 35, res = 30,agi = 10,dex =20,luc = 20},
                new Status {hp = 65, str = 30, vit = 15, mg = 30, res = 25,agi = 10,dex =25,luc = 25},
                new Status {hp = 50, str = 45, vit = 25, mg = 25, res = 20,agi = 20,dex =20,luc = 20},
            };

    private void ChooseTarot(int v)
    {
        if (tarotImage[count]) //tarotImage[0] == 
        {
            //StreamReader file = new StreamReader(@"Status\初期パラメータ0.txt");
            //richTextBox1.Text = file.ReadToEnd();
            //file.Close();

            Te0.GetComponent<Text>().text = select[v].hp.ToString();
            Te1.GetComponent<Text>().text = select[v].str.ToString();
            Te2.GetComponent<Text>().text = select[v].vit.ToString();
            Te3.GetComponent<Text>().text = select[v].luc.ToString();
            Te4.GetComponent<Text>().text = select[v].mg.ToString();
            Te5.GetComponent<Text>().text = select[v].res.ToString();
            Te6.GetComponent<Text>().text = select[v].agi.ToString();
            Te7.GetComponent<Text>().text = select[v].dex.ToString();
        }
        //プレイヤーステータス
        attack = select[v].str + (select[v].dex / 5) * (select[v].luc / 5);
        defense = select[v].vit + (select[v].dex / 5) * (select[v].luc / 5);
        mAttack = select[v].mg - 5 + (select[v].dex / 5) * (select[v].luc / 5);
        mDefense = select[v].res + (select[v].dex / 5) * (select[v].luc / 5);

        hitP = select[v].hp;
        magic = select[v].mg;
        strength = select[v].str;
        resist = select[v].res;
        agility = select[v].agi;
        luck = select[v].luc;
    }
    int attack;
    int defense;
    int mAttack;
    int mDefense;
    int hitP;
    int magic;
    int strength;
    int resist;
    int agility;
    int luck;

    List<Status> enemys = new List<Status>
            {
                new Status {eHp = 30,eAtt = 35 ,eDef=5, eRes = 5, eAgi = 10},　//１騎士

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//２山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//３山賊(測)

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//４山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//５冒険者

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//６若者

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 20},　//７屈強な

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//８正規兵

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//９傭兵

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//１０正規兵ら

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10}　 //１１住人
            };
}











//画像ファイルを読み込んで、Imageオブジェクトを作成する
//System.Drawing.Image img = System.Drawing.Image.FromFile("Images/66px-RWS_Tarot_08_Strength");

/*
GameObject card;
Tarot tarot = new Tarot();
int[] dice = new int[22];


this.card = GameObject.Find("card");
card.GetComponent<Tarot>();
*/

//int index = Random.Range(0, dice.Length);
//card = Resources.Load < Sprite > "Images/66px-RWS_Tarot_08_Strength";

//tarot.tarotImage[index];

//Sprite sprite;
//= Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
//tarot.tarotImage[index];

/*
Tarot tarot = new Tarot();

int[] dice = new int[22];
int index = Random.Range(0, dice.Length);

Sprite[] sprites = Resources.LoadAll<Sprite>("Images");
*/


//Sprite image = Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
//card.ImageLocation = tarot.tarotImage[index];