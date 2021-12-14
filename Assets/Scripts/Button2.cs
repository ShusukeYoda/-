using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    All all;
    GameObject SE11;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<All>();
        this.SE11 = GameObject.Find("cardStopSE");

        button = GetComponent<Button>();
        //ボタンを押下したときのリスナーを設定
        button.onClick.AddListener(() => StopClick());
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
}
