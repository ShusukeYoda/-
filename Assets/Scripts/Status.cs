using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int hp;

    public int str; public int vit;

    public int mg; public int res;

    public int agi; public int dex; public int luc;

    public int eHp;

    public int eAtt; public int eDef;

    public int eRes; public int eAgi;

    public string line;

    public int attack;
    public int defense;
    public int mAttack;
    public int mDefense;
    public int hitP;
    public int magic;
    public int strength;
    public int resist;
    public int agility;
    public int luck;

    public List<Status> enemy = new List<Status>
            {
                new Status {eHp = 50,eAtt = 45 ,eDef=5, eRes = 5, eAgi = 10},　//１騎士

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10},　//２山賊

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 5, eAgi = 15},　//３山賊(測)

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10},　//４山賊

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 10, eAgi = 15},　//５冒険者

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 5, eAgi = 15},　//６若者

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 15, eAgi = 20},　//７屈強な

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 5, eAgi = 10},　//８正規兵

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 10, eAgi = 15},　//９傭兵

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 5, eAgi = 10},　//１０正規兵ら

                new Status {eHp = 40,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10}　 //１１住人
            };
    public List<Status> select = new List<Status>
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30,line = "スタイルは『0 愚者』"},
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
}






/*
    // BGM
    public AudioClip[] clips;
    public AudioSource[] audios;

    public TextAsset[] textasset;

        audio[2] = Audio1.GetComponent<AudioSource>();
        audio[2].Play();

 */
/*　未使用メソッド
 *　    //battle テキストのクリア
        TextClear();

    private static void TextClear()
    {
        using (var fileStream = new FileStream("Assets/Resources/battle値.txt", FileMode.Open))
        {
            fileStream.SetLength(0);
            Debug.Log("clear");
        }
    }

        //saveテキスト
    public void SaveText(string path, string contents)
    {
        StreamWriter sw;
        sw = new StreamWriter(path, true);
        sw.WriteLine(contents);
        sw.Close();
        Debug.Log(path);
        Debug.Log(contents);
    }
*/


/*　ダメージ処理の変更について
            //テキスト書き込み
            //SaveText("Assets/Resources/battle値.txt", $"{ eDamage}ダメージを与えた\n"); 
            //テキスト読み込み
            //var teAsBattle = Resources.Load("battle値") as TextAsset;
   ここのみ  TextTMP.GetComponent<TextMeshProUGUI>().text = $"{ eDamage}ダメージを与えた\n";
            //teAsBattle.ToString();
            Debug.Log("チェックポイント");
 */
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

