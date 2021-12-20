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
        //ƒNƒ‰ƒX‚ğæ“¾‚·‚é‘‚«•û
        this.all = GameObject.Find("Main Camera").GetComponent<CommandSelect>();

        
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            SE10.GetComponent<AudioSource>().Play();
            SE9.GetComponent<AudioSource>().Play();

            all.moving = true;
        });
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
            //Debug//ŠG•¿‚Íall.count‚¾‚ª”\—Í‚ÍíÔ
            //tarot.ChooseTarot(7); 
            tarot.ChooseTarot(all.count);
        }
    }
}
