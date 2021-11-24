using System;
using System.Collections;
using System.Collections.Generic;
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

public class Button1 : MonoBehaviour
{
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
    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    private Text text;

    public Sprite[] tarotImage;                  //配列ｽﾌﾟﾗｲﾄ 消すと消える
    public List<Sprite> images;                  //Listｽﾌﾟﾗｲﾄ

    //タイマー
    float span = 0.1f;                           //0.1秒間隔
    float delta = 0;
    int count = 0;
    //スタートストップ
    public bool moving;
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
        this.TextTMP = GameObject.Find("TextTMP");

        //battle テキストのクリア
        TextClear();
    }

    private static void TextClear()
    {
        using (var fileStream = new FileStream("Assets/Resources/battle値.txt", FileMode.Open))
        {
            fileStream.SetLength(0);
            Debug.Log("clear");
        }
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
            ChooseTarot(count);
        }
    }

    public void StartClick()
    {
        moving = true;
    }
    public void StopClick()
    {
        if (moving == true && one == false)
        {
            moving = false;
            one = true;
            walk = true;
        }
    }
    public void StoryClick()
    {
        if (one)
        {
            random1 = UnityEngine.Random.Range(1, 4);
            //int random1 = 2;   //ストーリーcardデバッグ用
            sNum += random1;

            if (sNum < 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[sNum];
                //walk = false;
            }
            else if (sNum >= 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[42];
            }
        }
    }
    public class Status : Form
    {
        public int hp;

        public int str; public int vit;

        public int mg; public int res;

        public int agi; public int dex; public int luc;

        public int eHp;

        public int eAtt; public int eDef;

        public int eRes; public int eAgi;

        public string line;
    }

    List<Status> select = new List<Status>
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30,line = "スタイルは『0 愚者』"
},
                new Status {hp = 30, str = 10, vit = 10, mg = 40, res = 30,agi = 10,dex =20,luc = 15,line = "スタイルは『I 魔術師』"},
                new Status {hp = 30, str = 15, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30,line = "スタイルは『II 女教皇』"},

                new Status {hp = 30, str = 20, vit = 15, mg = 25, res = 20,agi = 10,dex =15,luc = 15,line = "スタイルは『III 女帝』"},
                new Status {hp = 35, str = 30, vit = 20, mg = 15, res = 10,agi = 10,dex =15,luc = 15,line = "スタイルは『IV 皇帝』"},
                new Status {hp = 30, str = 10, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30,line = "スタイルは『V 教皇』"},

                new Status {hp = 35, str = 20, vit = 20, mg = 20, res = 15,agi = 15,dex =20,luc = 10,line = "スタイルは『VI 恋人』"},
                new Status {hp = 50, str = 40, vit = 30, mg = 0, res = 0,agi = 5,dex =10,luc = 10,line = "スタイルは『VII 戦車』"},
                new Status {hp = 45, str = 50, vit = 25, mg = 5, res = 5,agi = 15,dex =25,luc = 15,line = "スタイルは『VIII 力』"},
                new Status {hp = 40, str = 25, vit = 15, mg = 20, res = 15,agi = 10,dex =5,luc = 10,line = "スタイルは『IX 隠者』"},

                new Status {hp = 40, str = 30, vit = 20, mg = 25, res = 20,agi = 15,dex =15,luc = 15,line = "スタイルは『X 運命の輪』"},
                new Status {hp = 40, str = 35, vit = 20, mg = 15, res = 10,agi = 15,dex =10,luc = 10,line = "スタイルは『XI 正義』"},
                new Status {hp = 45, str = 35, vit = 20, mg = 10, res = 10,agi = 10,dex =10,luc = 5,line = "スタイルは『XII 吊された男』"},
                new Status {hp = 35, str = 45, vit = 25, mg = 20, res = 15,agi = 20,dex =20,luc = 10,line = "スタイルは『XIII 死神』"},

                new Status {hp = 45, str = 25, vit = 20, mg = 25, res = 20,agi = 15,dex =30,luc = 15,line = "スタイルは『XIV 節制』"},
                new Status {hp = 35, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =15,luc = 10,line = "スタイルは『XV 悪魔』"},
                new Status {hp = 35, str = 40, vit = 20, mg = 10, res = 10,agi = 10,dex =15,luc = 5,line = "スタイルは『XVI 塔』"},
                new Status {hp = 40, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =20,luc = 20,line = "スタイルは『XVII 星』"},

                new Status {hp = 60, str = 35, vit = 20, mg = 30, res = 25,agi = 10,dex =20,luc = 20,line = "スタイルは『XVIII 月』"},
                new Status {hp = 55, str = 40, vit = 20, mg = 35, res = 30,agi = 10,dex =20,luc = 20,line = "スタイルは『XIX 太陽』"},
                new Status {hp = 65, str = 30, vit = 15, mg = 30, res = 25,agi = 10,dex =25,luc = 25,line = "スタイルは『XX  審判』"},
                new Status {hp = 50, str = 45, vit = 25, mg = 25, res = 20,agi = 20,dex =20,luc = 20,line = "スタイルは『XXI 世界』"},
            };

    private void ChooseTarot(int v)
    {
        if (tarotImage[count]) //tarotImage[0] == 
        {
            Te0.GetComponent<Text>().text = select[v].hp.ToString();
            Te1.GetComponent<Text>().text = select[v].str.ToString();
            Te2.GetComponent<Text>().text = select[v].vit.ToString();
            Te3.GetComponent<Text>().text = select[v].luc.ToString();
            Te4.GetComponent<Text>().text = select[v].mg.ToString();
            Te5.GetComponent<Text>().text = select[v].res.ToString();
            Te6.GetComponent<Text>().text = select[v].agi.ToString();
            Te7.GetComponent<Text>().text = select[v].dex.ToString();
            Style.GetComponent<Text>().text = select[v].line.ToString();
        }
        //プレイヤーステータス
        attack = select[v].str + (select[v].dex / 5) * (select[v].luc / 5);
        defense = select[v].vit + (select[v].dex / 5) * (select[v].luc / 5);
        mAttack = select[v].mg - 5 + (select[v].dex / 5) * (select[v].luc / 5);
        mDefense = select[v].res + (select[v].dex / 5) * (select[v].luc / 5);

        hitP = select[v].hp;
        magic = select[v].mg;
        strength = select[v].str;
        resist = select[v].res;
        agility = select[v].agi;
        luck = select[v].luc;
    }
    int attack;
    int defense;
    int mAttack;
    int mDefense;
    int hitP;
    int magic;
    int strength;
    int resist;
    int agility;
    int luck;

    List<Status> enemys = new List<Status>
            {
                new Status {eHp = 30,eAtt = 35 ,eDef=5, eRes = 5, eAgi = 10},　//１騎士

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//２山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//３山賊(測)

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//４山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//５冒険者

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//６若者

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 20},　//７屈強な

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//８正規兵

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//９傭兵

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//１０正規兵ら

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10}　 //１１住人
            };


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
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("魔法を使う1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("魔法を使う0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("立ち去る1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (true)//sNum == 2 debug
        {
            enemyNum = 0;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("話をする2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                hitP = 100; //debug
                agility = 30; //debug
                attack = 50; //debug

                var textAsset = Resources.Load("斬りつける2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //バトルメソッドへ
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (true)//magic >= 5 debug
                {
                    var textAsset = Resources.Load("魔法を使う2") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    //バトルフラグ
                    battle = true;
                    //2秒待ち
                    await Task.Delay(2000);
                    //mp消費
                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    //与ダメ
                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    //テキスト書き込み
                    SaveText("Assets/Resources/battle値.txt", $"{ eDamage}ダメージを与えた\n"); 
                    //テキスト読み込み
                    var teAsBattle = Resources.Load("battle値") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = teAsBattle.ToString();

                    await Task.Delay(1000);

                    //battle テキストのクリア
                    TextClear();

                    //倒したとき
                    if (enemys[enemyNum].eHp <= 0)
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
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("立ち去る2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
    }
    public void SaveText(string path, string contents)
    {
        StreamWriter sw;
        sw = new StreamWriter(path, true);
        sw.WriteLine(contents);
        sw.Close();
        Debug.Log(path);
        Debug.Log(contents);
    }

    private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
    {

        if (agility >= eAgi)
        {
            //テキスト書き込み
            SaveText("Assets/Resources/battle値.txt", $"{ eDamage}ダメージを与えた\n"); 
            //テキスト読み込み
            var teAsBattle = Resources.Load("battle値") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = teAsBattle.ToString();

            //

            //与ダメージ
            enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (eHp <= 0)
            {
                await Task.Delay(1000);

                KilledBranch(enemyNum);
            }
            //続行：通常
            else
            {
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }
        }
        else
        {
            //テキスト書き込み
            SaveText("Assets/Resources/battle値.txt", $"{damage}ダメージを受けた\n"); 
            //テキスト読み込み
            var teAsBattle = Resources.Load("battle値") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = teAsBattle.ToString();

            //

            //ステータスバーに表記
            hitP -= damage;

            if (hitP < 0)
            {
                hitP = 0;
            }
            Te0.GetComponent<Text>().text = hitP.ToString();

            //倒れたとき
            if (hitP <= 0)
            {
                await Task.Delay(2000);

                GameOver();
            }
            //続行：通常
            else
            {
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }

        }
    }

    private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
    {
        if (agility < eAgi)
        {
            //テキスト書き込み
            SaveText("Assets/Resources/battle値.txt", $"{damage}ダメージを受けた\n"); 
            //テキスト読み込み
            var teAsBattle = Resources.Load("battle値") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = teAsBattle.ToString();

            //

            //与ダメージ
            enemys[enemyNum].eHp -= eDamage;

            //倒したとき
            if (eHp <= 0)
            {
                await Task.Delay(1000);

                KilledBranch(enemyNum);
            }

            await Task.Delay(1000);

            //battle テキストのクリア
            TextClear();

        }
        else
        {
            //テキスト書き込み
            SaveText("Assets/Resources/battle値.txt", $"{ eDamage}ダメージを与えた\n"); 
            //テキスト読み込み
            var teAsBattle = Resources.Load("battle値") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = teAsBattle.ToString();

            //

            //ステータスバーに表記
            hitP -= damage;
            if (hitP < 0)
            {
                hitP = 0;
            }
            Te0.GetComponent<Text>().text = hitP.ToString();

            //倒れたとき
            if (hitP <= 0)
            {
                await Task.Delay(2000);

                GameOver();
            }

            await Task.Delay(1000);

            //battle テキストのクリア
            TextClear();
        }
    }

    private async void KilledBranch(int enemyNum)
    {
        await Task.Delay(1000);


        if (enemyNum == 0)
        {
            var textAsset = Resources.Load("battle2") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        /*
        if (enemyNum == 1 || enemyNom == 3)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle7.11.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 2)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle9.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 4)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle13.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 5)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle15.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 6)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle17.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 7)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle18.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 8)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle19.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 9)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle20.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        if (enemyNum == 10)
        {
            StreamReader line1 = new StreamReader(@"Battle\battle21.txt");
            richTextBox1.Text = line1.ReadToEnd();
        }
        */

        //battle テキストのクリア
        TextClear();

        walk = true;
        battle = false;
    }
    private void GameOver()
    {
        var textAsset = Resources.Load("GameOver") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        walk = true;

        storyCard.GetComponent<SpriteRenderer>().sprite = images[23];
    }
}



/*
 * 
                    using StreamWriter file = new("battle値", append: true);
                    await file.WriteLineAsync($"{eDamage}ダメージを与えた\n");
*/
//Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

//File.AppendAllText("battle値", $"{eDamage}ダメージを与えた\n");
/*
StreamWriter writer =
  new StreamWriter("battle値", true);
writer.WriteLine($"{eDamage}ダメージを与えた\n");
writer.Close();                   
*/
/*
string filePath = "battle値";
StreamWriter outStream = System.IO.File.CreateText(filePath);
outStream.WriteLine($"{eDamage}ダメージを与えた\n");
outStream.Close();
*/

/*
IResourceWriter writer = new ResourceWriter("battle値");
writer.AddResource("battle値", $"{eDamage}ダメージを与えた\n");
writer.Close();
*/

//File.WriteAllBytes("battle値", $"{eDamage}ダメージを与えた\n");
//var teAsBattle = AssetDatabase.LoadAssetAtPath<TextMeshProUGUI>("battle値");
//UnityEngine.Object teAsBattle = AssetDatabase.LoadMainAssetAtPath("battle値");
/*
StreamReader at = new StreamReader(@"\battle値.txt",
Encoding.GetEncoding("Shift_JIS"), false);
richTextBox1.Text = at.ReadToEnd();
at.Close();
*/
