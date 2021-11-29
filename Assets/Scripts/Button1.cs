using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Button1 : MonoBehaviour
{
    //�I�u�W�F�N�g
    GameObject card;
    GameObject storyCard;
    GameObject Te0;
    GameObject Te1;
    GameObject Te2;
    GameObject Te3;
    GameObject Te4;
    GameObject Te5;
    GameObject Te6;
    GameObject Te7;
    GameObject Style;
    GameObject Dropdown;
    //BGM
    GameObject Audio1;
    GameObject Audio2;
    GameObject Audio3;
    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    private Text text;

    public Sprite[] tarotImage;                  //�z����ײ� �����Ə�����
    public List<Sprite> images;                  //List���ײ�

    // SE
    public AudioClip cardShuffleSE;
    public AudioClip attackSE;
    public AudioClip criticalSE;
    public AudioClip damageSE;
    public AudioClip magicSE1;
    public AudioClip magicSE2;
    public AudioClip magicSE3;
    public AudioClip magicSE4;
    public AudioClip cardStopSE;
    public AudioClip startStopSE;
    public AudioClip onPointSE;

    //�^�C�}�[
    float span = 0.1f;                           //0.1�b�Ԋu
    float delta = 0;
    int count = 0;
    //�X�^�[�g�X�g�b�v
    public bool moving;
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
        this.card = GameObject.Find("card");
        this.storyCard = GameObject.Find("storyCard");
        this.Te0 = GameObject.Find("Te0");
        this.Te1 = GameObject.Find("Te1");
        this.Te2 = GameObject.Find("Te2");
        this.Te3 = GameObject.Find("Te3");
        this.Te4 = GameObject.Find("Te4");
        this.Te5 = GameObject.Find("Te5");
        this.Te6 = GameObject.Find("Te6");
        this.Te7 = GameObject.Find("Te7");
        this.Style = GameObject.Find("Style");
        this.Dropdown = GameObject.Find("Dropdown");


        this.Audio1 = GameObject.Find("BGM");
        this.Audio2 = GameObject.Find("BGM1");
        this.Audio3 = GameObject.Find("BGM2");

        Audio1.GetComponent<AudioSource>().Play();

        this.TextTMP = GameObject.Find("TextTMP");
    }
    // Update is called once per frame
    void Update()
    {
        if (moving && one == false)
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span && count < 21)
            {
                this.delta = 0;
                card.GetComponent<SpriteRenderer>().sprite = tarotImage[count];
                count++;
            }
            else if (this.delta > this.span && count == 21)
            {
                count = 0;
                this.delta = 0;
                card.GetComponent<SpriteRenderer>().sprite = tarotImage[count];
                count++;
            }
        }
        else if (moving == false && one == true)
        {
            card.GetComponent<SpriteRenderer>().sprite = tarotImage[count];
            ChooseTarot(count);
        }
    }

    public void StartClick()
    {
        moving = true;
    }
    public void StopClick()
    {
        if (moving == true && one == false)
        {
            moving = false;
            one = true;
            walk = true;
        }
    }
    public void StoryClick()
    {
        if (one && walk)
        {
            random1 = UnityEngine.Random.Range(1, 4);
            //int random1 = 22;   //�X�g�[���[card�f�o�b�O�p
            sNum += random1;


            if (sNum <= 21 && walk)
            {
                walk = false;
                storyCard.GetComponent<SpriteRenderer>().sprite = images[sNum];

                var textAsset = Resources.Load("image"+sNum) as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            }
            else if (sNum >= 22 && walk)
            {
                Audio1.GetComponent<AudioSource>().Stop();
                Audio3.GetComponent<AudioSource>().Play();

                UnityEngine.Debug.Log("�`�F�b�N");

                var textAsset = Resources.Load("EndImage") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                storyCard.GetComponent<SpriteRenderer>().sprite = images[22];

                walk = false;
            }
        }
    }
    public class Status : Form
    {
        public int hp;

        public int str; public int vit;

        public int mg; public int res;

        public int agi; public int dex; public int luc;

        public int eHp;

        public int eAtt; public int eDef;

        public int eRes; public int eAgi;

        public string line;
    }

    List<Status> select = new List<Status>
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30,line = "�X�^�C���́w0 ���ҁx"
},
                new Status {hp = 30, str = 10, vit = 10, mg = 40, res = 30,agi = 10,dex =20,luc = 15,line = "�X�^�C���́wI ���p�t�x"},
                new Status {hp = 30, str = 15, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30,line = "�X�^�C���́wII �����c�x"},

                new Status {hp = 30, str = 20, vit = 15, mg = 25, res = 20,agi = 10,dex =15,luc = 15,line = "�X�^�C���́wIII ����x"},
                new Status {hp = 35, str = 30, vit = 20, mg = 15, res = 10,agi = 10,dex =15,luc = 15,line = "�X�^�C���́wIV �c��x"},
                new Status {hp = 30, str = 10, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30,line = "�X�^�C���́wV ���c�x"},

                new Status {hp = 35, str = 20, vit = 20, mg = 20, res = 15,agi = 15,dex =20,luc = 10,line = "�X�^�C���́wVI ���l�x"},
                new Status {hp = 50, str = 40, vit = 30, mg = 0, res = 0,agi = 5,dex =10,luc = 10,line = "�X�^�C���́wVII ��ԁx"},
                new Status {hp = 45, str = 50, vit = 25, mg = 5, res = 5,agi = 15,dex =25,luc = 15,line = "�X�^�C���́wVIII �́x"},
                new Status {hp = 40, str = 25, vit = 15, mg = 20, res = 15,agi = 10,dex =5,luc = 10,line = "�X�^�C���́wIX �B�ҁx"},

                new Status {hp = 40, str = 30, vit = 20, mg = 25, res = 20,agi = 15,dex =15,luc = 15,line = "�X�^�C���́wX �^���̗ցx"},
                new Status {hp = 40, str = 35, vit = 20, mg = 15, res = 10,agi = 15,dex =10,luc = 10,line = "�X�^�C���́wXI ���`�x"},
                new Status {hp = 45, str = 35, vit = 20, mg = 10, res = 10,agi = 10,dex =10,luc = 5,line = "�X�^�C���́wXII �݂��ꂽ�j�x"},
                new Status {hp = 35, str = 45, vit = 25, mg = 20, res = 15,agi = 20,dex =20,luc = 10,line = "�X�^�C���́wXIII ���_�x"},

                new Status {hp = 45, str = 25, vit = 20, mg = 25, res = 20,agi = 15,dex =30,luc = 15,line = "�X�^�C���́wXIV �ߐ��x"},
                new Status {hp = 35, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =15,luc = 10,line = "�X�^�C���́wXV �����x"},
                new Status {hp = 35, str = 40, vit = 20, mg = 10, res = 10,agi = 10,dex =15,luc = 5,line = "�X�^�C���́wXVI ���x"},
                new Status {hp = 40, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =20,luc = 20,line = "�X�^�C���́wXVII ���x"},

                new Status {hp = 60, str = 35, vit = 20, mg = 30, res = 25,agi = 10,dex =20,luc = 20,line = "�X�^�C���́wXVIII ���x"},
                new Status {hp = 55, str = 40, vit = 20, mg = 35, res = 30,agi = 10,dex =20,luc = 20,line = "�X�^�C���́wXIX ���z�x"},
                new Status {hp = 65, str = 30, vit = 15, mg = 30, res = 25,agi = 10,dex =25,luc = 25,line = "�X�^�C���́wXX  �R���x"},
                new Status {hp = 50, str = 45, vit = 25, mg = 25, res = 20,agi = 20,dex =20,luc = 20,line = "�X�^�C���́wXXI ���E�x"},
            };

    private void ChooseTarot(int v)
    {
        if (tarotImage[count]) //tarotImage[0] == 
        {
            Te0.GetComponent<Text>().text = select[v].hp.ToString();
            Te1.GetComponent<Text>().text = select[v].str.ToString();
            Te2.GetComponent<Text>().text = select[v].vit.ToString();
            Te3.GetComponent<Text>().text = select[v].luc.ToString();
            Te4.GetComponent<Text>().text = select[v].mg.ToString();
            Te5.GetComponent<Text>().text = select[v].res.ToString();
            Te6.GetComponent<Text>().text = select[v].agi.ToString();
            Te7.GetComponent<Text>().text = select[v].dex.ToString();
            Style.GetComponent<Text>().text = select[v].line.ToString();
        }
        //�v���C���[�X�e�[�^�X
        attack = select[v].str + (select[v].dex / 5) * (select[v].luc / 5);
        defense = select[v].vit + (select[v].dex / 5) * (select[v].luc / 5);
        mAttack = select[v].mg - 5 + (select[v].dex / 5) * (select[v].luc / 5);
        mDefense = select[v].res + (select[v].dex / 5) * (select[v].luc / 5);

        hitP = select[v].hp;
        magic = select[v].mg;
        strength = select[v].str;
        resist = select[v].res;
        agility = select[v].agi;
        luck = select[v].luc;
    }
    int attack;
    int defense;
    int mAttack;
    int mDefense;
    int hitP;
    int magic;
    int strength;
    int resist;
    int agility;
    int luck;

    List<Status> enemys = new List<Status>
            {
                new Status {eHp = 50,eAtt = 35 ,eDef=5, eRes = 5, eAgi = 10},�@//�P�R�m

                new Status {eHp = 55,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},�@//�Q�R��

                new Status {eHp = 50,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�R�R��(��)

                new Status {eHp = 55,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},�@//�S�R��

                new Status {eHp = 50,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�T�`����

                new Status {eHp = 50,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�U���

                new Status {eHp = 60,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 20},�@//�V������

                new Status {eHp = 60,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},�@//�W���K��

                new Status {eHp = 55,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�X�b��

                new Status {eHp = 60,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},�@//�P�O���K����

                new Status {eHp = 40,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10}�@ //�P�P�Z�l
            };


    public void OnClick()
    {
        Dropdown ddtmp;

        //�uDropdown�v�Ƃ���GameObject��DropDown�R���|�[�l���g�𑀍삷�邽�߂Ɏ擾
        ddtmp = GameObject.Find("Dropdown").GetComponent<Dropdown>();

        //DropDown�R���|�[�l���g��options����I������ĂĂ���value��index�Ŏw�肵�A
        //�I������Ă��镶�����擾
        //string selectedvalue = ddtmp.options[ddtmp.value].text;

        CommandSelected(ddtmp.value);
    }

    bool battle = false;

    int damage;
    int eDamage;
    int cri;

    public int enemyNum;

    public async void CommandSelected(int co)
    {
        cri = UnityEngine.Random.Range(0, 50);

        if (sNum == 1)
        {
            walk = false;

            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������1") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 2)//sNum == 2 debug
           {
            walk = false;
            enemyNum = 0;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)//magic >= 5 debug
                {
                    var textAsset = Resources.Load("���@���g��2") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    //�o�g���t���O
                    battle = true;
                    //2�b�҂�
                    await Task.Delay(2000);
                    //mp����
                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    //�^�_��
                    eDamage = mAttack - enemys[enemyNum].eRes;
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
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������2") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }




        if (sNum == 3)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������3") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����3") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������3") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }

        if (sNum == 4)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������4") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����4") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������4") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 5)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                magic += 10;
                Te4.GetComponent<Text>().text = magic.ToString();

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������5") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 6)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                luck -= 10;
                Te3.GetComponent<Text>().text = luck.ToString();

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
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
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������6") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 7)
        {
            walk = false;
            enemyNum = 1;
            battle = true;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;

                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                await Task.Delay(2000);
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��7") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }

                }
                else
                {
                    var textAsset = Resources.Load("���@���g��7b") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                    await Task.Delay(2000);

                    damage = attack - enemys[0].eDef;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    Te0.GetComponent<Text>().text = hitP.ToString();

                    //�|�ꂽ�Ƃ�
                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);
                }

            }
            if (co == 3 && battle == false ||
                co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;

                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                await Task.Delay(2000);
            }
        }
        if (sNum == 8)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                strength += 10;
                Te1.GetComponent<Text>().text = strength.ToString();                                //Te1�Ő������̂�

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
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
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������8") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 9)
        {
            walk = false;
            enemyNum = 2;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������9") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                battle = true;

                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;

                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                await Task.Delay(2000);
            }

            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����9") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && battle != true ||
                co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��9a") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

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
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������9") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 10)
        {
           walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������10") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����10") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������10") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 11)
        {
            walk = false;
            enemyNum = 3;
            battle = true;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;

                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                await Task.Delay(2000);
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��11") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }

                    await Task.Delay(2000);
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��11b") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;
                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    Te0.GetComponent<Text>().text = hitP.ToString();

                    //�|�ꂽ�Ƃ�
                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }

                    await Task.Delay(2000);
                }

            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;
                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }

                await Task.Delay(2000);
            }
        }
        if (sNum == 12)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������12") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����12") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������12") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 13)
        {
            walk = false;
            enemyNum = 4;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������13") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����13") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��13") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }

            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������13") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 14)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������14") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����14") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��14") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                    magic -= 5;
                    hitP += 10;
                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te0.GetComponent<Text>().text = hitP.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������14") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 15)
        {
            walk = false;
            enemyNum = 5;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������15") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����15") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��15") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������15") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 16)
        {
            walk = false;
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                luck += 10;
                Te3.GetComponent<Text>().text = luck.ToString();

                walk = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������16") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 17)
        {
            walk = false;
            enemyNum = 6;
            battle = true;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;
                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                await Task.Delay(2000);
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��17") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }

                }
                else
                {
                    var textAsset = Resources.Load("���@���g��17b") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;
                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    Te0.GetComponent<Text>().text = hitP.ToString();

                    //�|�ꂽ�Ƃ�
                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);
                }

            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                await Task.Delay(2000);

                damage = attack - enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;
                if (hitP < 0)
                {
                    hitP = 0;
                }
                Te0.GetComponent<Text>().text = hitP.ToString();

                //�|�ꂽ�Ƃ�
                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                await Task.Delay(2000);
            }
        }
        if (sNum == 18)
        {
            walk = false;
            enemyNum = 7;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������18") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����18") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��18") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }

                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }

            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������18") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
        }
        if (sNum == 19)
        {
            walk = false;
            enemyNum = 8;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������19") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����19") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��19") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();



                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }
            }
            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������19") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                walk = true;
            }
        }
        if (sNum == 20)
        {
            walk = false;
            enemyNum = 9;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������20") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;

            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����20") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                battle = true;

                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);

                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��20") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }

            }

            if (co == 3 && battle != true)
            {
                var textAsset = Resources.Load("��������20") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
        }
        if (sNum == 21)
        {
            walk = false;
            enemyNum = 10;
            if (co == 0 && battle == false ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������21") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;

            }
            if (co == 1 && battle != true)
            {
                var textAsset = Resources.Load("�a�����21a") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
            }
            if (co == 1 && walk == false && battle == true)
            {
                var textAsset = Resources.Load("�a�����21b") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                //battle
                if (cri <= luck)
                {
                    eDamage = attack * 2 - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;


                }
                else
                {
                    eDamage = attack - enemys[enemyNum].eDef;
                    damage = enemys[enemyNum].eAtt - defense;
                }

                if (damage < 0)
                {
                    damage = 0;
                }

                await Task.Delay(2000);


                //�o�g�����\�b�h��
                SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
            }

            if (co == 2 && battle != true)
            {
                if (magic >= 5)
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
            if (co == 2 && walk == false && battle == true)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��21") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();





                    battle = true;

                    await Task.Delay(2000);

                    magic -= 5;
                    Te4.GetComponent<Text>().text = magic.ToString();

                    eDamage = mAttack - enemys[enemyNum].eRes;
                    enemys[enemyNum].eHp -= eDamage;

                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
                    UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                    //

                    //�^�_���[�W
                    enemys[enemyNum].eHp -= eDamage;

                    //�|�����Ƃ�
                    if (enemys[enemyNum].eHp <= 0)
                    {
                        await Task.Delay(1000);

                        KilledBranch(enemyNum);
                    }
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
                }

            }
            if (co == 3 && battle != true ||
                co == 0 && walk == false)
            {
                var textAsset = Resources.Load("��������21") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                battle = true;
            }
        }
    }


    private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
    {

        if (agility >= eAgi)
        {
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                await Task.Delay(1000);

                KilledBranch(enemyNum);
            }
            //���s�F�ʏ�
            else
            {
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }
        }
        else
        {
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�X�e�[�^�X�o�[�ɕ\�L
            hitP -= damage;

            if (hitP < 0)
            {
                hitP = 0;
            }
            Te0.GetComponent<Text>().text = hitP.ToString();

            //�|�ꂽ�Ƃ�
            if (hitP <= 0)
            {
                await Task.Delay(2000);

                GameOver();
            }
            //���s�F�ʏ�
            else
            {
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }

        }
    }

    private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
    {
        if (agility >= eAgi)
        {
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�^�_���[�W
            enemys[enemyNum].eHp -= eDamage;

            //�|�����Ƃ�
            if (enemys[enemyNum].eHp <= 0)
            {
                await Task.Delay(1000);

                KilledBranch(enemyNum);
            }

            await Task.Delay(2000);

        }
        else
        {
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}�_���[�W��^����";
            UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
            //

            //�X�e�[�^�X�o�[�ɕ\�L
            hitP -= damage;
            if (hitP < 0)
            {
                hitP = 0;
            }
            Te0.GetComponent<Text>().text = hitP.ToString();

            //�|�ꂽ�Ƃ�
            if (hitP <= 0)
            {
                await Task.Delay(2000);

                GameOver();
            }

            await Task.Delay(2000);

        }
    }

    private async void KilledBranch(int enemyNum)
    {
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
    private void GameOver()
    {
        Audio1.GetComponent<AudioSource>().Stop();
        Audio2.GetComponent<AudioSource>().Play();

        var textAsset = Resources.Load("GameOver") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        walk = true;

        storyCard.GetComponent<SpriteRenderer>().sprite = images[23];
    }
}










/*
    // BGM
    public AudioClip[] clips;
    public AudioSource[] audios;

    public TextAsset[] textasset;

        audio[2] = Audio1.GetComponent<AudioSource>();
        audio[2].Play();

 */
/*�@���g�p���\�b�h
 *�@    //battle �e�L�X�g�̃N���A
        TextClear();

    private static void TextClear()
    {
        using (var fileStream = new FileStream("Assets/Resources/battle�l.txt", FileMode.Open))
        {
            fileStream.SetLength(0);
            Debug.Log("clear");
        }
    }

        //save�e�L�X�g
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


/*�@�_���[�W�����̕ύX�ɂ���
            //�e�L�X�g��������
            //SaveText("Assets/Resources/battle�l.txt", $"{ eDamage}�_���[�W��^����\n"); 
            //�e�L�X�g�ǂݍ���
            //var teAsBattle = Resources.Load("battle�l") as TextAsset;
   �����̂�  TextTMP.GetComponent<TextMeshProUGUI>().text = $"{ eDamage}�_���[�W��^����\n";
            //teAsBattle.ToString();
            Debug.Log("�`�F�b�N�|�C���g");
 */
/*
 * 
                    using StreamWriter file = new("battle�l", append: true);
                    await file.WriteLineAsync($"{eDamage}�_���[�W��^����\n");
*/
//Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

//File.AppendAllText("battle�l", $"{eDamage}�_���[�W��^����\n");
/*
StreamWriter writer =
  new StreamWriter("battle�l", true);
writer.WriteLine($"{eDamage}�_���[�W��^����\n");
writer.Close();                   
*/
/*
string filePath = "battle�l";
StreamWriter outStream = System.IO.File.CreateText(filePath);
outStream.WriteLine($"{eDamage}�_���[�W��^����\n");
outStream.Close();
*/

/*
IResourceWriter writer = new ResourceWriter("battle�l");
writer.AddResource("battle�l", $"{eDamage}�_���[�W��^����\n");
writer.Close();
*/

//File.WriteAllBytes("battle�l", $"{eDamage}�_���[�W��^����\n");
//var teAsBattle = AssetDatabase.LoadAssetAtPath<TextMeshProUGUI>("battle�l");
//UnityEngine.Object teAsBattle = AssetDatabase.LoadMainAssetAtPath("battle�l");
/*
StreamReader at = new StreamReader(@"\battle�l.txt",
Encoding.GetEncoding("Shift_JIS"), false);
richTextBox1.Text = at.ReadToEnd();
at.Close();
*/
