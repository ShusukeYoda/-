using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Windows.Forms;

public class TextMethPro : MonoBehaviour
{
    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {

    }

    void Start()
    {
        var textAsset = Resources.Load("Start") as TextAsset;
        textMeshPro = this.GetComponent<TextMeshProUGUI>();

        textMeshPro.text = textAsset.ToString();
        Debug.Log(textAsset);

        //textMeshPro.text = ("Start");
        //GetComponent<TextMesh>().text = "Start";
    }


    // Update is called once per frame
    void Update()
    {


    }
}
// Resources.Load<TextAsset>("Start");
//textMP.text = "Start";

/*  
 *          if (!TryGetComponent(out textMeshPro)) this.enabled = false;

        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.text = "Example of text to be displayed.";
 *  
 *  //　3DであるTextMesh系のTextMeshPro
    public TextMeshPro textMP;
    //　2DであるUGUI系のTextMeshPro
    public TextMeshProUGUI textMpGui;
    //　両方の親であるTMP_Textクラス
    public TMP_Text tmp_text;

    public enum TextMeshProMode
    {
        textMP,
        textMpGui,
        tmp_text
    }

//　インスペクタでどれを使うか選択するモード
    //[SerializeField]
    //private TextMeshProMode textMeshProMode;

    // Start is called before the first frame update
 *         //　選択したモードで取得するコンポーネントを変える
        //if (textMeshProMode == TextMeshProMode.textMP)
        //{
            textMP = GetComponent<TextMeshPro>();
            textMP.SetText("<color=#ff0000>" + "aaa" + "</color>");
        //}
        //else if (textMeshProMode == TextMeshProMode.textMpGui)
        //{
            textMpGui = GetComponent<TextMeshProUGUI>();
            textMpGui.SetText("<color=#00ff00>" + "bbb" + "</color>");
        //}
        //else if (textMeshProMode == TextMeshProMode.tmp_text)
        //{
            tmp_text = GetComponent<TMP_Text>();
            tmp_text.SetText("<color=#0000ff>" + "ccc" + "</color>");
        //}


        this.textMP = GameObject.Find("TextTMP");

        //テキストボックス取得
        textbox_name = textMP.GetComponent<TextMeshProUGUI>();
        //オープニングテキスト
        StreamReader file = new StreamReader("Start");
        textbox_name.text = file.ReadToEnd();
        file.Close();
*/