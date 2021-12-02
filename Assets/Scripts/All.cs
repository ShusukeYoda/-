using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class All : MonoBehaviour
{
    Tarot tarot;
    public List<Sprite> images;    //Listｽﾌﾟﾗｲﾄ
    StoryCard SCard;
    Status status;

    //オブジェクト
    GameObject card;
    GameObject storyCard;
    GameObject Te0;
    GameObject Te1;
    GameObject Te2;
    GameObject Te3;
    GameObject Te4;
    GameObject Te5;
    GameObject Te6;
    GameObject Te7;
    GameObject Style;
    GameObject Dropdown;
    //BGM
    GameObject Audio1;
    GameObject Audio2;
    GameObject Audio3;
    //SE
    GameObject SE1;
    GameObject SE2;
    GameObject SE3;
    GameObject SE4;
    GameObject SE5;
    GameObject SE6;
    GameObject SE7;
    GameObject SE8;
    GameObject SE9;
    GameObject SE10;
    GameObject SE11;

    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    //タイマー
    public float span = 0.1f;                           //0.1秒間隔
    public float delta = 0;
    public int count = 0;
    //スタートストップ
    public bool moving = false;
    public bool one = false;

    //乱数・ボタン３用
    public int random1;
    //ストーリー進行num
    public int sNum;
    //ストーリー進行bool
    public bool walk = true;

    // Start is called before the first frame update
    void Start()
    {
        //Find
        this.card = GameObject.Find("card");
        this.storyCard = GameObject.Find("storyCard");
        this.SCard = GameObject.Find("storyCard").GetComponent<StoryCard>();
        this.status = GameObject.Find("Status").GetComponent<Status>();
        this.Te0 = GameObject.Find("Te0");
        this.Te1 = GameObject.Find("Te1");
        this.Te2 = GameObject.Find("Te2");
        this.Te3 = GameObject.Find("Te3");
        this.Te4 = GameObject.Find("Te4");
        this.Te5 = GameObject.Find("Te5");
        this.Te6 = GameObject.Find("Te6");
        this.Te7 = GameObject.Find("Te7");
        this.Style = GameObject.Find("Style");
        this.Dropdown = GameObject.Find("Dropdown");


        this.Audio1 = GameObject.Find("BGM");
        this.Audio2 = GameObject.Find("BGM1");
        this.Audio3 = GameObject.Find("BGM2");

        this.SE1 = GameObject.Find("attackDamegeSE");
        this.SE2 = GameObject.Find("criticalSE");
        this.SE3 = GameObject.Find("destroySE");
        this.SE4 = GameObject.Find("magicAttack1SE");
        this.SE5 = GameObject.Find("magicAttack2SE");
        this.SE6 = GameObject.Find("magicSE");
        this.SE7 = GameObject.Find("onePointSE");
        this.SE8 = GameObject.Find("recoverySE");
        this.SE9 = GameObject.Find("shaffleSE");
        this.SE10 = GameObject.Find("tarot&StartSE");
        this.SE11 = GameObject.Find("cardStopSE");

        this.TextTMP = GameObject.Find("TextTMP");
    }
    // Update is called once per frame


    public void OnClick()
    {
        Dropdown ddtmp;

        //「Dropdown」というGameObjectのDropDownコンポーネントを操作するために取得
        ddtmp = GameObject.Find("Dropdown").GetComponent<Dropdown>();

        //DropDownコンポーネントのoptionsから選択されてているvalueをindexで指定し、
        //選択されている文字を取得
        //string selectedvalue = ddtmp.options[ddtmp.value].text;

        CommandSelected(ddtmp.value);
    }

    bool battle = false;
    bool critical = false;

    int damage;
    int eDamage;
    int cri;

    public int enemyNum;

    public async void CommandSelected(int co)
    {
        cri = UnityEngine.Random.Range(0, 50);

        if (sNum == 1)
        {
            walk = false;

            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 2)//sNum == 2 debug
        {
            walk = false;
            enemyNum = 0;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                await Attack2();
            }
            if (co == 2 && walk == false)
            {
                await magicAttack2();
            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }

        if (sNum == 3)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする3") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける3") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る3") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }

        if (sNum == 4)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする4") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける4") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る4") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 5)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                SE7.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.magic += 10;
                Te4.GetComponent<Text>().text = tarot.magic.ToString();

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 6)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                SE6.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.luck -= 10;
                Te3.GetComponent<Text>().text = tarot.luck.ToString();

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic6();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 7)
        {
            walk = false;
            enemyNum = 1;
            battle = true;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                //ステータスバーに表記
                await PreGameOver();
                await Task.Delay(2000);
            }
            if (co == 1 && walk == false)
            {
                await Attack7();
            }
            if (co == 2 && walk == false)
            {
                await magic7Attack();
            }
            if (co == 3 && battle == false ||
                co == 3 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("立ち去る7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
        }
        if (sNum == 8)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                SE7.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.strength += 10;
                Te1.GetComponent<Text>().text = tarot.strength.ToString();                                //Te1で正しいのか

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic8();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 9)
        {
            walk = false;
            enemyNum = 2;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする9") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                battle = true;

                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }

            if (co == 1 && walk == false)
            {
                await Attack9();
            }
            if (co == 2 && battle != true ||
                co == 2 && walk == false)
            {
                await magic9Attack();

            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る9") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 10)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする10") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける10") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る10") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 11)
        {
            walk = false;
            enemyNum = 3;
            battle = true;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
            if (co == 1 && walk == false)
            {
                await Attack11();
            }
            if (co == 2 && walk == false)
            {
                await magic11Attack();

            }
            if (co == 3 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("立ち去る11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
        }
        if (sNum == 12)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする12") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける12") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る12") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 13)
        {
            walk = false;
            enemyNum = 4;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする13") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                await Attack13();
            }
            if (co == 2 && walk == false)
            {
                await magic13Attack();

            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る13") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 14)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする14") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける14") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magicRecovery();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る14") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 15)
        {
            walk = false;
            enemyNum = 5;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする15") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                await Attack15();
            }
            if (co == 2 && walk == false)
            {
                magicSleep();
            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る15") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 16)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                SE7.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.luck += 10;
                Te3.GetComponent<Text>().text = tarot.luck.ToString();

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("斬りつける16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                magic1Method();
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 17)
        {
            walk = false;
            enemyNum = 6;
            battle = true;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("話をする17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
            if (co == 1 && walk == false)
            {
                await Attack17();
            }
            if (co == 2 && walk == false)
            {
                await magic17Attack();

            }
            if (co == 3 && battle != true)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("立ち去る17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - status.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                UnityEngine.Debug.Log("チェックポイント");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
        }
        if (sNum == 18)
        {
            walk = false;
            enemyNum = 7;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする18") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                await Attack18();
            }
            if (co == 2 && walk == false)
            {
                await magic18Attack();

            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る18") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
        }
        if (sNum == 19)
        {
            walk = false;
            enemyNum = 8;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする19") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                await Attack19();
            }
            if (co == 2 && walk == false)
            {
                magicInvisible();
            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る19") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 20)
        {
            walk = false;
            enemyNum = 9;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする20") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;

            }
            if (co == 1 && walk == false)
            {
                await Attack20();
            }
            if (co == 2 && walk == false)
            {
                await magic20Attack();

            }

            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る20") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
        }
        if (sNum == 21)
        {
            walk = false;
            enemyNum = 10;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする21") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;

            }
            if (co == 1 && battle != true)
            {
                var textAsset = Resources.Load("斬りつける21a") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false && battle == true)
            {
                await Attack21b();
            }

            if (co == 2 && battle != true)
            {
                magic21();
            }
            if (co == 2 && walk == false && battle == true)
            {
                await magic21Attack();

            }
            if (co == 3 && battle != true ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る21") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
        }
    }

    private async Task PreGameOver()
    {
        tarot.hitP -= damage;

        if (tarot.hitP < 0)
        {
            tarot.hitP = 0;
        }
        Te0.GetComponent<Text>().text = tarot.hitP.ToString();

        //倒れたとき
        if (tarot.hitP <= 0)
        {
            await Task.Delay(2000);

            GameOver();
        }
    }

    private async Task Attack21b()
    {
        var textAsset = Resources.Load("斬りつける21b") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);


        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack20()
    {
        var textAsset = Resources.Load("斬りつける20") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack19()
    {
        var textAsset = Resources.Load("斬りつける19") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack18()
    {
        var textAsset = Resources.Load("斬りつける18") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack17()
    {
        var textAsset = Resources.Load("斬りつける17") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack15()
    {
        var textAsset = Resources.Load("斬りつける15") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack13()
    {
        var textAsset = Resources.Load("斬りつける13") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack11()
    {
        var textAsset = Resources.Load("斬りつける11") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack9()
    {
        var textAsset = Resources.Load("斬りつける9") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack7()
    {
        var textAsset = Resources.Load("斬りつける7") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task Attack2()
    {
        var textAsset = Resources.Load("斬りつける2") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - status.enemys[enemyNum].eDef;
            damage = status.enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        await Task.Delay(2000);

        //バトルメソッドへ
        SwBattlePre(damage, eDamage, status.enemys[enemyNum].eAgi, status.enemys[enemyNum].eHp);
    }

    private async Task magic21Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う21") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magic21()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("魔法を使う21b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic20Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う20") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magicInvisible()
    {
        if (tarot.magic >= 5)
        {
            SE6.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う19") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic18Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う18") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic17Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う17") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("魔法を使う17b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            damage = tarot.attack - status.enemys[enemyNum].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            await PreGameOver();
            await Task.Delay(2000);
        }
    }

    private void magicSleep()
    {
        if (tarot.magic >= 5)
        {
            SE6.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う15") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magicRecovery()
    {
        if (tarot.magic >= 5)
        {
            SE8.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う14") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            tarot.hitP += 10;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic13Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う13") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic11Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う11") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

            await Task.Delay(2000);
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う11b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            damage = tarot.attack - status.enemys[enemyNum].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            await PreGameOver();
            await Task.Delay(2000);
        }
    }

    private async Task magic9Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う9a") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("魔法を使う9b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            battle = true;
        }
    }

    private void magic8()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("魔法を使う8") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic7Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う7") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("魔法を使う7b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            damage = tarot.attack - status.enemys[0].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            await PreGameOver();
            await Task.Delay(2000);
        }
    }

    private void magic6()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("魔法を使う6") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magicAttack2()
    {
        if (tarot.magic >= 5)//magic >= 5 debug
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う2") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            //バトルフラグ
            battle = true;
            //2秒待ち
            await Task.Delay(2000);
            //mp消費
            tarot.magic -= 5;
            Te4.GetComponent<UnityEngine.UI.Text>().text = tarot.magic.ToString();

            //与ダメ
            eDamage = tarot.mAttack - status.enemys[enemyNum].eRes;
            status.enemys[enemyNum].eHp -= eDamage;

            if (eDamage < 0)
            {
                eDamage = 0;
            }

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";

            await Task.Delay(1000);

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magic1Method()
    {
        if (tarot.magic >= 5)
        {
            SE8.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う1") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            tarot.luck += 5;

            Te4.GetComponent<Text>().text = tarot.magic.ToString();
            Te3.GetComponent<Text>().text = tarot.luck.ToString();
            /*
            magic -= 5;     //UIテスト
            Te4.GetComponent<Text>().text = magic.ToString();
            UnityEngine.Debug.Log(magic);
            */
            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
    {

        if (tarot.agility >= eAgi)
        {
            if (critical)
            {
                SE2.GetComponent<AudioSource>().Play();
                critical = false;
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";

                //与ダメージ
                status.enemys[enemyNum].eHp -= eDamage;

                //倒したとき
                if (status.enemys[enemyNum].eHp <= 0)
                {
                    KilledBranch(enemyNum);
                }
                await Task.Delay(2000);
                SwBattlePost(damage, eDamage, eAgi, eHp);
            }

            //criticalではないとき
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
            //続行：通常
            else
            {
                SE1.GetComponent<AudioSource>().Play();
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }
        }
        else
        {
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            //ステータスバーに表記
            await PreGameOver();
            //続行：通常
            SE1.GetComponent<AudioSource>().Play();
            await Task.Delay(2000);

            SwBattlePost(damage, eDamage, eAgi, eHp);

        }
    }

    private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
    {
        if (tarot.agility >= eAgi)
        {
            if (critical)
            {
                SE2.GetComponent<AudioSource>().Play();
                critical = false;
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";

                //与ダメージ
                status.enemys[enemyNum].eHp -= eDamage;

                //倒したとき
                if (status.enemys[enemyNum].eHp <= 0)
                {
                    KilledBranch(enemyNum);
                }
                SE1.GetComponent<AudioSource>().Play();
                await Task.Delay(2000);
            }

            //criticalではないとき
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";

            //与ダメージ
            status.enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (status.enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
            SE1.GetComponent<AudioSource>().Play();
            await Task.Delay(2000);

        }
        else
        {
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";

            await PreGameOver();
            SE1.GetComponent<AudioSource>().Play();
            await Task.Delay(2000);
        }
    }

    private async void KilledBranch(int enemyNum)
    {
        SE3.GetComponent<AudioSource>().Play();
        await Task.Delay(1000);

        if (enemyNum == 0)
        {
            var textAsset = Resources.Load("battle2") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }

        if (enemyNum == 1 || enemyNum == 3)
        {
            var textAsset = Resources.Load("battle7.11") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 2)
        {
            var textAsset = Resources.Load("battle9") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 4)
        {
            var textAsset = Resources.Load("battle13") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 5)
        {
            var textAsset = Resources.Load("battle15") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 6)
        {
            var textAsset = Resources.Load("battle17") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 7)
        {
            var textAsset = Resources.Load("battle18") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 8)
        {
            var textAsset = Resources.Load("battle19") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 9)
        {
            var textAsset = Resources.Load("battle20") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 10)
        {
            var textAsset = Resources.Load("battle21") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }



        walk = true;
        battle = false;
    }
    private void GameOver()
    {
        Audio1.GetComponent<AudioSource>().Stop();
        Audio2.GetComponent<AudioSource>().Play();

        var textAsset = Resources.Load("GameOver") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        walk = true;

        storyCard.GetComponent<SpriteRenderer>().sprite = SCard.images[23];
    }
}