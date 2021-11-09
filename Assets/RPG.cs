using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cards����P
{
    public class RPG : MonoBehaviour
    {
        //�t�H�[���Q�C���X�^���X�G
        //Cards cards;

        // Start is called before the first frame update
        void Start()
        {

        //�^���b�g�p�����_���ϐ��ƃJ�E���^�[(�b)
        Random random = new Random();
        public int count;
        //�^���b�g�X�^�[�g�F�^�C�}�[
        Timer timer;
        private void button1_Click(object sender, EventArgs e)
        {
            if (judge == false)
            {
                //�I�[�f�B�I�t�@�C�����w�肷��
                mediaPlayer.URL = "��������12.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                timer.Start();                                           //�X�^�[�g
            }
        }
        private void OnTimer1(object sender, EventArgs e)
        {
            if (judge == false)
            {
                Tarot tarot = new Tarot();
                int num = random.Next(22);
                pictureBox1.ImageLocation = tarot.tarotImage[num];
            }
        }

        //�A�j���[�V����gif�p
        Bitmap animated;
        //�E�B���h�E�Y���f�B�A�v���C���[
        WindowsMediaPlayer wmPlayer;
        //�R���{�{�b�N�X
        Dictionary<string, int> comandSelect;
        private void Form1_Load(object sender, EventArgs e)
        {
            // �A�j���[�V����gif�̐ݒ�
            animated = new Bitmap("round_white.gif");
            gifBox.Image = animated;
            // pictureBox��Paint�C�x���g�n���h��
            gifBox.Paint += pictureBox_Paint;
            // �A�j���[�V�����J�n
            ImageAnimator.Animate(animated, new EventHandler(Image_FrameChanged));


            //mp3�v���C���[(wmp)
            wmPlayer = new WindowsMediaPlayer();
            //wmPlayer.settings.autoStart = false;  //�J�n���ɂ̓R�����g�A�E�g
            wmPlayer.URL = "�������s�A�m35.mp3";

            //�R���{�{�b�N�X
            comandSelect = new Dictionary<string, int>();

            comandSelect.Add("�b������", 0);
            comandSelect.Add("�a�����", 1);
            comandSelect.Add("���@���g��", 2);
            comandSelect.Add("��������", 3);

            foreach (KeyValuePair<string, int> command in this.comandSelect)
            {
                commandBox.Items.Add(command.Key);
            }
            //commandBox.Text = "DropDownList";

            //battle �e�L�X�g�̃N���A
            using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }

            //�I�[�v�j���O�e�L�X�g
            StreamReader file = new StreamReader(@"Story\Start.txt");
            richTextBox1.Text = file.ReadToEnd();
            file.Close();


            //�^���b�g�p�^�C�}�[
            timer = new Timer();

            timer.Interval = 100;
            timer.Tick += OnTimer1;                                 //�I���^�C�}�[

            //�t�H�[���Q�̕\��
            this.cards = new Cards(this);
            cards.Show();
        }
        private void Image_FrameChanged(object sender, EventArgs e)
        {
            // Paint�C�x���g�n���h�����Ăяo��
            gifBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // �t���[���̍X�V
            ImageAnimator.UpdateFrames(animated);
            // �摜�̕`��
            e.Graphics.DrawImage(animated, 0, 0);
        }


        // �^���b�g�I���{�^��
        bool judge = false;
        string line;
        private void button2_Click(object sender, EventArgs e)
        {
            Tarot tarot = new Tarot();
            timer.Stop();                                           //�X�g�b�v

            if (judge == false)
            {
                //�I�[�f�B�I�t�@�C�����w�肷��
                mediaPlayer.URL = "�������J�[�h��14.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                if (pictureBox1.ImageLocation == tarot.tarotImage[0])
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

        }

        //Status select = new Status();
        private void TarotChoose(int v)
        {
            List<Status> select = new List<Status>
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30},
                new Status {hp = 30, str = 10, vit = 10, mg = 40, res = 30,agi = 10,dex =20,luc = 15},
                new Status {hp = 30, str = 15, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30},

                new Status {hp = 30, str = 20, vit = 15, mg = 25, res = 20,agi = 10,dex =15,luc = 15},
                new Status {hp = 35, str = 30, vit = 20, mg = 15, res = 10,agi = 10,dex =15,luc = 15},
                new Status {hp = 30, str = 10, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30},

                new Status {hp = 35, str = 20, vit = 20, mg = 20, res = 15,agi = 15,dex =20,luc = 10},
                new Status {hp = 50, str = 40, vit = 30, mg = 0, res = 0,agi = 5,dex =10,luc = 10},
                new Status {hp = 45, str = 50, vit = 25, mg = 5, res = 5,agi = 15,dex =25,luc = 15},
                new Status {hp = 40, str = 25, vit = 15, mg = 20, res = 15,agi = 10,dex =5,luc = 10},

                new Status {hp = 40, str = 30, vit = 20, mg = 25, res = 20,agi = 15,dex =15,luc = 15},
                new Status {hp = 40, str = 35, vit = 20, mg = 15, res = 10,agi = 15,dex =10,luc = 10},
                new Status {hp = 45, str = 35, vit = 20, mg = 10, res = 10,agi = 10,dex =10,luc = 5},
                new Status {hp = 35, str = 45, vit = 25, mg = 20, res = 15,agi = 20,dex =20,luc = 10},

                new Status {hp = 45, str = 25, vit = 20, mg = 25, res = 20,agi = 15,dex =30,luc = 15},
                new Status {hp = 35, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =15,luc = 10},
                new Status {hp = 35, str = 40, vit = 20, mg = 10, res = 10,agi = 10,dex =15,luc = 5},
                new Status {hp = 40, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =20,luc = 20},

                new Status {hp = 60, str = 35, vit = 20, mg = 30, res = 25,agi = 10,dex =20,luc = 20},
                new Status {hp = 55, str = 40, vit = 20, mg = 35, res = 30,agi = 10,dex =20,luc = 20},
                new Status {hp = 65, str = 30, vit = 15, mg = 30, res = 25,agi = 10,dex =25,luc = 25},
                new Status {hp = 50, str = 45, vit = 25, mg = 25, res = 20,agi = 20,dex =20,luc = 20},
            };

            Tarot tarot = new Tarot();
            if (tarot.tarotImage[0] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^0.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;

                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[1] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^1.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[2] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^2.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[3] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^3.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[4] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^4.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[5] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^5.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[6] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^6.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[7] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^7.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[8] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^8.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[9] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^9.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[10] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^10.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[11] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^11.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[12] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^12.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[13] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^13.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[14] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^14.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[15] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^15.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[16] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^16.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[17] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^17.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[18] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^18.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[19] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^19.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[20] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^20.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[21] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^21.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
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

        int storyNumber;
        internal void StoryText(int n)
        {
            if (n == 0)
            {
                StreamReader file = new StreamReader(@"Story\image0.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 1)
            {
                StreamReader file = new StreamReader(@"Story\image1.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 2)
            {

                StreamReader file = new StreamReader(@"Story\image2.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 3)
            {

                StreamReader file = new StreamReader(@"Story\image3.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 4)
            {
                StreamReader file = new StreamReader(@"Story\image4.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 5)
            {
                StreamReader file = new StreamReader(@"Story\image5.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 6)
            {
                StreamReader file = new StreamReader(@"Story\image6.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 7)
            {
                StreamReader file = new StreamReader(@"Story\image7.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 8)
            {
                StreamReader file = new StreamReader(@"Story\image8.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 9)
            {
                StreamReader file = new StreamReader(@"Story\image9.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 10)
            {
                StreamReader file = new StreamReader(@"Story\image10.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 11)
            {
                StreamReader file = new StreamReader(@"Story\image11.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 12)
            {
                StreamReader file = new StreamReader(@"Story\image12.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 13)
            {
                StreamReader file = new StreamReader(@"Story\image13.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 14)
            {
                StreamReader file = new StreamReader(@"Story\image14.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 15)
            {
                StreamReader file = new StreamReader(@"Story\image15.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 16)
            {
                StreamReader file = new StreamReader(@"Story\image16.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 17)
            {
                StreamReader file = new StreamReader(@"Story\image17.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 18)
            {
                StreamReader file = new StreamReader(@"Story\image18.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 19)
            {
                StreamReader file = new StreamReader(@"Story\image19.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 20)
            {
                StreamReader file = new StreamReader(@"Story\image20.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 21)
            {
                StreamReader file = new StreamReader(@"Story\image21.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            //End
            if (n == 22)
            {
                StreamReader file = new StreamReader(@"Story\EndImage.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                wmPlayer.URL = "������  �A�R�[�X�e�B�b�N50.mp3";

                storyNumber = n;
            }
        }

        //form2�̃J�[�h��؂�ւ���
        int counter = 1;
        int num2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (judge && walk)
            {
                //�I�[�f�B�I�t�@�C�����w�肷��
                mediaPlayer.URL = "������ ���ʉ� �p�\�R��01.wav";
                //�Đ�����
                mediaPlayer.controls.play();


                Random random2 = new Random();
                int ran2 = random2.Next(1, 4);
                //int ran2 = 2;   //�X�g�[���[card�f�o�b�O�p

                num2 += ran2;
                if (num2 < 22)
                {
                    cards.StoryCards(num2);
                    counter--;
                    walk = false;
                }
                else
                {
                    cards.EndCards();
                }
            }
        }


        private void CommandSelected(object sender, EventArgs e)
        {
            if (judge)
            {
                string command = commandBox.Text;
                int number = this.comandSelect[command];

                Command(number);
            }
        }

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

        bool battle = false;
        bool walk = false;

        int damage;
        int eDamage;

        Random critical = new Random();

        int enemyNum;
        private async void Command(int co)
        {
            int cri = critical.Next(0, 50);
            //int cri = critical.Next(attack);

            if (storyNumber == 1)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������1.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����1.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������1.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }

            if (storyNumber == 2)
            {
                enemyNum = 0;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader file = new StreamReader(@"Command\�b������2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                }
                if (co == 1 && walk == false)
                {

                    StreamReader file = new StreamReader(@"Command\�a�����2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();


                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;



                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader file = new StreamReader(@"Command\���@���g��2.txt");
                        richTextBox1.Text = file.ReadToEnd();
                        file.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle �e�L�X�g�̃N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader file = new StreamReader(@"Command\��������2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                    walk = true;
                }
            }
            if (storyNumber == 3)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������3.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����3.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������3.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 4)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������4.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����4.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������4.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 5)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������5.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������  �}�W�J��11.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    magic += 10;
                    label13.Text = magic.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����5.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������5.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 6)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������6.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������  �}�W�J��27.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    luck -= 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����6.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��6.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������6.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 7)
            {
                enemyNum = 1;
                battle = true;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������7.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����7.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��7.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle �e�L�X�g�̃N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��7b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[0].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                        writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //�X�e�[�^�X�o�[�ɕ\�L
                        hitP -= damage;

                        if (hitP < 0)
                        {
                            hitP = 0;
                        }
                        label9.Text = hitP.ToString();

                        if (hitP <= 0)
                        {
                            await Task.Delay(2000);

                            GameOver();
                        }
                        await Task.Delay(2000);

                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle == false ||
                    co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������7.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 8)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������8.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������ ���ʉ� �����|�C���g17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    strength += 10;
                    label10.Text = strength.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����8.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��8.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������8.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 9)
            {
                enemyNum = 2;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������9.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    battle = true;

                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����9.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && battle != true ||
                    co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��9a.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��9b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                        battle = true;
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������9.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 10)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������10.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����10.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������10.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 11)
            {
                enemyNum = 3;
                battle = true;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������11.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����11.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��11.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��11b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                        writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //�X�e�[�^�X�o�[�ɕ\�L
                        hitP -= damage;

                        if (hitP < 0)
                        {
                            hitP = 0;
                        }
                        label9.Text = hitP.ToString();

                        if (hitP <= 0)
                        {
                            await Task.Delay(2000);

                            GameOver();
                        }
                        await Task.Delay(2000);

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������11.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 12)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������12.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����12.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������12.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 13)
            {
                enemyNum = 4;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������13.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����13.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��13.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������13.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 14)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������14.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����14.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��14.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��11.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        hitP += 10;
                        label13.Text = magic.ToString();
                        label9.Text = hitP.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������14.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 15)
            {
                enemyNum = 5;
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������15.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����15.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��15.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������15.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 16)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������16.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������  �}�W�J��11.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    luck += 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����16.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������16.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 17)
            {
                enemyNum = 6;
                battle = true;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������17.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����17.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��17.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��17b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                        writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //�X�e�[�^�X�o�[�ɕ\�L
                        hitP -= damage;

                        if (hitP < 0)
                        {
                            hitP = 0;
                        }
                        label9.Text = hitP.ToString();

                        if (hitP <= 0)
                        {
                            await Task.Delay(2000);

                            GameOver();
                        }
                        await Task.Delay(2000);

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������17.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }

                }
            }
            if (storyNumber == 18)
            {
                enemyNum = 7;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������18.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����18.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��18.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������18.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
            if (storyNumber == 19)
            {
                enemyNum = 8;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������19.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����19.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��19.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������19.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 20)
            {
                enemyNum = 9;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������20.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����20.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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
                        StreamReader line3 = new StreamReader(@"Command\���@���g��20.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }

                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������20.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
            if (storyNumber == 21)
            {
                enemyNum = 10;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������21.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && battle != true)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����21a.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 1 && walk == false && battle == true)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����21b.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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
                        StreamReader line2 = new StreamReader(@"Command\���@���g��21b.txt");
                        richTextBox1.Text = line2.ReadToEnd();
                        line2.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 2 && walk == false && battle == true)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��21.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true ||
                    co == 0 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������21.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
        }

        //wave�Đ��p���f�B�A�v���C���[�C���X�^���X
        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
        private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
        {

            if (agility >= eAgi)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();


                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();


                //�^�_���[�W
                enemys[enemyNum].eHp -= eDamage;

                if (eHp <= 0)
                {
                    await Task.Delay(1000);

                    KilledBranch(enemyNum);
                }
                else
                {
                    await Task.Delay(2000);

                    SwBattlePost(damage, eDamage, eAgi, eHp);
                }
            }
            else
            {
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writ =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;

                if (hitP < 0)
                {
                    hitP = 0;
                }
                label9.Text = hitP.ToString();

                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                else
                {
                    await Task.Delay(2000);

                    SwBattlePost(damage, eDamage, eAgi, eHp);
                }

            }
        }


        private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
        {
            if (agility < eAgi)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();

                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                //�^�_���[�W
                enemys[enemyNum].eHp -= eDamage;

                if (eHp <= 0)
                {
                    await Task.Delay(1000);

                    KilledBranch(enemyNum);
                }

                //battle �e�L�X�g�̃N���A
                using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                {
                    fileStream.SetLength(0);
                }

            }
            else
            {
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writ =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;
                if (hitP < 0)
                {
                    hitP = 0;
                }
                label9.Text = hitP.ToString();

                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }


                //battle �e�L�X�g�̃N���A
                using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                {
                    fileStream.SetLength(0);
                }
            }
        }

        private async void KilledBranch(int enemyNom)
        {
            await Task.Delay(1000);

            if (enemyNom == 0)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle2.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 1 || enemyNom == 3)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle7.11.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 2)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle9.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 4)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle13.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 5)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle15.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 6)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle17.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 7)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle18.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 8)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle19.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 9)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle20.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 10)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle21.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }

            //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
            mediaPlayer.URL = "������  �퓬16.wav";
            //�Đ�����
            mediaPlayer.controls.play();

            //�e�L�X�g�N���A
            using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }
            walk = true;
            battle = false;
        }

        private void GameOver()
        {
            StreamReader file = new StreamReader(@"Story\GameOver.txt");
            richTextBox1.Text = file.ReadToEnd();
            file.Close();

            wmPlayer.URL = "������  �A�R�[�X�e�B�b�N31.mp3";

            //this.BackColor = Color.FromArgb(0, 0, 0);

            walk = true;

            cards.GameOverCards();
        }
    }
}
namespace cards����P
{
    public partial class Form1 : Form
    {
        //�t�H�[���Q�C���X�^���X�G
        Cards cards;

        public Form1()
        {
            InitializeComponent();

            //Foam�̏����ʒu
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(700, 250);

            //this.Load += new EventHandler(Form1_Load);    on���ƃR�}���h���B
            this.Controls.Add(gifBox);
            //gifBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        //�^���b�g�C���[�W
        class Tarot
        {
            public string[] tarotImage;
            public Tarot()
            {
                tarotImage = new string[22];
                tarotImage[0] = @"Image\69px-RWS_Tarot_00_Fool.jpg";
                tarotImage[1] = @"Image\68px-RWS_Tarot_01_Magician.jpg";
                tarotImage[2] = @"Image\69px-RWS_Tarot_02_High_Priestess.jpg";
                tarotImage[3] = @"Image\69px-RWS_Tarot_03_Empress.jpg";
                tarotImage[4] = @"Image\70px-RWS_Tarot_04_Emperor.jpg";
                tarotImage[5] = @"Image\68px-RWS_Tarot_05_Hierophant.jpg";
                tarotImage[6] = @"Image\69px-RWS_Tarot_06_Lovers.jpg";
                tarotImage[7] = @"Image\68px-RWS_Tarot_07_Chariot.jpg";
                tarotImage[8] = @"Image\66px-RWS_Tarot_08_Strength.jpg";
                tarotImage[9] = @"Image\69px-RWS_Tarot_09_Hermit.jpg";
                tarotImage[10] = @"Image\69px-RWS_Tarot_10_Wheel_of_Fortune.jpg";
                tarotImage[11] = @"Image\69px-RWS_Tarot_11_Justice.jpg";
                tarotImage[12] = @"Image\68px-RWS_Tarot_12_Hanged_Man.jpg";
                tarotImage[13] = @"Image\68px-RWS_Tarot_13_Death.jpg";
                tarotImage[14] = @"Image\69px-RWS_Tarot_14_Temperance.jpg";
                tarotImage[15] = @"Image\69px-RWS_Tarot_15_Devil.jpg";
                tarotImage[16] = @"Image\70px-RWS_Tarot_16_Tower.jpg";
                tarotImage[17] = @"Image\69px-RWS_Tarot_17_Star.jpg";
                tarotImage[18] = @"Image\68px-RWS_Tarot_18_Moon.jpg";
                tarotImage[19] = @"Image\69px-RWS_Tarot_19_Sun.jpg";
                tarotImage[20] = @"Image\69px-RWS_Tarot_20_Judgement.jpg";
                tarotImage[21] = @"Image\68px-RWS_Tarot_21_World.jpg";
            }
        }

        //�^���b�g�p�����_���ϐ��ƃJ�E���^�[(�b)
        Random random = new Random();
        public int count;
        //�^���b�g�X�^�[�g�F�^�C�}�[
        Timer timer;
        private void button1_Click(object sender, EventArgs e)
        {
            if (judge == false)
            {
                //�I�[�f�B�I�t�@�C�����w�肷��
                mediaPlayer.URL = "��������12.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                timer.Start();                                           //�X�^�[�g
            }
        }
        private void OnTimer1(object sender, EventArgs e)
        {
            if (judge == false)
            {
                Tarot tarot = new Tarot();
                int num = random.Next(22);
                pictureBox1.ImageLocation = tarot.tarotImage[num];
            }
        }

        //�A�j���[�V����gif�p
        Bitmap animated;
        //�E�B���h�E�Y���f�B�A�v���C���[
        WindowsMediaPlayer wmPlayer;
        //�R���{�{�b�N�X
        Dictionary<string, int> comandSelect;
        private void Form1_Load(object sender, EventArgs e)
        {
            // �A�j���[�V����gif�̐ݒ�
            animated = new Bitmap("round_white.gif");
            gifBox.Image = animated;
            // pictureBox��Paint�C�x���g�n���h��
            gifBox.Paint += pictureBox_Paint;
            // �A�j���[�V�����J�n
            ImageAnimator.Animate(animated, new EventHandler(Image_FrameChanged));


            //mp3�v���C���[(wmp)
            wmPlayer = new WindowsMediaPlayer();
            //wmPlayer.settings.autoStart = false;  //�J�n���ɂ̓R�����g�A�E�g
            wmPlayer.URL = "�������s�A�m35.mp3";

            //�R���{�{�b�N�X
            comandSelect = new Dictionary<string, int>();

            comandSelect.Add("�b������", 0);
            comandSelect.Add("�a�����", 1);
            comandSelect.Add("���@���g��", 2);
            comandSelect.Add("��������", 3);

            foreach (KeyValuePair<string, int> command in this.comandSelect)
            {
                commandBox.Items.Add(command.Key);
            }
            //commandBox.Text = "DropDownList";

            //battle �e�L�X�g�̃N���A
            using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }

            //�I�[�v�j���O�e�L�X�g
            StreamReader file = new StreamReader(@"Story\Start.txt");
            richTextBox1.Text = file.ReadToEnd();
            file.Close();


            //�^���b�g�p�^�C�}�[
            timer = new Timer();

            timer.Interval = 100;
            timer.Tick += OnTimer1;                                 //�I���^�C�}�[

            //�t�H�[���Q�̕\��
            this.cards = new Cards(this);
            cards.Show();
        }
        private void Image_FrameChanged(object sender, EventArgs e)
        {
            // Paint�C�x���g�n���h�����Ăяo��
            gifBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // �t���[���̍X�V
            ImageAnimator.UpdateFrames(animated);
            // �摜�̕`��
            e.Graphics.DrawImage(animated, 0, 0);
        }


        // �^���b�g�I���{�^��
        bool judge = false;
        string line;
        private void button2_Click(object sender, EventArgs e)
        {
            Tarot tarot = new Tarot();
            timer.Stop();                                           //�X�g�b�v

            if (judge == false)
            {
                //�I�[�f�B�I�t�@�C�����w�肷��
                mediaPlayer.URL = "�������J�[�h��14.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                if (pictureBox1.ImageLocation == tarot.tarotImage[0])
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

        }

        //Status select = new Status();
        private void TarotChoose(int v)
        {
            List<Status> select = new List<Status>
            {
                new Status {hp = 35, str = 20, vit = 10, mg = 15, res = 5,agi = 20,dex =15,luc = 30},
                new Status {hp = 30, str = 10, vit = 10, mg = 40, res = 30,agi = 10,dex =20,luc = 15},
                new Status {hp = 30, str = 15, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30},

                new Status {hp = 30, str = 20, vit = 15, mg = 25, res = 20,agi = 10,dex =15,luc = 15},
                new Status {hp = 35, str = 30, vit = 20, mg = 15, res = 10,agi = 10,dex =15,luc = 15},
                new Status {hp = 30, str = 10, vit = 15, mg = 35, res = 30,agi = 10,dex =15,luc = 30},

                new Status {hp = 35, str = 20, vit = 20, mg = 20, res = 15,agi = 15,dex =20,luc = 10},
                new Status {hp = 50, str = 40, vit = 30, mg = 0, res = 0,agi = 5,dex =10,luc = 10},
                new Status {hp = 45, str = 50, vit = 25, mg = 5, res = 5,agi = 15,dex =25,luc = 15},
                new Status {hp = 40, str = 25, vit = 15, mg = 20, res = 15,agi = 10,dex =5,luc = 10},

                new Status {hp = 40, str = 30, vit = 20, mg = 25, res = 20,agi = 15,dex =15,luc = 15},
                new Status {hp = 40, str = 35, vit = 20, mg = 15, res = 10,agi = 15,dex =10,luc = 10},
                new Status {hp = 45, str = 35, vit = 20, mg = 10, res = 10,agi = 10,dex =10,luc = 5},
                new Status {hp = 35, str = 45, vit = 25, mg = 20, res = 15,agi = 20,dex =20,luc = 10},

                new Status {hp = 45, str = 25, vit = 20, mg = 25, res = 20,agi = 15,dex =30,luc = 15},
                new Status {hp = 35, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =15,luc = 10},
                new Status {hp = 35, str = 40, vit = 20, mg = 10, res = 10,agi = 10,dex =15,luc = 5},
                new Status {hp = 40, str = 45, vit = 25, mg = 15, res = 10,agi = 10,dex =20,luc = 20},

                new Status {hp = 60, str = 35, vit = 20, mg = 30, res = 25,agi = 10,dex =20,luc = 20},
                new Status {hp = 55, str = 40, vit = 20, mg = 35, res = 30,agi = 10,dex =20,luc = 20},
                new Status {hp = 65, str = 30, vit = 15, mg = 30, res = 25,agi = 10,dex =25,luc = 25},
                new Status {hp = 50, str = 45, vit = 25, mg = 25, res = 20,agi = 20,dex =20,luc = 20},
            };

            Tarot tarot = new Tarot();
            if (tarot.tarotImage[0] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^0.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;

                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[1] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^1.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[2] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^2.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[3] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^3.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[4] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^4.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[5] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^5.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[6] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^6.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[7] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^7.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[8] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^8.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[9] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^9.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[10] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^10.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[11] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^11.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[12] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^12.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[13] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^13.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[14] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^14.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[15] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^15.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[16] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^16.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[17] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^17.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[18] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^18.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[19] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^19.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[20] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^20.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
            }
            if (tarot.tarotImage[21] == tarot.tarotImage[v])
            {
                StreamReader file = new StreamReader(@"Status\�����p�����[�^21.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();
                walk = true;
                label9.Text = select[v].hp.ToString();
                label10.Text = select[v].str.ToString();
                label11.Text = select[v].vit.ToString();
                label12.Text = select[v].luc.ToString();
                label13.Text = select[v].mg.ToString();
                label14.Text = select[v].res.ToString();
                label15.Text = select[v].agi.ToString();
                label16.Text = select[v].dex.ToString();
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

        int storyNumber;
        internal void StoryText(int n)
        {
            if (n == 0)
            {
                StreamReader file = new StreamReader(@"Story\image0.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 1)
            {
                StreamReader file = new StreamReader(@"Story\image1.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 2)
            {

                StreamReader file = new StreamReader(@"Story\image2.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 3)
            {

                StreamReader file = new StreamReader(@"Story\image3.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 4)
            {
                StreamReader file = new StreamReader(@"Story\image4.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 5)
            {
                StreamReader file = new StreamReader(@"Story\image5.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 6)
            {
                StreamReader file = new StreamReader(@"Story\image6.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 7)
            {
                StreamReader file = new StreamReader(@"Story\image7.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 8)
            {
                StreamReader file = new StreamReader(@"Story\image8.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 9)
            {
                StreamReader file = new StreamReader(@"Story\image9.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 10)
            {
                StreamReader file = new StreamReader(@"Story\image10.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 11)
            {
                StreamReader file = new StreamReader(@"Story\image11.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 12)
            {
                StreamReader file = new StreamReader(@"Story\image12.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 13)
            {
                StreamReader file = new StreamReader(@"Story\image13.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 14)
            {
                StreamReader file = new StreamReader(@"Story\image14.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 15)
            {
                StreamReader file = new StreamReader(@"Story\image15.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 16)
            {
                StreamReader file = new StreamReader(@"Story\image16.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 17)
            {
                StreamReader file = new StreamReader(@"Story\image17.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 18)
            {
                StreamReader file = new StreamReader(@"Story\image18.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 19)
            {
                StreamReader file = new StreamReader(@"Story\image19.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 20)
            {
                StreamReader file = new StreamReader(@"Story\image20.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            if (n == 21)
            {
                StreamReader file = new StreamReader(@"Story\image21.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                storyNumber = n;
            }
            //End
            if (n == 22)
            {
                StreamReader file = new StreamReader(@"Story\EndImage.txt");
                richTextBox1.Text = file.ReadToEnd();
                file.Close();

                wmPlayer.URL = "������  �A�R�[�X�e�B�b�N50.mp3";

                storyNumber = n;
            }
        }

        //form2�̃J�[�h��؂�ւ���
        int counter = 1;
        int num2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (judge && walk)
            {
                //�I�[�f�B�I�t�@�C�����w�肷��
                mediaPlayer.URL = "������ ���ʉ� �p�\�R��01.wav";
                //�Đ�����
                mediaPlayer.controls.play();


                Random random2 = new Random();
                int ran2 = random2.Next(1, 4);
                //int ran2 = 2;   //�X�g�[���[card�f�o�b�O�p

                num2 += ran2;
                if (num2 < 22)
                {
                    cards.StoryCards(num2);
                    counter--;
                    walk = false;
                }
                else
                {
                    cards.EndCards();
                }
            }
        }


        private void CommandSelected(object sender, EventArgs e)
        {
            if (judge)
            {
                string command = commandBox.Text;
                int number = this.comandSelect[command];

                Command(number);
            }
        }

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

        bool battle = false;
        bool walk = false;

        int damage;
        int eDamage;

        Random critical = new Random();

        int enemyNum;
        private async void Command(int co)
        {
            int cri = critical.Next(0, 50);
            //int cri = critical.Next(attack);

            if (storyNumber == 1)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������1.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����1.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������1.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }

            if (storyNumber == 2)
            {
                enemyNum = 0;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader file = new StreamReader(@"Command\�b������2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                }
                if (co == 1 && walk == false)
                {

                    StreamReader file = new StreamReader(@"Command\�a�����2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();


                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;



                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader file = new StreamReader(@"Command\���@���g��2.txt");
                        richTextBox1.Text = file.ReadToEnd();
                        file.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle �e�L�X�g�̃N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader file = new StreamReader(@"Command\��������2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                    walk = true;
                }
            }
            if (storyNumber == 3)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������3.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����3.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������3.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 4)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������4.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����4.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������4.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 5)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������5.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������  �}�W�J��11.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    magic += 10;
                    label13.Text = magic.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����5.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������5.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 6)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������6.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������  �}�W�J��27.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    luck -= 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����6.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��6.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������6.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 7)
            {
                enemyNum = 1;
                battle = true;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������7.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����7.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��7.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle �e�L�X�g�̃N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��7b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[0].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                        writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //�X�e�[�^�X�o�[�ɕ\�L
                        hitP -= damage;

                        if (hitP < 0)
                        {
                            hitP = 0;
                        }
                        label9.Text = hitP.ToString();

                        if (hitP <= 0)
                        {
                            await Task.Delay(2000);

                            GameOver();
                        }
                        await Task.Delay(2000);

                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle == false ||
                    co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������7.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 8)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������8.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������ ���ʉ� �����|�C���g17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    strength += 10;
                    label10.Text = strength.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����8.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��8.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������8.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 9)
            {
                enemyNum = 2;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������9.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    battle = true;

                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����9.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && battle != true ||
                    co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��9a.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��9b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                        battle = true;
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������9.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 10)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������10.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����10.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������10.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 11)
            {
                enemyNum = 3;
                battle = true;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������11.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����11.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��11.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��11b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                        writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //�X�e�[�^�X�o�[�ɕ\�L
                        hitP -= damage;

                        if (hitP < 0)
                        {
                            hitP = 0;
                        }
                        label9.Text = hitP.ToString();

                        if (hitP <= 0)
                        {
                            await Task.Delay(2000);

                            GameOver();
                        }
                        await Task.Delay(2000);

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������11.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 12)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������12.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����12.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������12.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 13)
            {
                enemyNum = 4;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������13.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����13.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��13.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������13.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 14)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������14.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����14.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��14.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��11.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        hitP += 10;
                        label13.Text = magic.ToString();
                        label9.Text = hitP.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������14.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 15)
            {
                enemyNum = 5;
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������15.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����15.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��15.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������15.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 16)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������16.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "������  �}�W�J��11.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();

                    luck += 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����16.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������16.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 17)
            {
                enemyNum = 6;
                battle = true;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������17.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����17.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��17.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��17b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                        writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //�X�e�[�^�X�o�[�ɕ\�L
                        hitP -= damage;

                        if (hitP < 0)
                        {
                            hitP = 0;
                        }
                        label9.Text = hitP.ToString();

                        if (hitP <= 0)
                        {
                            await Task.Delay(2000);

                            GameOver();
                        }
                        await Task.Delay(2000);

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������17.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                    mediaPlayer.URL = "�������퓬17.wav";
                    //�Đ�����
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                    writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //�X�e�[�^�X�o�[�ɕ\�L
                    hitP -= damage;

                    if (hitP < 0)
                    {
                        hitP = 0;
                    }
                    label9.Text = hitP.ToString();

                    if (hitP <= 0)
                    {
                        await Task.Delay(2000);

                        GameOver();
                    }
                    await Task.Delay(2000);

                    using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }

                }
            }
            if (storyNumber == 18)
            {
                enemyNum = 7;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������18.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����18.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��18.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������18.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
            if (storyNumber == 19)
            {
                enemyNum = 8;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������19.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����19.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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

                    //System.Threading.Thread.Sleep(1000);  �g�p����ƃo�O��

                    //�o�g�����\�b�h��
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��19.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �}�W�J��27.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������19.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 20)
            {
                enemyNum = 9;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������20.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����20.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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
                        StreamReader line3 = new StreamReader(@"Command\���@���g��20.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }

                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������20.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
            if (storyNumber == 21)
            {
                enemyNum = 10;
                if (co == 0 && battle == false ||
                    co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\�b������21.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && battle != true)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����21a.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 1 && walk == false && battle == true)
                {
                    StreamReader line2 = new StreamReader(@"Command\�a�����21b.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  �퓬05.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();
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
                        StreamReader line2 = new StreamReader(@"Command\���@���g��21b.txt");
                        richTextBox1.Text = line2.ReadToEnd();
                        line2.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 2 && walk == false && battle == true)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\���@���g��21.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                        mediaPlayer.URL = "������  ��01.wav";
                        //�Đ�����
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //�e�L�X�g�N���A
                        using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }

                        if (enemys[enemyNum].eHp <= 0)
                        {
                            KilledBranch(enemyNum);
                        }
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\���@���g��0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true ||
                    co == 0 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\��������21.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
        }

        //wave�Đ��p���f�B�A�v���C���[�C���X�^���X
        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
        private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
        {

            if (agility >= eAgi)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();


                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();


                //�^�_���[�W
                enemys[enemyNum].eHp -= eDamage;

                if (eHp <= 0)
                {
                    await Task.Delay(1000);

                    KilledBranch(enemyNum);
                }
                else
                {
                    await Task.Delay(2000);

                    SwBattlePost(damage, eDamage, eAgi, eHp);
                }
            }
            else
            {
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writ =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;

                if (hitP < 0)
                {
                    hitP = 0;
                }
                label9.Text = hitP.ToString();

                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }
                else
                {
                    await Task.Delay(2000);

                    SwBattlePost(damage, eDamage, eAgi, eHp);
                }

            }
        }


        private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
        {
            if (agility < eAgi)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}�_���[�W��^����\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();

                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                //�^�_���[�W
                enemys[enemyNum].eHp -= eDamage;

                if (eHp <= 0)
                {
                    await Task.Delay(1000);

                    KilledBranch(enemyNum);
                }

                //battle �e�L�X�g�̃N���A
                using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                {
                    fileStream.SetLength(0);
                }

            }
            else
            {
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writ =
                  new StreamWriter(@"Battle\battle�l.txt", true, sjis);
                writ.WriteLine($"{damage}�_���[�W���󂯂�\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle�l.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
                mediaPlayer.URL = "�������퓬17.wav";
                //�Đ�����
                mediaPlayer.controls.play();

                //�X�e�[�^�X�o�[�ɕ\�L
                hitP -= damage;
                if (hitP < 0)
                {
                    hitP = 0;
                }
                label9.Text = hitP.ToString();

                if (hitP <= 0)
                {
                    await Task.Delay(2000);

                    GameOver();
                }


                //battle �e�L�X�g�̃N���A
                using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
                {
                    fileStream.SetLength(0);
                }
            }
        }

        private async void KilledBranch(int enemyNom)
        {
            await Task.Delay(1000);

            if (enemyNom == 0)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle2.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 1 || enemyNom == 3)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle7.11.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 2)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle9.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 4)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle13.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 5)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle15.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 6)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle17.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 7)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle18.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 8)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle19.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 9)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle20.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }
            if (enemyNom == 10)
            {
                StreamReader line1 = new StreamReader(@"Battle\battle21.txt");
                richTextBox1.Text = line1.ReadToEnd();
            }

            //�I�[�f�B�I�t�@�C�����w�肷��i�����I�ɍĐ������j
            mediaPlayer.URL = "������  �퓬16.wav";
            //�Đ�����
            mediaPlayer.controls.play();

            //�e�L�X�g�N���A
            using (var fileStream = new FileStream(@"Battle\battle�l.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }
            walk = true;
            battle = false;
        }

        private void GameOver()
        {
            StreamReader file = new StreamReader(@"Story\GameOver.txt");
            richTextBox1.Text = file.ReadToEnd();
            file.Close();

            wmPlayer.URL = "������  �A�R�[�X�e�B�b�N31.mp3";

            //this.BackColor = Color.FromArgb(0, 0, 0);

            walk = true;

            cards.GameOverCards();
        }
    }
}
}

// Update is called once per frame
void Update()
{

}
}
