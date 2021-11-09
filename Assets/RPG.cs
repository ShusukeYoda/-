using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cards試作１
{
    public class RPG : MonoBehaviour
    {
        //フォーム２インスタンス；
        //Cards cards;

        // Start is called before the first frame update
        void Start()
        {

        //タロット用ランダム変数とカウンター(秒)
        Random random = new Random();
        public int count;
        //タロットスタート：タイマー
        Timer timer;
        private void button1_Click(object sender, EventArgs e)
        {
            if (judge == false)
            {
                //オーディオファイルを指定する
                mediaPlayer.URL = "魔王魂水12.wav";
                //再生する
                mediaPlayer.controls.play();

                timer.Start();                                           //スタート
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

        //アニメーションgif用
        Bitmap animated;
        //ウィンドウズメディアプレイヤー
        WindowsMediaPlayer wmPlayer;
        //コンボボックス
        Dictionary<string, int> comandSelect;
        private void Form1_Load(object sender, EventArgs e)
        {
            // アニメーションgifの設定
            animated = new Bitmap("round_white.gif");
            gifBox.Image = animated;
            // pictureBoxのPaintイベントハンドラ
            gifBox.Paint += pictureBox_Paint;
            // アニメーション開始
            ImageAnimator.Animate(animated, new EventHandler(Image_FrameChanged));


            //mp3プレイヤー(wmp)
            wmPlayer = new WindowsMediaPlayer();
            //wmPlayer.settings.autoStart = false;  //開始時にはコメントアウト
            wmPlayer.URL = "魔王魂ピアノ35.mp3";

            //コンボボックス
            comandSelect = new Dictionary<string, int>();

            comandSelect.Add("話をする", 0);
            comandSelect.Add("斬りつける", 1);
            comandSelect.Add("魔法を使う", 2);
            comandSelect.Add("立ち去る", 3);

            foreach (KeyValuePair<string, int> command in this.comandSelect)
            {
                commandBox.Items.Add(command.Key);
            }
            //commandBox.Text = "DropDownList";

            //battle テキストのクリア
            using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }

            //オープニングテキスト
            StreamReader file = new StreamReader(@"Story\Start.txt");
            richTextBox1.Text = file.ReadToEnd();
            file.Close();


            //タロット用タイマー
            timer = new Timer();

            timer.Interval = 100;
            timer.Tick += OnTimer1;                                 //オンタイマー

            //フォーム２の表示
            this.cards = new Cards(this);
            cards.Show();
        }
        private void Image_FrameChanged(object sender, EventArgs e)
        {
            // Paintイベントハンドラを呼び出す
            gifBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // フレームの更新
            ImageAnimator.UpdateFrames(animated);
            // 画像の描画
            e.Graphics.DrawImage(animated, 0, 0);
        }


        // タロット選択ボタン
        bool judge = false;
        string line;
        private void button2_Click(object sender, EventArgs e)
        {
            Tarot tarot = new Tarot();
            timer.Stop();                                           //ストップ

            if (judge == false)
            {
                //オーディオファイルを指定する
                mediaPlayer.URL = "魔王魂カード決14.wav";
                //再生する
                mediaPlayer.controls.play();

                if (pictureBox1.ImageLocation == tarot.tarotImage[0])
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

        public class Status
        {
            public int hp;

            public int str; public int vit;

            public int mg; public int res;

            public int agi; public int dex; public int luc;

            //public int wt = 510; //WT = クラス基本値+510-AGI+装備重量

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
                StreamReader file = new StreamReader(@"Status\初期パラメータ0.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ1.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ2.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ3.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ4.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ5.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ6.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ7.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ8.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ9.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ10.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ11.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ12.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ13.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ14.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ15.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ16.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ17.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ18.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ19.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ20.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ21.txt");
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


            //プレイヤーステータス
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

                wmPlayer.URL = "魔王魂  アコースティック50.mp3";

                storyNumber = n;
            }
        }

        //form2のカードを切り替える
        int counter = 1;
        int num2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (judge && walk)
            {
                //オーディオファイルを指定する
                mediaPlayer.URL = "魔王魂 効果音 パソコン01.wav";
                //再生する
                mediaPlayer.controls.play();


                Random random2 = new Random();
                int ran2 = random2.Next(1, 4);
                //int ran2 = 2;   //ストーリーcardデバッグ用

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
                new Status {eHp = 30,eAtt = 35 ,eDef=5, eRes = 5, eAgi = 10},　//１騎士

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//２山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//３山賊(測)

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//４山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//５冒険者

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//６若者

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 20},　//７屈強な

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//８正規兵

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//９傭兵

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//１０正規兵ら

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10}　 //１１住人
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
                    StreamReader line1 = new StreamReader(@"Command\話をする1.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける1.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る1.txt");
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
                    StreamReader file = new StreamReader(@"Command\話をする2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                }
                if (co == 1 && walk == false)
                {

                    StreamReader file = new StreamReader(@"Command\斬りつける2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();


                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;



                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader file = new StreamReader(@"Command\魔法を使う2.txt");
                        richTextBox1.Text = file.ReadToEnd();
                        file.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle テキストのクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader file = new StreamReader(@"Command\立ち去る2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                    walk = true;
                }
            }
            if (storyNumber == 3)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする3.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける3.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る3.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 4)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする4.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける4.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る4.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 5)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする5.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂  マジカル11.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    magic += 10;
                    label13.Text = magic.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける5.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る5.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 6)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする6.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂  マジカル27.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    luck -= 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける6.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う6.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る6.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする7.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける7.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う7.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle テキストのクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う7b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[0].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle値.txt", true, sjis);
                        writ.WriteLine($"{damage}ダメージを受けた\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //ステータスバーに表記
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

                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle == false ||
                    co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る7.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 8)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする8.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂 効果音 ワンポイント17.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    strength += 10;
                    label10.Text = strength.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける8.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う8.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る8.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする9.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    battle = true;

                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける9.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && battle != true ||
                    co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う9a.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う9b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                        battle = true;
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る9.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 10)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする10.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける10.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る10.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする11.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける11.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う11.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う11b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle値.txt", true, sjis);
                        writ.WriteLine($"{damage}ダメージを受けた\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //ステータスバーに表記
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

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る11.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 12)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする12.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける12.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る12.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする13.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける13.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う13.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る13.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 14)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする14.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける14.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う14.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル11.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        hitP += 10;
                        label13.Text = magic.ToString();
                        label9.Text = hitP.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る14.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする15.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける15.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う15.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る15.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 16)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする16.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂  マジカル11.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    luck += 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける16.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る16.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする17.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける17.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う17.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
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
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う17b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle値.txt", true, sjis);
                        writ.WriteLine($"{damage}ダメージを受けた\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //ステータスバーに表記
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

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る17.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                    StreamReader line1 = new StreamReader(@"Command\話をする18.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける18.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う18.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る18.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする19.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける19.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う19.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る19.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする20.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける20.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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


                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う20.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }

                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る20.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする21.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && battle != true)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける21a.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 1 && walk == false && battle == true)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける21b.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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


                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }

                if (co == 2 && battle != true)
                {
                    if (magic >= 5)
                    {
                        StreamReader line2 = new StreamReader(@"Command\魔法を使う21b.txt");
                        richTextBox1.Text = line2.ReadToEnd();
                        line2.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 2 && walk == false && battle == true)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う21.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true ||
                    co == 0 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る21.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
        }

        //wave再生用メディアプレイヤーインスタンス
        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
        private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
        {

            if (agility >= eAgi)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}ダメージを与えた\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();


                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();


                //与ダメージ
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
                  new StreamWriter(@"Battle\battle値.txt", true, sjis);
                writ.WriteLine($"{damage}ダメージを受けた\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();

                //ステータスバーに表記
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
                  new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}ダメージを与えた\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();

                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();

                //与ダメージ
                enemys[enemyNum].eHp -= eDamage;

                if (eHp <= 0)
                {
                    await Task.Delay(1000);

                    KilledBranch(enemyNum);
                }

                //battle テキストのクリア
                using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                {
                    fileStream.SetLength(0);
                }

            }
            else
            {
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writ =
                  new StreamWriter(@"Battle\battle値.txt", true, sjis);
                writ.WriteLine($"{damage}ダメージを受けた\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();

                //ステータスバーに表記
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


                //battle テキストのクリア
                using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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

            //オーディオファイルを指定する（自動的に再生される）
            mediaPlayer.URL = "魔王魂  戦闘16.wav";
            //再生する
            mediaPlayer.controls.play();

            //テキストクリア
            using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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

            wmPlayer.URL = "魔王魂  アコースティック31.mp3";

            //this.BackColor = Color.FromArgb(0, 0, 0);

            walk = true;

            cards.GameOverCards();
        }
    }
}
namespace cards試作１
{
    public partial class Form1 : Form
    {
        //フォーム２インスタンス；
        Cards cards;

