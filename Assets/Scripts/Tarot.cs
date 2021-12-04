using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

class Tarot :MonoBehaviour
{
    CommandManager all;
    Status status;
    Text text;
    public Sprite[] tarotImage;   //配列ｽﾌﾟﾗｲﾄ 消すと消える
    
    Text Te0;
    Text Te1;
    Text Te2;
    Text Te3;
    Text Te4;
    Text Te5;
    Text Te6;
    Text Te7;
    Text Style;
    /*
    GameObject Te0;
    GameObject Te1;
    GameObject Te2;
    GameObject Te3;
    GameObject Te4;
    GameObject Te5;
    GameObject Te6;
    GameObject Te7;
    GameObject Style;
    */
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<CommandManager>();
        this.status = new Status();
        
        this.Te0 = GameObject.Find("Te0").GetComponent<Text>();
        this.Te1 = GameObject.Find("Te1").GetComponent<Text>();
        this.Te2 = GameObject.Find("Te2").GetComponent<Text>();
        this.Te3 = GameObject.Find("Te3").GetComponent<Text>();
        this.Te4 = GameObject.Find("Te4").GetComponent<Text>();
        this.Te5 = GameObject.Find("Te5").GetComponent<Text>();
        this.Te6 = GameObject.Find("Te6").GetComponent<Text>();
        this.Te7 = GameObject.Find("Te7").GetComponent<Text>();
        this.Style = GameObject.Find("Style").GetComponent<Text>();
        /*
        this.Te0 = GameObject.Find("Te0");
        this.Te1 = GameObject.Find("Te1");
        this.Te2 = GameObject.Find("Te2");
        this.Te3 = GameObject.Find("Te3");
        this.Te4 = GameObject.Find("Te4");
        this.Te5 = GameObject.Find("Te5");
        this.Te6 = GameObject.Find("Te6");
        this.Te7 = GameObject.Find("Te7");
        this.Style = GameObject.Find("Style");
        */
    }

    public void ChooseTarot(int v)
    {
        if (tarotImage[all.count]) //tarotImage[0] == 
        {
            Te0.GetComponent<Text>().text = select[v].hp.ToString();
            Te1.GetComponent<Text>().text = select[v].str.ToString();
            Te2.GetComponent<Text>().text = select[v].vit.ToString ();
            Te3.GetComponent<Text>().text = select[v].luc.ToString();
            Te4.GetComponent<Text>().text = select[v].mg.ToString();
            Te5.GetComponent<Text>().text = select[v].res.ToString();
            Te6.GetComponent<Text>().text = select[v].agi.ToString();
            Te7.GetComponent<Text>().text = select[v].dex.ToString();
            Style.GetComponent<Text>().text = select[v].line.ToString();
        }
        //プレイヤーステータス
        status.attack = select[v].str + (select[v].dex / 5) * (select[v].luc / 5);
        status.defense = select[v].vit + (select[v].dex / 5) * (select[v].luc / 5);
        status.mAttack = select[v].mg - 5 + (select[v].dex / 5) * (select[v].luc / 5);
        status.mDefense = select[v].res + (select[v].dex / 5) * (select[v].luc / 5);

        status.hitP = select[v].hp;
        status.magic = select[v].mg;
        status.strength = select[v].str;
        status.resist = select[v].res;
        status.agility = select[v].agi;
        status.luck = select[v].luc;
    }
    public List<Status> select = new List<Status>()
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30,line = "スタイルは『0 愚者』"},
                new Status {hp = 30, str = 10, vit = 10, mg = 40, res = 30,agi = 10,dex =20,luc = 15,line = "スタイルは『I 魔術師』"},
                new Status {hp = 30, str = 15, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30,line = "スタイルは『II 女教皇』"},

                new Status {hp = 30, str = 20, vit = 15, mg = 25, res = 20,agi = 10,dex =15,luc = 15,line = "スタイルは『III 女帝』"},
                new Status {hp = 35, str = 30, vit = 20, mg = 15, res = 10,agi = 10,dex =15,luc = 15,line = "スタイルは『IV 皇帝』"},
                new Status {hp = 30, str = 10, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30,line = "スタイルは『V 教皇』"},

                new Status {hp = 35, str = 20, vit = 20, mg = 20, res = 15,agi = 15,dex =20,luc = 10,line = "スタイルは『VI 恋人』"},
                new Status {hp = 50, str = 40, vit = 30, mg = 0, res = 0,agi = 5,dex =10,luc = 10,line = "スタイルは『VII 戦車』"},
                new Status {hp = 45, str = 50, vit = 25, mg = 5, res = 5,agi = 15,dex =25,luc = 15,line = "スタイルは『VIII 力』"},
                new Status {hp = 40, str = 25, vit = 15, mg = 20, res = 15,agi = 10,dex =5,luc = 10,line = "スタイルは『IX 隠者』"},

                new Status {hp = 40, str = 30, vit = 20, mg = 25, res = 20,agi = 15,dex =15,luc = 15,line = "スタイルは『X 運命の輪』"},
                new Status {hp = 40, str = 35, vit = 20, mg = 15, res = 10,agi = 15,dex =10,luc = 10,line = "スタイルは『XI 正義』"},
                new Status {hp = 45, str = 35, vit = 20, mg = 10, res = 10,agi = 10,dex =10,luc = 5,line = "スタイルは『XII 吊された男』"},
                new Status {hp = 35, str = 45, vit = 25, mg = 20, res = 15,agi = 20,dex =20,luc = 10,line = "スタイルは『XIII 死神』"},

                new Status {hp = 45, str = 25, vit = 20, mg = 25, res = 20,agi = 15,dex =30,luc = 15,line = "スタイルは『XIV 節制』"},
                new Status {hp = 35, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =15,luc = 10,line = "スタイルは『XV 悪魔』"},
                new Status {hp = 35, str = 40, vit = 20, mg = 10, res = 10,agi = 10,dex =15,luc = 5,line = "スタイルは『XVI 塔』"},
                new Status {hp = 40, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =20,luc = 20,line = "スタイルは『XVII 星』"},

                new Status {hp = 60, str = 35, vit = 20, mg = 30, res = 25,agi = 10,dex =20,luc = 20,line = "スタイルは『XVIII 月』"},
                new Status {hp = 55, str = 40, vit = 20, mg = 35, res = 30,agi = 10,dex =20,luc = 20,line = "スタイルは『XIX 太陽』"},
                new Status {hp = 65, str = 30, vit = 15, mg = 30, res = 25,agi = 10,dex =25,luc = 25,line = "スタイルは『XX  審判』"},
                new Status {hp = 50, str = 45, vit = 25, mg = 25, res = 20,agi = 20,dex =20,luc = 20,line = "スタイルは『XXI 世界』"},
            };
}