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
 *  //�@3D�ł���TextMesh�n��TextMeshPro
    public TextMeshPro textMP;
    //�@2D�ł���UGUI�n��TextMeshPro
    public TextMeshProUGUI textMpGui;
    //�@�����̐e�ł���TMP_Text�N���X
    public TMP_Text tmp_text;

    public enum TextMeshProMode
    {
        textMP,
        textMpGui,
        tmp_text
    }

//�@�C���X�y�N�^�łǂ���g�����I�����郂�[�h
    //[SerializeField]
    //private TextMeshProMode textMeshProMode;

    // Start is called before the first frame update
 *         //�@�I���������[�h�Ŏ擾����R���|�[�l���g��ς���
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

        //�e�L�X�g�{�b�N�X�擾
        textbox_name = textMP.GetComponent<TextMeshProUGUI>();
        //�I�[�v�j���O�e�L�X�g
        StreamReader file = new StreamReader("Start");
        textbox_name.text = file.ReadToEnd();
        file.Close();
*/