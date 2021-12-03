using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

class Tarot :MonoBehaviour
{
    All all;
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
        this.all = GameObject.Find("Main Camera").GetComponent<All>();
        this.status = GameObject.Find("Status").GetComponent<Status>();
        
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
            Te0.GetComponent<Text>().text = status.select[v].hp.ToString();
            Te1.GetComponent<Text>().text = status.select[v].str.ToString();
            Te2.GetComponent<Text>().text = status.select[v].vit.ToString ();
            Te3.GetComponent<Text>().text = status.select[v].luc.ToString();
            Te4.GetComponent<Text>().text = status.select[v].mg.ToString();
            Te5.GetComponent<Text>().text = status.select[v].res.ToString();
            Te6.GetComponent<Text>().text = status.select[v].agi.ToString();
            Te7.GetComponent<Text>().text = status.select[v].dex.ToString();
            Style.GetComponent<Text>().text = status.select[v].line.ToString();
        }
        //プレイヤーステータス
        status.attack = status.select[v].str + (status.select[v].dex / 5) * (status.select[v].luc / 5);
        status.defense = status.select[v].vit + (status.select[v].dex / 5) * (status.select[v].luc / 5);
        status.mAttack = status.select[v].mg - 5 + (status.select[v].dex / 5) * (status.select[v].luc / 5);
        status.mDefense = status.select[v].res + (status.select[v].dex / 5) * (status.select[v].luc / 5);

        status.hitP = status.select[v].hp;
        status.magic = status.select[v].mg;
        status.strength = status.select[v].str;
        status.resist = status.select[v].res;
        status.agility = status.select[v].agi;
        status.luck = status.select[v].luc;
    }
}