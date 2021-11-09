using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Drawing;

public class buttonClick2 : MonoBehaviour
{
    bool judge = false;
    // Start is called before the first frame update
    void Start()
    {
        Timer timer = new Timer();
        Tarot tarot = new Tarot();
        timer.Stop();                                           //ストップ

        GameObject card = GameObject.Find("card");
        Image image_component = card.GetComponent<Image>();
        if (judge == false)
        {
            //オーディオファイルを指定する
            //mediaPlayer.URL = "魔王魂カード決14.wav";
            //再生する
            //mediaPlayer.controls.play();

            if (card.ImageLocation == tarot.tarotImage[0])
            {
                line = "スタイルは『0 愚者』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(0);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[1])
            {
                line = "スタイルは『I 魔術師』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(1);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[2])
            {
                line = "スタイルは『II 女教皇』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(2);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[3])
            {
                line = "スタイルは『III 女帝』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(3);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[4])
            {
                line = "スタイルは『IV 皇帝』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(4);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[5])
            {
                line = "スタイルは『V 教皇』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(5);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[6])
            {
                line = "スタイルは『VI 恋人』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(6);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[7])
            {
                line = "スタイルは『VII 戦車』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(7);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[8])
            {
                line = "スタイルは『VIII 力』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(8);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[9])
            {
                line = "スタイルは『IX 隠者』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(9);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[10])
            {
                line = "スタイルは『X 運命の輪』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(10);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[11])
            {
                line = "スタイルは『XI 正義』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(11);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[12])
            {
                line = "スタイルは『XII 吊された男』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(12);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[13])
            {
                line = "スタイルは『XIII 死神』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(13);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[14])
            {
                line = "スタイルは『XIV 節制』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(14);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[15])
            {
                line = "スタイルは『XV 悪魔』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(15);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[16])
            {
                line = "スタイルは『XVI 塔』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(16);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[17])
            {
                line = "スタイルは『XVII 星』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(17);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[18])
            {
                line = "スタイルは『XVIII 月』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(18);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[19])
            {
                line = "スタイルは『XIX 太陽』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(19);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[20])
            {
                line = "スタイルは『XX  審判』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(20);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[21])
            {
                line = "スタイルは『XXI 世界』です";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(21);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
