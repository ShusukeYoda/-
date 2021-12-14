using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Button3 : MonoBehaviour
{
    All all;
    StoryCard SCard;
    GameObject storyCard;
    GameObject TextTMP;
    GameObject SE10;
    GameObject Audio1;
    GameObject Audio3;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<All>();
        this.SCard = GameObject.Find("storyCard").GetComponent<StoryCard>();
        this.storyCard = GameObject.Find("storyCard");
        this.TextTMP = GameObject.Find("TextTMP");
        this.SE10 = GameObject.Find("tarot&StartSE");
        this.Audio1 = GameObject.Find("BGM");
        this.Audio3 = GameObject.Find("BGM2");

        button = GetComponent<Button>();
        //ボタンを押下したときのリスナーを設定
        button.onClick.AddListener(() => StoryClick());
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
