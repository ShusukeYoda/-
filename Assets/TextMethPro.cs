using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Windows.Forms;

public class TextMethPro : MonoBehaviour
{
    public GameObject textMP;

    private TextMeshProUGUI textbox_name;

    public void TextSet()
    {
        this.textMP = GameObject.Find("TextTMP");

        //テキストボックス取得
        textbox_name = textMP.GetComponent<TextMeshProUGUI>();
        //オープニングテキスト
        StreamReader file = new StreamReader("Start");
        textbox_name.text = file.ReadToEnd();
        file.Close();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
