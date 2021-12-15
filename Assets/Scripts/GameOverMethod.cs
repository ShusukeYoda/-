using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMethod : MonoBehaviour
{
    All all;
    Tarot tarot;
    public GameObject Te0;
    GameObject Audio1;
    GameObject Audio2;
    public GameObject TextTMP;
    GameObject storyCard;
    StoryCard SCard;


    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<All>();
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.Te0 = GameObject.Find("Te0");
        this.Audio1 = GameObject.Find("BGM");
        this.Audio2 = GameObject.Find("BGM1");
        this.TextTMP = GameObject.Find("TextTMP");
        this.storyCard = GameObject.Find("storyCard");
        this.SCard = GameObject.Find("storyCard").GetComponent<StoryCard>();

    }

    public bool gameover = false;
    public async Task PreGameOver()
    {
        gameover = true;

        tarot.hitP -= all.damage;

        if (tarot.hitP < 0)
        {
            tarot.hitP = 0;
        }
        Te0.GetComponent<Text>().text = tarot.hitP.ToString();

        //“|‚ê‚½‚Æ‚«
        if (tarot.hitP <= 0)
        {
            await Task.Delay(2000);

            GameOver();
        }
    }

    private void GameOver()
    {
        Audio1.GetComponent<AudioSource>().Stop();
        Audio2.GetComponent<AudioSource>().Play();

        var textAsset = Resources.Load("GameOver") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        all.walk = true;

        storyCard.GetComponent<Image>().sprite = SCard.images[22];
    }

}
