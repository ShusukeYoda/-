using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    GameObject card;
    GameObject SE9;
    GameObject SE10;
    GameObject SE11;
    GameObject storyCard;
    GameObject TextTMP;
    GameObject Audio1;
    GameObject Audio3;
    All all;
    Tarot tarot;
    StoryCard SCard;

    Button button;
    void Start()
    {
        this.card = GameObject.Find("card");
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.SCard = GameObject.Find("storyCard").GetComponent<StoryCard>();
        this.SE9 = GameObject.Find("shaffleSE");
        this.SE10 = GameObject.Find("tarot&StartSE");
        this.SE11 = GameObject.Find("cardStopSE");
        this.storyCard = GameObject.Find("storyCard");
        this.TextTMP = GameObject.Find("TextTMP");
        this.Audio1 = GameObject.Find("BGM");
        this.Audio3 = GameObject.Find("BGM2");
        //クラスを取得する書き方
        this.all = GameObject.Find("Main Camera").GetComponent<All>();

        
        button = GetComponent<Button>();
        //ボタンを押下したときのリスナーを設定
        button.onClick.AddListener(() => StartClick());
        
    }
    public void StartClick()
    {
        SE10.GetComponent<AudioSource>().Play();
        SE9.GetComponent<AudioSource>().Play();

        all.moving = true;
    }

    void Update()
    {
        //if(true)
        if (all.moving && all.one == false)
        {
            this.all.delta += Time.deltaTime;
            if (this.all.delta > this.all.span && all.count < 21)
            {
                this.all.delta = 0;
                card.GetComponent<Image>().sprite = tarot.tarotImage[all.count];
                all.count++;
            }
            else if (this.all.delta > this.all.span && all.count == 21)
            {
                all.count = 0;
                this.all.delta = 0;
                card.GetComponent<Image>().sprite = tarot.tarotImage[all.count];
                all.count++;
            }
        }
        else if (all.moving == false && all.one == true && tarot.selected == false)
        {
            card.GetComponent<Image>().sprite = tarot.tarotImage[all.count];
            //Debug//絵柄はall.countだが能力は戦車
            //tarot.ChooseTarot(7); 
            tarot.ChooseTarot(all.count);
        }
    }


    public void StopClick()
    {
        SE11.GetComponent<AudioSource>().Play();

        if (all.moving == true && all.one == false)
        {
            all.moving = false;
            all.one = true;
            all.walk = true;
        }
    }
    int random1;
    public void StoryClick()
    {
        if (all.one && all.walk)
        {
            random1 = UnityEngine.Random.Range(1, 4);
            //int random1 = 2;   //ストーリーcardデバッグ用
            all.sNum += random1;


            if (all.sNum <= 21 && all.walk)
            {
                SE10.GetComponent<AudioSource>().Play();
                all.walk = false;
                storyCard.GetComponent<Image>().sprite = SCard.images[all.sNum];

                var textAsset = Resources.Load("image" + all.sNum) as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            else if (all.sNum >= 22 && all.walk)
            {
                SE10.GetComponent<AudioSource>().Play();
                Audio1.GetComponent<AudioSource>().Stop();
                Audio3.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("EndImage") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                storyCard.GetComponent<Image>().sprite = SCard.images[23];

                all.walk = false;
            }
        }
    }
}
