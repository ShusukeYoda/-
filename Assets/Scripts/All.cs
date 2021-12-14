using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using Debug = UnityEngine.Debug;
using Image = UnityEngine.UI.Image;
using Text = UnityEngine.UI.Text;

public class All : MonoBehaviour
{
    Tarot tarot;
    public List<Sprite> images;    //List���ײ�
    StoryCard SCard;

    //�I�u�W�F�N�g
    GameObject storyCard;
    public GameObject Te0;
    GameObject Te1;
    GameObject Te2;
    GameObject Te3;
    public GameObject Te4;
    GameObject Te5;
    GameObject Te6;
    GameObject Te7;
    GameObject Style;

    //BGM
    GameObject Audio1;
    GameObject Audio2;
    GameObject Audio3;
    //SE
    GameObject SE1;
    GameObject SE2;
    GameObject SE3;
    GameObject SE4;
    GameObject SE5;
    GameObject SE6;
    GameObject SE7;
    GameObject SE8;

    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    //�^�C�}�[//0.1�b�Ԋu
    public float span = 0.1f;
    public float delta = 0;
    public int count = 0;
    //�X�^�[�g�X�g�b�v
    public bool moving = false;
    public bool one = false;

    //�����E�{�^���R�p
    public int random1;
    //�X�g�[���[�i�snum
    public int sNum;
    //�X�g�[���[�i�sbool
    public bool walk = true;

    // Start is called before the first frame update
    void Start()
    {
        //Find
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.storyCard = GameObject.Find("storyCard");
        this.SCard = GameObject.Find("storyCard").GetComponent<StoryCard>();
        this.Te0 = GameObject.Find("Te0");
        this.Te1 = GameObject.Find("Te1");
        this.Te2 = GameObject.Find("Te2");
        this.Te3 = GameObject.Find("Te3");

        this.Te4 = GameObject.Find("Te4");
        this.Te5 = GameObject.Find("Te5");
        this.Te6 = GameObject.Find("Te6");
        this.Te7 = GameObject.Find("Te7");
        this.Style = GameObject.Find("Style");

        this.Audio1 = GameObject.Find("BGM");
        this.Audio2 = GameObject.Find("BGM1");
        this.Audio3 = GameObject.Find("BGM2");

        this.SE1 = GameObject.Find("attackDamegeSE");
        this.SE2 = GameObject.Find("criticalSE");
        this.SE3 = GameObject.Find("destroySE");
        this.SE4 = GameObject.Find("magicAttack1SE");
        this.SE5 = GameObject.Find("magicAttack2SE");
        this.SE6 = GameObject.Find("magicSE");
        this.SE7 = GameObject.Find("onePointSE");
        this.SE8 = GameObject.Find("recoverySE");

        this.TextTMP = GameObject.Find("TextTMP");

        Audio1.GetComponent<AudioSource>().Play();
    }



