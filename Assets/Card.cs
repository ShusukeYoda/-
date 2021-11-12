using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Timers;
using System;
using Random = UnityEngine.Random;
//using System.Windows.Forms;

public class Card : MonoBehaviour
{

    //オブジェクト
    GameObject cards;
    //スプライト
    public Sprite[] tarotImage;                  // [22];
    //タイマー
    Timer timer;
    
    //乱数
    //Random random1 = Random.Range(0, 21);

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
       //Find
        this.cards = GameObject.Find("card");

        timer = new Timer();
        timer.Interval = 100;
        timer.Elapsed += new ElapsedEventHandler(onTimer);
        timer.Start();
    }
    // Update is called once per frame
    void Update()
    {
        //cards.GetComponent<SpriteRenderer>().sprite = tarot[0];
    }
    void onTimer(object source, ElapsedEventArgs e)
    {
        //random1 = Random.Range(0, 21);
        Debug.Log("test");
        
        cards.GetComponent<SpriteRenderer>().sprite = tarotImage[count];

        if (count <= 22)
        {
            count++;
        }
        else
        {
            count = 0;
        }
    }
    private void OnDisable()
    {
        timer.Dispose();
    }
}

/*
       tarotImage[0] = 69px - RWS_Tarot_00_Fool;
        tarotImage[1] = "68px-RWS_Tarot_01_Magician";
        tarotImage[2] = "69px-RWS_Tarot_02_High_Priestess";
        tarotImage[3] = "69px-RWS_Tarot_03_Empress";
        tarotImage[4] = "70px-RWS_Tarot_04_Emperor";
        tarotImage[5] = "68px-RWS_Tarot_05_Hierophant";
        tarotImage[6] = "69px-RWS_Tarot_06_Lovers";
        tarotImage[7] = "68px-RWS_Tarot_07_Chariot";
        tarotImage[8] = "66px-RWS_Tarot_08_Strength";
        tarotImage[9] = "69px-RWS_Tarot_09_Hermit";
        tarotImage[10] = "69px-RWS_Tarot_10_Wheel_of_Fortune";
        tarotImage[11] = "69px-RWS_Tarot_11_Justice";
        tarotImage[12] = "68px-RWS_Tarot_12_Hanged_Man";
        tarotImage[13] = "68px-RWS_Tarot_13_Death";
        tarotImage[14] = "69px-RWS_Tarot_14_Temperance";
        tarotImage[15] = "69px-RWS_Tarot_15_Devil";
        tarotImage[16] = "70px-RWS_Tarot_16_Tower";
        tarotImage[17] = "69px-RWS_Tarot_17_Star";
        tarotImage[18] = "68px-RWS_Tarot_18_Moon";
        tarotImage[19] = "69px-RWS_Tarot_19_Sun";
        tarotImage[20] = "69px-RWS_Tarot_20_Judgement";
        tarotImage[21] = "68px-RWS_Tarot_21_World";
*/

/*      
 *      
 *      

    //public event EventHandler Tick;
 *      
 *      
 *      //タイマー
        //
        //
        //timer.Tick += onTimer;
        //
        //timer.Enabled = true;

 *    
 *    
 *    public int timer;
 *         timer += Time.deltaTime;
        if (timer >= 3f)
        {
            Hoge();
        }
 */
//Timer timer = new Timer();


//public string[] tarotImage;
//tarotImage = new string[22];
/*
tarotImage[0] = 69px-RWS_Tarot_00_Fool;
tarotImage[1] = "68px-RWS_Tarot_01_Magician";
tarotImage[2] = "69px-RWS_Tarot_02_High_Priestess";
tarotImage[3] = "69px-RWS_Tarot_03_Empress";
tarotImage[4] = "70px-RWS_Tarot_04_Emperor";
tarotImage[5] = "68px-RWS_Tarot_05_Hierophant";
tarotImage[6] = "69px-RWS_Tarot_06_Lovers";
tarotImage[7] = "68px-RWS_Tarot_07_Chariot";
tarotImage[8] = "66px-RWS_Tarot_08_Strength";
tarotImage[9] = "69px-RWS_Tarot_09_Hermit";
tarotImage[10] = "69px-RWS_Tarot_10_Wheel_of_Fortune";
tarotImage[11] = "69px-RWS_Tarot_11_Justice";
tarotImage[12] = "68px-RWS_Tarot_12_Hanged_Man";
tarotImage[13] = "68px-RWS_Tarot_13_Death";
tarotImage[14] = "69px-RWS_Tarot_14_Temperance";
tarotImage[15] = "69px-RWS_Tarot_15_Devil";
tarotImage[16] = "70px-RWS_Tarot_16_Tower";
tarotImage[17] = "69px-RWS_Tarot_17_Star";
tarotImage[18] = "68px-RWS_Tarot_18_Moon";
tarotImage[19] = "69px-RWS_Tarot_19_Sun";
tarotImage[20] = "69px-RWS_Tarot_20_Judgement";
tarotImage[21] = "68px-RWS_Tarot_21_World";
*/


//Sprite sp = Resources.Load<Sprite>(tarotImage[0]);


//cards.AddComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
//cards.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
//cards.AddComponent<Image>().sprite = Resources.Load<Sprite>(tarotImage[0]);


//= new GameObject("card");
/*
 *         //card.AddComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        card.AddComponent<Image>().sprite = Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
 * 
 * 
 *     Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;

 * public class Card : MonoBehaviour
{
    Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press space to change the Sprite of the Image
        if (Input.GetKey(KeyCode.Space))
        {
            m_Image.sprite = m_Sprite;
        }
    }
}
 */