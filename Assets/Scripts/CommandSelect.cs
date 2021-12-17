using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Text = UnityEngine.UI.Text;

public class CommandSelect : MonoBehaviour
{
    Tarot tarot;
    EnemyList enemyList;
    public List<Sprite> images;    
    GameOverMethod GameOverMethod;
    AttackMethod attackMethod;
    MagicMethod magicMethod;

    //�e�L�X�g
    public GameObject Te0;
    GameObject Te1;
    GameObject Te3;
    public GameObject Te4;
    public GameObject TextTMP;

    //BGM
    GameObject Audio1;
    //SE
    GameObject SE1;
    GameObject SE6;
    GameObject SE7;

    // Start is called before the first frame update
    void Start()
    {
        //Find
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.GameOverMethod = GameObject.Find("GameOver").GetComponent<GameOverMethod>();
        this.attackMethod = GameObject.Find("AttackMethod").GetComponent<AttackMethod>();
        this.magicMethod = GameObject.Find("MagicMethod").GetComponent<MagicMethod>();
        this.enemyList = GameObject.Find("EnemyList").GetComponent<EnemyList>();
        this.Te0 = GameObject.Find("Te0");
        this.Te1 = GameObject.Find("Te1");
        this.Te3 = GameObject.Find("Te3");
        this.Te4 = GameObject.Find("Te4");
        this.TextTMP = GameObject.Find("TextTMP");

        this.Audio1 = GameObject.Find("BGM");
        this.SE1 = GameObject.Find("attackDamegeSE");
        this.SE6 = GameObject.Find("magicSE");
        this.SE7 = GameObject.Find("onePointSE");

        Audio1.GetComponent<AudioSource>().Play();
    }

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
    public bool battle = false;

    public bool critical = false;
    public int damage;
    public int eDamage;
    public int cri;
    public int enemyNum;

    #region �R�}���h�Z���N�g
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
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttack();
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
                magicMethod.magic1Method();
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
                magicMethod.magic6();
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

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                //�X�e�[�^�X�o�[�ɕ\�L
                await GameOverMethod.PreGameOver();
                await Task.Delay(2000);
            }
            if (command == 1 && walk == false)
            {
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttackExistsRisk();
            }
            if (command == 3 && battle == false ||
                command == 3 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("��������7") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await GameOverMethod.PreGameOver();
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
                magicMethod.magic8();
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

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await GameOverMethod.PreGameOver();
                await Task.Delay(2000);
            }

            if (command == 1 && walk == false)
            {
                attackMethod.Attack();
            }
            if (command == 2 && battle != true ||
                command == 2 && walk == false)
            {
                await magicMethod.magicAttack();

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

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await GameOverMethod.PreGameOver();
                await Task.Delay(2000);
            }
            if (command == 1 && walk == false)
            {
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttackExistsRisk();

            }
            if (command == 3 && walk == false)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("��������11") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


                await Task.Delay(2000);

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await GameOverMethod.PreGameOver();
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
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttack();

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
                magicMethod.magicRecovery();
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
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                magicMethod.magicSleep();
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
                magicMethod.magic1Method();
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

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await GameOverMethod.PreGameOver();
                await Task.Delay(2000);
            }
            if (command == 1 && walk == false)
            {
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttackExistsRisk();

            }
            if (command == 3 && battle != true)
            {
                SE1.GetComponent<AudioSource>().Play();

                var textAsset = Resources.Load("��������17") as TextAsset;
                TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

                await Task.Delay(2000);

                damage = tarot.attack - enemyList.enemys[enemyNum].eDef;

                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}�_���[�W���󂯂�";
                UnityEngine.Debug.Log("�`�F�b�N�|�C���g");
                //

                await GameOverMethod.PreGameOver();
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
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttack();

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
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                magicMethod.magicInvisible();
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
                attackMethod.Attack();
            }
            if (command == 2 && walk == false)
            {
                await magicMethod.magicAttack();

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
                attackMethod.Attack();
            }

            if (command == 2 && battle != true)
            {
                magicMethod.magic21();
            }
            if (command == 2 && walk == false && battle == true)
            {
                await magicMethod.magicAttack();

            }
            if (command == 3 && battle != true ||
                command == 0 && walk == false)
            {
                Leave();
            }
        }
    }

    #endregion

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
            magicMethod.magic1Method();
        }
        if (command== 3 && walk == false)
        {
            var textAsset = Resources.Load($"��������{sNum}") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            walk = true;
        }
    }
}
