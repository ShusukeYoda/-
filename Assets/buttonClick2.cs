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
        timer.Stop();                                           //�X�g�b�v

        GameObject card = GameObject.Find("card");
        Image image_component = card.GetComponent<Image>();
        if (judge == false)
        {
            //�I�[�f�B�I�t�@�C�����w�肷��
            //mediaPlayer.URL = "�������J�[�h��14.wav";
            //�Đ�����
            //mediaPlayer.controls.play();

            if (card.ImageLocation == tarot.tarotImage[0])
            {
                line = "�X�^�C���́w0 ���ҁx�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(0);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[1])
            {
                line = "�X�^�C���́wI ���p�t�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(1);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[2])
            {
                line = "�X�^�C���́wII �����c�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(2);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[3])
            {
                line = "�X�^�C���́wIII ����x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(3);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[4])
            {
                line = "�X�^�C���́wIV �c��x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(4);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[5])
            {
                line = "�X�^�C���́wV ���c�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(5);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[6])
            {
                line = "�X�^�C���́wVI ���l�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(6);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[7])
            {
                line = "�X�^�C���́wVII ��ԁx�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(7);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[8])
            {
                line = "�X�^�C���́wVIII �́x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(8);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[9])
            {
                line = "�X�^�C���́wIX �B�ҁx�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(9);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[10])
            {
                line = "�X�^�C���́wX �^���̗ցx�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(10);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[11])
            {
                line = "�X�^�C���́wXI ���`�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(11);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[12])
            {
                line = "�X�^�C���́wXII �݂��ꂽ�j�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(12);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[13])
            {
                line = "�X�^�C���́wXIII ���_�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(13);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[14])
            {
                line = "�X�^�C���́wXIV �ߐ��x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(14);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[15])
            {
                line = "�X�^�C���́wXV �����x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(15);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[16])
            {
                line = "�X�^�C���́wXVI ���x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(16);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[17])
            {
                line = "�X�^�C���́wXVII ���x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(17);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[18])
            {
                line = "�X�^�C���́wXVIII ���x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(18);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[19])
            {
                line = "�X�^�C���́wXIX ���z�x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(19);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[20])
            {
                line = "�X�^�C���́wXX  �R���x�ł�";
                PlayerStyle.Text = line;
                judge = true;
                TarotChoose(20);
            }
            if (pictureBox1.ImageLocation == tarot.tarotImage[21])
            {
                line = "�X�^�C���́wXXI ���E�x�ł�";
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
