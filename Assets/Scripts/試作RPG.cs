using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System;

namespace 試作RPG
{

    public partial class Form1 : Form
    {


    }


    public class 試作RPG : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Form form1 = new Form();
            //formポジション
            form1.StartPosition = FormStartPosition.Manual;
            form1.Left = 700;
            form1.Top = 250;
            //サイズ
            form1.Width = 694;
            form1.Height = 348;

            form1.Show();


            Form form2 = new Form();
            form2.StartPosition = FormStartPosition.Manual;
            form2.Left = 415;
            form2.Top = 250;
            form2.Width = 301;
            form2.Height = 394;
            form2.Show();

            /*
            void OnGUI()
            {
                // ボタンを表示する
                if(
                GUI.Button(new Rect(200, 200, 100, 50), "Button"))
                {
                    Debug.Log("Button is clicked.");
                }
            }
            */
        }


        // Update is called once per frame
        void Update()
        {

        }


    }
}

/*
 *        

            void OnGUI()
            {
                if (GUI.Button(new Rect(25, 25, 100, 30), "Button"))
                {
                    // このコードは Button がクリックされたときに実行されます
                }
            }

            Bitmap animete;
 *          //GIFアニメ画像の読み込み
            animate = new Bitmap("round_white.gif");
            //フォームのPaintイベントハンドラを追加
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            //アニメ開始
            ImageAnimator.Animate(animate,
            new EventHandler(this.Image_FrameChanged));

        private void Image_FrameChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }
 */