    List<Status> enemys = new List<Status>
            {
                new Status {eHp = 50,eAtt = 45 ,eDef=5, eRes = 5, eAgi = 10},�@//�P�R�m

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10},�@//�Q�R��

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 5, eAgi = 15},�@//�R�R��(��)

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10},�@//�S�R��

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 10, eAgi = 15},�@//�T�`����

                new Status {eHp = 50,eAtt = 50 ,eDef=15, eRes = 5, eAgi = 15},�@//�U���

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 15, eAgi = 20},�@//�V������

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 5, eAgi = 10},�@//�W���K��

                new Status {eHp = 55,eAtt = 50 ,eDef=15, eRes = 10, eAgi = 15},�@//�X�b��

                new Status {eHp = 60,eAtt = 55 ,eDef=15, eRes = 5, eAgi = 10},�@//�P�O���K����

                new Status {eHp = 40,eAtt = 50 ,eDef=15, eRes = 0, eAgi = 10}�@ //�P�P�Z�l
            };

    bool battle = false;
    bool critical = false;

    int damage;
    int eDamage;
    int cri;

    public int enemyNum;

    public async void CommandSelected(int command)
    {
        cri = UnityEngine.Random.Range(0, 50);

        if (sNum == 1)
        {
            common_method(command);
        }
        if (sNum == 2)//sNum == 2 debug
        {
            walk = false;
            enemyNum = 0;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicAttack2(tarot.magic);
            }
            if (command == 3 && battle != true)
            {
                Leave();
            }
        }

        if (sNum == 3)
        {
            common_method(command);
        }

        if (sNum == 4)
        {
            common_method(command);
        }
        if (sNum == 5)
        {
            walk = false;
            if (command == 0 && walk == false)
            {
                SE7.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.magic += 10;
                Te4.GetComponent<Text>().text = tarot.magic.ToString();

                walk = true;
            }
            if (command == 1 && walk == false)
            {
                NonBattle();
            }
            if (command == 2 && walk == false)
            {
                magic1Method();
            }
            if (command == 3 && walk == false)
            {
                Leave();
            }
        }
        if (sNum == 6)
        {
            walk = false;
            if (command == 0 && walk == false)
            {
                SE6.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.luck -= 10;
                Te3.GetComponent<Text>().text = tarot.luck.ToString();

                walk = true;
            }
            if (command == 1 && walk == false)
            {
                NonBattle();
            }
            if (command == 2 && walk == false)
            {
                magic6();
            }
            if (command == 3 && walk == false)
            {
                Leave();
            }
        }
        if (sNum == 7)
        {
            walk = false;
            enemyNum = 1;
            battle = true;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                await PreGameOver();
                await Task.Delay(2000);
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magic7Attack();
            }
            if (command == 3 && battle == false ||
                command == 3 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("��������7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
        }
        if (sNum == 8)
        {
            walk = false;
            if (command == 0 && walk == false)
            {
                SE7.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.strength += 10;
                Te1.GetComponent<Text>().text = tarot.strength.ToString();                                //Te1�Ő������̂�

                walk = true;
            }
            if (command == 1 && walk == false)
            {
                NonBattle();
            }
            if (command == 2 && walk == false)
            {
                magic8();
            }
            if (command == 3 && walk == false)
            {
                Leave();
            }
        }
        if (sNum == 9)
        {
            walk = false;
            enemyNum = 2;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������9") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                battle = true;

                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }

            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && battle != true ||
                command == 2 && walk == false)
            {
                await magic9Attack();

            }
            if (command == 3 && battle != true)
            {
                Leave();
            }
        }
        if (sNum == 10)
        {
            common_method(command);
        }
        if (sNum == 11)
        {
            walk = false;
            enemyNum = 3;
            battle = true;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magic11Attack();

            }
            if (command == 3 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("��������11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
        }
        if (sNum == 12)
        {
            common_method(command);
        }
        if (sNum == 13)
        {
            walk = false;
            enemyNum = 4;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������13") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magic13Attack();

            }
            if (command == 3 && battle != true)
            {
                Leave();
            }
        }
        if (sNum == 14)
        {
            walk = false;

            if (command == 0 && walk == false)
            {
                var textAsset = Resources.Load($"�b������{sNum}") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (command== 1 && walk == false)
            {
                var textAsset = Resources.Load($"�a�����{sNum}") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (command== 2 && walk == false)
            {
                magicRecovery();
            }
            if (command== 3 && walk == false)
            {
                var textAsset = Resources.Load($"��������{sNum}") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 15)
        {
            walk = false;
            enemyNum = 5;
            if (command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������15") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                magicSleep();
            }
            if (command == 3 && battle != true)
            {
                Leave();
            }
        }
        if (sNum == 16)
        {
            walk = false;
            if (command == 0 && walk == false)
            {
                SE7.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                tarot.luck += 10;
                Te3.GetComponent<Text>().text = tarot.luck.ToString();

                walk = true;
            }
            if (command == 1 && walk == false)
            {
                NonBattle();
            }
            if (command == 2 && walk == false)
            {
                magic1Method();
            }
            if (command == 3 && walk == false)
            {
                Leave();
            }
        }
        if (sNum == 17)
        {
            walk = false;
            enemyNum = 6;
            battle = true;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("�b������17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magic17Attack();

            }
            if (command == 3 && battle != true)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("��������17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await PreGameOver();
                await Task.Delay(2000);
            }
        }
        if (sNum == 18)
        {
            walk = false;
            enemyNum = 7;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������18") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magic18Attack();

            }
            if (command == 3 && battle != true)
            {
                Leave();
            }
        }
        if (sNum == 19)
        {
            walk = false;
            enemyNum = 8;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������19") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                magicInvisible();
            }
            if (command == 3 && battle != true)
            {
                Leave();
            }
        }
        if (sNum == 20)
        {
            walk = false;
            enemyNum = 9;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������20") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;

            }
            if (command == 1 && walk == false)
            {
                 Attack();
            }
            if (command == 2 && walk == false)
            {
                await magic20Attack();

            }

            if (command == 3 && battle != true)
            {
                Leave();
            }
        }
        if (sNum == 21)
        {
            walk = false;
            enemyNum = 10;
            if (command == 0 && battle == false ||
                command == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������21") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;

            }
            if (command == 1 && battle != true)
            {
                var textAsset = Resources.Load("�a�����21a") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (command == 1 && walk == false && battle == true)
            {
                 Attack();
            }

            if (command == 2 && battle != true)
            {
                magic21();
            }
            if (command == 2 && walk == false && battle == true)
            {
                await magic21Attack();

            }
            if (command == 3 && battle != true ||
                command == 0 && walk == false)
            {
                Leave();
            }
        }
    }

    private void NonBattle()
    {
        var textAsset = Resources.Load($"�a�����{sNum}") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
    }

    private void Leave()
    {
        var textAsset = Resources.Load($"��������{sNum}") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        walk = true;
    }

    private void common_method(int command)
    {
        walk = false;

        if (command== 0 && walk == false)
        {
            var textAsset = Resources.Load($"�b������{sNum}") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (command== 1 && walk == false)
        {
            var textAsset = Resources.Load($"�a�����{sNum}") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (command== 2 && walk == false)
        {
            magic1Method();
        }
        if (command== 3 && walk == false)
        {
            var textAsset = Resources.Load($"��������{sNum}") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            walk = true;
        }
    }

    private void Attack()
    {
        var textAsset = Resources.Load($"�a�����{sNum}") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        battle = true;

        if (cri <= tarot.luck)
        {
            critical = true;

            eDamage = tarot.attack * 2 - enemys[enemyNum].eDef;
            damage = enemys[enemyNum].eAtt - tarot.defense;
        }
        else
        {
            eDamage = tarot.attack - enemys[enemyNum].eDef;
            damage = enemys[enemyNum].eAtt - tarot.defense;
        }

        if (damage < 0)
        {
            damage = 0;
        }

        //�o�g�����\�b�h��
        SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
    }

    private async Task magic21Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��21") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magic21()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("���@���g��21b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic20Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��20") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magicInvisible()
    {
        if (tarot.magic >= 5)
        {
            SE6.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��19") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic18Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��18") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic17Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��17") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("���@���g��17b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            damage = tarot.attack - enemys[enemyNum].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            await PreGameOver();
            await Task.Delay(2000);
        }
    }

    private void magicSleep()
    {
        if (tarot.magic >= 5)
        {
            SE6.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��15") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magicRecovery()
    {
        if (tarot.magic >= 5)
        {
            SE8.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��14") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            tarot.hitP += 10;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic13Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��13") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic11Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��11") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

            await Task.Delay(2000);
        }
        else
        {
            var textAsset = Resources.Load("���@���g��11b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            damage = tarot.attack - enemys[enemyNum].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            await PreGameOver();
            await Task.Delay(2000);
        }
    }

    private async Task magic9Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��9a") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("���@���g��9b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            battle = true;
        }
    }

    private void magic8()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("���@���g��8") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magic7Attack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��7") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }

        }
        else
        {
            var textAsset = Resources.Load("���@���g��7b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            damage = tarot.attack - enemys[0].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            await PreGameOver();
            await Task.Delay(2000);
        }
    }

    private void magic6()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("���@���g��6") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async Task magicAttack2(int magic)
    {
        if (tarot.magic >= 5)//magic >= 5 debug
        {
            SE4.GetComponent<AudioSource>().Play();

            //mp����
            tarot.magic -= 5;
            Te4.GetComponent<UnityEngine.UI.Text>().text = magic.ToString();

            var textAsset = Resources.Load("���@���g��2") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            //�o�g���t���O
            battle = true;
            //2�b�҂�
            await Task.Delay(2000);

            //�^�_��
            eDamage = tarot.mAttack - enemys[enemyNum].eRes;
            enemys[enemyNum].eHp -= eDamage;

            if (eDamage < 0)
            {
                eDamage = 0;
            }

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";

            await Task.Delay(1000);

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private void magic1Method()
    {
        if (tarot.magic >= 5)
        {
            SE8.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("���@���g��1") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            tarot.luck += 5;

            Te4.GetComponent<Text>().text = tarot.magic.ToString();
            Te3.GetComponent<Text>().text = tarot.luck.ToString();
            /*
            magic -= 5;     //UI�e�X�g
            Te4.GetComponent<Text>().text = magic.ToString();
            UnityEngine.Debug.Log(magic);
            */
            walk = true;
        }
        else
        {
            var textAsset = Resources.Load("���@���g��0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
    {

        if (tarot.agility >= eAgi)
        {
            if (critical)
            {
                SE2.GetComponent<AudioSource>().Play();
                critical = false;
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";

                //�^�_���[�W
                enemys[enemyNum].eHp -= eDamage;
                Te0.GetComponent<Text>().text = tarot.hitP.ToString();

                //�|�����Ƃ�
                if (enemys[enemyNum].eHp <= 0)
                {
                    KilledBranch(enemyNum);
                }
                await Task.Delay(2000);
                SwBattlePost(damage, eDamage, eAgi, eHp);
            }

            //critical�ł͂Ȃ��Ƃ�
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
            //���s�F�ʏ�
            else
            {
                SE1.GetComponent<AudioSource>().Play();
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }
        }
        else
        {
            SE1.GetComponent<AudioSource>().Play();

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            //�X�e�[�^�X�o�[�ɕ\�L
            await PreGameOver();

            if (gameover == false)
            {
                //���s�F�ʏ�
                SE1.GetComponent<AudioSource>().Play();
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }
        }
    }

    private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
    {
        if (tarot.agility >= eAgi)
        {
            if (critical)
            {
                SE2.GetComponent<AudioSource>().Play();
                critical = false;
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";

                //�^�_���[�W
                enemys[enemyNum].eHp -= eDamage;
                Te0.GetComponent<Text>().text = tarot.hitP.ToString();

                //�|�����Ƃ�
                if (enemys[enemyNum].eHp <= 0)
                {
                    KilledBranch(enemyNum);
                }
                SE1.GetComponent<AudioSource>().Play();
                await Task.Delay(2000);
            }

            //critical�ł͂Ȃ��Ƃ�
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                KilledBranch(enemyNum);
            }
            SE1.GetComponent<AudioSource>().Play();
            await Task.Delay(2000);

        }
        else
        {
            SE1.GetComponent<AudioSource>().Play();

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            await PreGameOver();
            if (gameover == false)
            {
                await Task.Delay(2000);
            }
        }
    }

    private async void KilledBranch(int enemyNum)
    {
        SE3.GetComponent<AudioSource>().Play();
        await Task.Delay(1000);

        if (enemyNum == 0)
        {
            var textAsset = Resources.Load("battle2") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }

        if (enemyNum == 1 || enemyNum == 3)
        {
            var textAsset = Resources.Load("battle7.11") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 2)
        {
            var textAsset = Resources.Load("battle9") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 4)
        {
            var textAsset = Resources.Load("battle13") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 5)
        {
            var textAsset = Resources.Load("battle15") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 6)
        {
            var textAsset = Resources.Load("battle17") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 7)
        {
            var textAsset = Resources.Load("battle18") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 8)
        {
            var textAsset = Resources.Load("battle19") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 9)
        {
            var textAsset = Resources.Load("battle20") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        if (enemyNum == 10)
        {
            var textAsset = Resources.Load("battle21") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }

        walk = true;
        battle = false;
    }

    bool gameover = false;
    private async Task PreGameOver()
    {
        gameover = true;

        tarot.hitP -= damage;

        if (tarot.hitP < 0)
        {
            tarot.hitP = 0;
        }
        Te0.GetComponent<Text>().text = tarot.hitP.ToString();

        //�|�ꂽ�Ƃ�
        if (tarot.hitP <= 0)
        {
            await Task.Delay(2000);

            GameOver();
        }
    }

    private void GameOver()
    {
        Audio1.GetComponent<AudioSource>().Stop();
        Audio2.GetComponent<AudioSource>().Play();

        var textAsset = Resources.Load("GameOver") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        walk = true;

        storyCard.GetComponent<Image>().sprite = SCard.images[22];
    }
}