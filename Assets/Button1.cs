using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    //オブジェクト
    GameObject card;

    public Sprite[] tarotImage;                  //消すと消える

    //タイマー
    float span = 0.1f;                           //0.1秒間隔
    float delta = 0;
    int count = 0;
    //スタートストップ
    public bool moving;
    public bool one = false;

    // Start is called before the first frame update
    void Start()
    {
        //Find
        this.card = GameObject.Find("card");
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
        }
    }
    public void StartClick()
    {
        moving = true;
    }
    public void StopClick()
    {
        moving = false;
        one = true;
    }
    public void StoryClick()
    {
        if (one)
        {

        }
    }

    public List<string> images;
    public void StoryCards()
    {
        images = new List<string>
        {};
    }
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