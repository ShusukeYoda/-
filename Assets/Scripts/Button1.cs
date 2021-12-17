using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    GameObject card;
    GameObject SE9;
    GameObject SE10;
    CommandSelect all;
    Tarot tarot;

    [SerializeField]
    Button button;
    void Start()
    {
        this.card = GameObject.Find("card");
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.SE9 = GameObject.Find("shaffleSE");
        this.SE10 = GameObject.Find("tarot&StartSE");
        //クラスを取得する書き方
        this.all = GameObject.Find("Main Camera").GetComponent<CommandSelect>();

        
        button = GetComponent<Button>();
        //ボタンを押下したときのリスナーを設定
        button.onClick.AddListener(TarotClick);
        
    }
    public void TarotClick()
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
}