        public Form1()
        {
            InitializeComponent();

            //Foamの初期位置
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(700, 250);

            //this.Load += new EventHandler(Form1_Load);    onだとコマンド増殖
            this.Controls.Add(gifBox);
            //gifBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        //タロットイメージ
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

        //タロット用ランダム変数とカウンター(秒)
        Random random = new Random();
        public int count;
        //タロットスタート：タイマー
        Timer timer;
        private void button1_Click(object sender, EventArgs e)
        {
            if (judge == false)
            {
                //オーディオファイルを指定する
                mediaPlayer.URL = "魔王魂水12.wav";
                //再生する
                mediaPlayer.controls.play();

                timer.Start();                                           //スタート
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

        //アニメーションgif用
        Bitmap animated;
        //ウィンドウズメディアプレイヤー
        WindowsMediaPlayer wmPlayer;
        //コンボボックス
        Dictionary<string, int> comandSelect;
        private void Form1_Load(object sender, EventArgs e)
        {
            // アニメーションgifの設定
            animated = new Bitmap("round_white.gif");
            gifBox.Image = animated;
            // pictureBoxのPaintイベントハンドラ
            gifBox.Paint += pictureBox_Paint;
            // アニメーション開始
            ImageAnimator.Animate(animated, new EventHandler(Image_FrameChanged));


            //mp3プレイヤー(wmp)
            wmPlayer = new WindowsMediaPlayer();
            //wmPlayer.settings.autoStart = false;  //開始時にはコメントアウト
            wmPlayer.URL = "魔王魂ピアノ35.mp3";

            //コンボボックス
            comandSelect = new Dictionary<string, int>();

            comandSelect.Add("話をする", 0);
            comandSelect.Add("斬りつける", 1);
            comandSelect.Add("魔法を使う", 2);
            comandSelect.Add("立ち去る", 3);

            foreach (KeyValuePair<string, int> command in this.comandSelect)
            {
                commandBox.Items.Add(command.Key);
            }
            //commandBox.Text = "DropDownList";

            //battle テキストのクリア
            using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }

            //オープニングテキスト
            StreamReader file = new StreamReader(@"Story\Start.txt");
            richTextBox1.Text = file.ReadToEnd();
            file.Close();


            //タロット用タイマー
            timer = new Timer();

            timer.Interval = 100;
            timer.Tick += OnTimer1;                                 //オンタイマー

            //フォーム２の表示
            this.cards = new Cards(this);
            cards.Show();
        }
        private void Image_FrameChanged(object sender, EventArgs e)
        {
            // Paintイベントハンドラを呼び出す
            gifBox.Invalidate();
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // フレームの更新
            ImageAnimator.UpdateFrames(animated);
            // 画像の描画
            e.Graphics.DrawImage(animated, 0, 0);
        }


        // タロット選択ボタン
        bool judge = false;
        string line;
        private void button2_Click(object sender, EventArgs e)
        {
            Tarot tarot = new Tarot();
            timer.Stop();                                           //ストップ

            if (judge == false)
            {
                //オーディオファイルを指定する
                mediaPlayer.URL = "魔王魂カード決14.wav";
                //再生する
                mediaPlayer.controls.play();

                if (pictureBox1.ImageLocation == tarot.tarotImage[0])
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

        public class Status
        {
            public int hp;

            public int str; public int vit;

            public int mg; public int res;

            public int agi; public int dex; public int luc;

            //public int wt = 510; //WT = クラス基本値+510-AGI+装備重量

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
                StreamReader file = new StreamReader(@"Status\初期パラメータ0.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ1.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ2.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ3.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ4.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ5.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ6.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ7.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ8.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ9.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ10.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ11.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ12.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ13.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ14.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ15.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ16.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ17.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ18.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ19.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ20.txt");
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
                StreamReader file = new StreamReader(@"Status\初期パラメータ21.txt");
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


            //プレイヤーステータス
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

                wmPlayer.URL = "魔王魂  アコースティック50.mp3";

                storyNumber = n;
            }
        }

        //form2のカードを切り替える
        int counter = 1;
        int num2;
        private void button3_Click(object sender, EventArgs e)
        {
            if (judge && walk)
            {
                //オーディオファイルを指定する
                mediaPlayer.URL = "魔王魂 効果音 パソコン01.wav";
                //再生する
                mediaPlayer.controls.play();


                Random random2 = new Random();
                int ran2 = random2.Next(1, 4);
                //int ran2 = 2;   //ストーリーcardデバッグ用

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
                new Status {eHp = 30,eAtt = 35 ,eDef=5, eRes = 5, eAgi = 10},　//１騎士

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//２山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//３山賊(測)

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10},　//４山賊

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//５冒険者

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//６若者

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 20},　//７屈強な

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//８正規兵

                new Status {eHp = 35,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 15},　//９傭兵

                new Status {eHp = 40,eAtt = 45 ,eDef=15, eRes = 5, eAgi = 10},　//１０正規兵ら

                new Status {eHp = 30,eAtt = 40 ,eDef=15, eRes = 5, eAgi = 10}　 //１１住人
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
                    StreamReader line1 = new StreamReader(@"Command\話をする1.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける1.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る1.txt");
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
                    StreamReader file = new StreamReader(@"Command\話をする2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                }
                if (co == 1 && walk == false)
                {

                    StreamReader file = new StreamReader(@"Command\斬りつける2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();


                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;



                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader file = new StreamReader(@"Command\魔法を使う2.txt");
                        richTextBox1.Text = file.ReadToEnd();
                        file.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle テキストのクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader file = new StreamReader(@"Command\立ち去る2.txt");
                    richTextBox1.Text = file.ReadToEnd();
                    file.Close();
                    walk = true;
                }
            }
            if (storyNumber == 3)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする3.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける3.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る3.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 4)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする4.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける4.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る4.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 5)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする5.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂  マジカル11.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    magic += 10;
                    label13.Text = magic.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける5.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る5.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 6)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする6.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂  マジカル27.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    luck -= 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける6.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う6.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る6.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする7.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける7.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う7.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //battle テキストのクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う7b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[0].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle値.txt", true, sjis);
                        writ.WriteLine($"{damage}ダメージを受けた\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //ステータスバーに表記
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

                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle == false ||
                    co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る7.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 8)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする8.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂 効果音 ワンポイント17.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    strength += 10;
                    label10.Text = strength.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける8.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う8.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る8.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする9.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    battle = true;

                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける9.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && battle != true ||
                    co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う9a.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う9b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                        battle = true;
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る9.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 10)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする10.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける10.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る10.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする11.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける11.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う11.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う11b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle値.txt", true, sjis);
                        writ.WriteLine($"{damage}ダメージを受けた\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //ステータスバーに表記
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

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る11.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
            }
            if (storyNumber == 12)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする12.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける12.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る12.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする13.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける13.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う13.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る13.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 14)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする14.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける14.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う14.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル11.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        hitP += 10;
                        label13.Text = magic.ToString();
                        label9.Text = hitP.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る14.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする15.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける15.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う15.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る15.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();
                    walk = true;
                }
            }
            if (storyNumber == 16)
            {
                if (co == 0 && walk == false)
                {
                    StreamReader line1 = new StreamReader(@"Command\話をする16.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂  マジカル11.wav";
                    //再生する
                    mediaPlayer.controls.play();

                    luck += 10;
                    label12.Text = luck.ToString();

                    walk = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける16.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う1.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        luck += 5;
                        label13.Text = magic.ToString();
                        label12.Text = luck.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る16.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする17.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける17.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う17.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
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
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う17b.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();


                        await Task.Delay(2000);

                        damage = attack - enemys[enemyNum].eDef;

                        Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writ =
                          new StreamWriter(@"Battle\battle値.txt", true, sjis);
                        writ.WriteLine($"{damage}ダメージを受けた\n");
                        writ.Close();


                        StreamReader df = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = df.ReadToEnd();
                        df.Close();

                        //ステータスバーに表記
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

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                        {
                            fileStream.SetLength(0);
                        }
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る17.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();


                    //オーディオファイルを指定する（自動的に再生される）
                    mediaPlayer.URL = "魔王魂戦闘17.wav";
                    //再生する
                    mediaPlayer.controls.play();


                    await Task.Delay(2000);

                    damage = attack - enemys[enemyNum].eDef;

                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writ =
                      new StreamWriter(@"Battle\battle値.txt", true, sjis);
                    writ.WriteLine($"{damage}ダメージを受けた\n");
                    writ.Close();


                    StreamReader df = new StreamReader(@"Battle\battle値.txt",
                    Encoding.GetEncoding("Shift_JIS"), false);
                    richTextBox1.Text = df.ReadToEnd();
                    df.Close();

                    //ステータスバーに表記
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

                    using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                    StreamReader line1 = new StreamReader(@"Command\話をする18.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける18.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う18.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る18.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする19.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;
                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける19.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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

                    //System.Threading.Thread.Sleep(1000);  使用するとバグる

                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う19.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  マジカル27.wav";
                        //再生する
                        mediaPlayer.controls.play();

                        magic -= 5;
                        label13.Text = magic.ToString();

                        walk = true;
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る19.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする20.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && walk == false)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける20.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    battle = true;

                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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


                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }
                if (co == 2 && walk == false)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う20.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }

                if (co == 3 && battle != true)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る20.txt");
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
                    StreamReader line1 = new StreamReader(@"Command\話をする21.txt");
                    richTextBox1.Text = line1.ReadToEnd();
                    line1.Close();

                    battle = true;

                }
                if (co == 1 && battle != true)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける21a.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();
                }
                if (co == 1 && walk == false && battle == true)
                {
                    StreamReader line2 = new StreamReader(@"Command\斬りつける21b.txt");
                    richTextBox1.Text = line2.ReadToEnd();
                    line2.Close();

                    //battle
                    if (cri <= luck)
                    {
                        eDamage = attack * 2 - enemys[enemyNum].eDef;
                        damage = enemys[enemyNum].eAtt - defense;

                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  戦闘05.wav";
                        //再生する
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


                    //バトルメソッドへ
                    SwBattlePre(damage, eDamage, enemys[enemyNum].eAgi, enemys[enemyNum].eHp);
                }

                if (co == 2 && battle != true)
                {
                    if (magic >= 5)
                    {
                        StreamReader line2 = new StreamReader(@"Command\魔法を使う21b.txt");
                        richTextBox1.Text = line2.ReadToEnd();
                        line2.Close();
                    }
                    else
                    {
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }
                }
                if (co == 2 && walk == false && battle == true)
                {
                    if (magic >= 5)
                    {
                        StreamReader line3 = new StreamReader(@"Command\魔法を使う21.txt");
                        richTextBox1.Text = line3.ReadToEnd();
                        line3.Close();


                        //オーディオファイルを指定する（自動的に再生される）
                        mediaPlayer.URL = "魔王魂  炎01.wav";
                        //再生する
                        mediaPlayer.controls.play();


                        battle = true;

                        await Task.Delay(2000);

                        magic -= 5;
                        label13.Text = magic.ToString();

                        eDamage = mAttack - enemys[enemyNum].eRes;
                        enemys[enemyNum].eHp -= eDamage;

                        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                        StreamWriter writer =
                          new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                        writer.WriteLine($"{eDamage}ダメージを与えた\n");
                        writer.Close();

                        StreamReader at = new StreamReader(@"Battle\battle値.txt",
                        Encoding.GetEncoding("Shift_JIS"), false);
                        richTextBox1.Text = at.ReadToEnd();
                        at.Close();

                        //テキストクリア
                        using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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
                        StreamReader line0 = new StreamReader(@"Command\魔法を使う0.txt");
                        richTextBox1.Text = line0.ReadToEnd();
                        line0.Close();
                    }

                }
                if (co == 3 && battle != true ||
                    co == 0 && walk == false)
                {
                    StreamReader line4 = new StreamReader(@"Command\立ち去る21.txt");
                    richTextBox1.Text = line4.ReadToEnd();
                    line4.Close();

                    battle = true;
                }
            }
        }

        //wave再生用メディアプレイヤーインスタンス
        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
        private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
        {

            if (agility >= eAgi)
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer =
                  new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}ダメージを与えた\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();


                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();


                //与ダメージ
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
                  new StreamWriter(@"Battle\battle値.txt", true, sjis);
                writ.WriteLine($"{damage}ダメージを受けた\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();

                //ステータスバーに表記
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
                  new StreamWriter(@"Battle\battle値.txt", true, sjisEnc);
                writer.WriteLine($"{eDamage}ダメージを与えた\n");
                writer.Close();


                StreamReader at = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = at.ReadToEnd();
                at.Close();

                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();

                //与ダメージ
                enemys[enemyNum].eHp -= eDamage;

                if (eHp <= 0)
                {
                    await Task.Delay(1000);

                    KilledBranch(enemyNum);
                }

                //battle テキストのクリア
                using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
                {
                    fileStream.SetLength(0);
                }

            }
            else
            {
                Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writ =
                  new StreamWriter(@"Battle\battle値.txt", true, sjis);
                writ.WriteLine($"{damage}ダメージを受けた\n");
                writ.Close();


                StreamReader df = new StreamReader(@"Battle\battle値.txt",
                Encoding.GetEncoding("Shift_JIS"), false);
                richTextBox1.Text = df.ReadToEnd();
                df.Close();

                //オーディオファイルを指定する（自動的に再生される）
                mediaPlayer.URL = "魔王魂戦闘17.wav";
                //再生する
                mediaPlayer.controls.play();

                //ステータスバーに表記
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


                //battle テキストのクリア
                using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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

            //オーディオファイルを指定する（自動的に再生される）
            mediaPlayer.URL = "魔王魂  戦闘16.wav";
            //再生する
            mediaPlayer.controls.play();

            //テキストクリア
            using (var fileStream = new FileStream(@"Battle\battle値.txt", FileMode.Open))
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

            wmPlayer.URL = "魔王魂  アコースティック31.mp3";

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
