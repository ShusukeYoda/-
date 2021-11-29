using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;
using Image = UnityEngine.UI.Image;

public class Button没 : MonoBehaviour
{

    // Image コンポーネントを格納する変数
    public Image m_Image;
    // スプライトオブジェクトを格納する配列
    public Sprite[] m_Sprite;
    // スプライトオブジェクトを変更するためのフラグ
    bool change;
    //Tarotクラスインスタンス
    Tarot tarot = new Tarot();

    // Start is called before the first frame update
    void Start()
    {
        // スプライトオブジェクトを変更するためのフラグを false に設定
        change = false;
        // Image コンポーネントを取得して変数 m_Image に格納
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スプライトオブジェクトの変更フラグが true の場合
            if (change)
            {
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[0] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[0];
                change = false;
            }
            // スプライトオブジェクトの変更フラグが false の場合
            else
            {
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[1] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[1];
                change = true;
            }
        }
    }
}
            /*
        public void Click()
        {
            Tarot tarot = new Tarot();

            int[] dice = new int[22];
            int index = Random.Range(0, dice.Length);


            Sprite image = Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
            //card.ImageLocation = tarot.tarotImage[index];
        }
        */