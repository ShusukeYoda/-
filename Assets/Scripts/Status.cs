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

    List<Status> enemys = new List<Status>
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

