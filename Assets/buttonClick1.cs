using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Windows.Forms;
using System;
using Timer = System.Timers.Timer;
using Random = UnityEngine.Random;
using System.Windows.Forms;


public class buttonClick1 : MonoBehaviour
{
    public int count; 
    public bool judge;
    int random1 = Random.Range(0, 22);

    // Start is called before the first frame update
    void Start()
    {

        if (judge == false)
        {
            //�I�[�f�B�I�t�@�C�����w�肷��
            //mediaPlayer.URL = "��������12.wav";
            //�Đ�����
            //mediaPlayer.controls.play();

            /*
            Timer timer = new Timer();
            //�^���b�g�p�^�C�}�[
            timer.Start();                                           //�X�^�[�g

            timer.Interval = 100;
            //timer.Tick += OnTimer1;                                 //�I���^�C�}�[
            */
        }
    }

    private void OnTimer1()
    {
        if (judge == false)
        {
            Tarot tarot = new Tarot();
            int num = random1;
            .ImageLocation = tarot.tarotImage[num];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //OnTimer1();
    }
}


