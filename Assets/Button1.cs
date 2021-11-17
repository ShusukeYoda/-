using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    private Text text;

    public Sprite[] tarotImage;                  //�z����ײ� �����Ə�����
    public List<Sprite> images;                  //List���ײ�

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
        if (one)
        {
            random1 = UnityEngine.Random.Range(1, 4);
            //int random1 = 2;   //�X�g�[���[card�f�o�b�O�p
            sNum += random1;

            if (sNum < 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[sNum];
                //walk = false;
            }
            else if (sNum >= 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[42];
            }
        }
    }
    public class Status
    {
        public int hp;

        public int str; public int vit;

        public int mg; public int res;

        public int agi; public int dex; public int luc;

        //public int wt = 510; //WT = �N���X��{�l+510-AGI+�����d��

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
            //StreamReader file = new StreamReader(@"Status\�����p�����[�^0.txt");
            //richTextBox1.Text = file.ReadToEnd();
            //file.Close();

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
                new Status {eHp = 30,eAtt = 35 ,eDef=5, eRes = 5, eAgi = 10},�@//�P�R�m

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},�@//�Q�R��

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�R�R��(��)

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},�@//�S�R��

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�T�`����

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�U���

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 20},�@//�V������

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},�@//�W���K��

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},�@//�X�b��

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},�@//�P�O���K����

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10}�@ //�P�P�Z�l
            };

    public int command;
    private void Command1()
    {
        if (one)
        {
            command = 1;
            CommandSelected(command);
        }
    }
    private void Command2()
    {
        if (one)
        {
            command = 2;
            CommandSelected(command);
        }
    }
    private void Command3()
    {
        if (one)
        {
            command = 3;
            CommandSelected(command);
        }
    }
    private void Command4()
    {
        if (one)
        {
            command = 4;
            CommandSelected(command);
        }
    }

    int critical;
    private void CommandSelected(int co)
    {
        critical = UnityEngine.Random.Range(0, 50);

        if (sNum == 1)
        {
            if (co == 0 && walk == false)
            {
                var textAsset = Resources.Load("�b������1") as TextAsset;
                textMeshPro = this.GetComponent<TextMeshProUGUI>();
                textMeshPro.text = textAsset.ToString();
            }
            if (co == 1 && walk == false)
            {
                var textAsset = Resources.Load("�a�����1") as TextAsset;
                textMeshPro = this.GetComponent<TextMeshProUGUI>();
                textMeshPro.text = textAsset.ToString();
            }
            if (co == 2 && walk == false)
            {
                if (magic >= 5)
                {
                    var textAsset = Resources.Load("���@���g��1") as TextAsset;
                    textMeshPro = this.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = textAsset.ToString();

                    magic -= 5;
                    luck += 5;

                    Te4.GetComponent<Text>().text = magic.ToString();
                    Te3.GetComponent<Text>().text = luck.ToString();

                    walk = true;
                }
                else
                {
                    var textAsset = Resources.Load("���@���g��0") as TextAsset;
                    textMeshPro = this.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = textAsset.ToString();
                }
            }
            if (co == 3 && walk == false)
            {
                var textAsset = Resources.Load("��������1") as TextAsset;
                textMeshPro = this.GetComponent<TextMeshProUGUI>();
                textMeshPro.text = textAsset.ToString();

                walk = true;
            }
        }
    }
}



/*
private void CommandSelected(object sender, EventArgs e)
{
    if (one)
    {

        string command = Dropdown;
        int number = this.comandSelect[command];

        Command(number);
    }
}

private void Command(int number)
{
    throw new NotImplementedException();
}
  */







//�摜�t�@�C����ǂݍ���ŁAImage�I�u�W�F�N�g���쐬����
//System.Drawing.Image img = System.Drawing.Image.FromFile("Images/66px-RWS_Tarot_08_Strength");

/*
GameObject card;
Tarot tarot = new Tarot();
int[] dice = new int[22];


this.card = GameObject.Find("card");
card.GetComponent<Tarot>();
*/

//int index = Random.Range(0, dice.Length);
//card = Resources.Load < Sprite > "Images/66px-RWS_Tarot_08_Strength";

//tarot.tarotImage[index];

//Sprite sprite;
//= Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
//tarot.tarotImage[index];

/*
Tarot tarot = new Tarot();

int[] dice = new int[22];
int index = Random.Range(0, dice.Length);

Sprite[] sprites = Resources.LoadAll<Sprite>("Images");
*/


//Sprite image = Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
//card.ImageLocation = tarot.tarotImage[index];