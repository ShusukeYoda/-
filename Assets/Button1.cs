using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    //�I�u�W�F�N�g
    GameObject card;
    GameObject storyCard;

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
            random1 = Random.Range(1, 4);
            //int random1 = 2;   //�X�g�[���[card�f�o�b�O�p
            sNum += random1;

            if (sNum < 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[sNum];
                //walk = false;
            }
            else if(sNum >= 23 && walk == true)
            {
                storyCard.GetComponent<SpriteRenderer>().sprite = images[42];
            }
        }
    }
}












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