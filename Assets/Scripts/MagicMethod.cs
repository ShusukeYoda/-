using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagicMethod : MonoBehaviour
{
    CommandSelect all;
    Tarot tarot;
    EnemyList enemyList;
    public GameObject TextTMP;
    GameObject SE4;
    GameObject SE6;
    GameObject SE8;
    public GameObject Te0;
    GameObject Te3;
    public GameObject Te4;
    GameOverMethod GameOverMethod;
    KilledBranch killedBranch;

    // Start is called before the first frame update
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<CommandSelect>();
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.enemyList = GameObject.Find("EnemyList").GetComponent<EnemyList>();
        this.TextTMP = GameObject.Find("TextTMP");
        this.SE4 = GameObject.Find("magicAttack1SE");
        this.SE6 = GameObject.Find("magicSE");
        this.SE8 = GameObject.Find("recoverySE");
        this.Te0 = GameObject.Find("Te0");
        this.Te3 = GameObject.Find("Te3");
        this.Te4 = GameObject.Find("Te4");
        this.GameOverMethod = GameObject.Find("GameOver").GetComponent<GameOverMethod>();
        this.killedBranch = GameObject.Find("KilledBranch").GetComponent<KilledBranch>();
    }
    public async Task magicAttack()
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load($"魔法を使う{all.sNum}") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            all.battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            all.eDamage = tarot.mAttack - enemyList.enemys[all.enemyNum].eRes;
            enemyList.enemys[all.enemyNum].eHp -= all.eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ all.eDamage}ダメージを与えた";

            await Task.Delay(2000);
            //与ダメージ
            enemyList.enemys[all.enemyNum].eHp -= all.eDamage;

            //倒したとき
            if (enemyList.enemys[all.enemyNum].eHp <= 0)
            {
                killedBranch.destroyingBranch(all.enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }
    // 7.11.17
    public async Task magicAttackExistsRisk() 
    {
        if (tarot.magic >= 5)
        {
            SE4.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load($"魔法を使う{all.sNum}") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            all.battle = true;

            await Task.Delay(2000);

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            all.eDamage = tarot.mAttack - enemyList.enemys[all.enemyNum].eRes;
            enemyList.enemys[all.enemyNum].eHp -= all.eDamage;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ all.eDamage}ダメージを与えた";

            await Task.Delay(2000);
            //与ダメージ
            enemyList.enemys[all.enemyNum].eHp -= all.eDamage;

            //倒したとき
            if (enemyList.enemys[all.enemyNum].eHp <= 0)
            {
                killedBranch.destroyingBranch(all.enemyNum);
            }
        }
        else
        {
            var textAsset = Resources.Load($"魔法を使う{all.sNum}b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            await Task.Delay(2000);

            all.damage = tarot.attack - enemyList.enemys[all.enemyNum].eDef;

            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{all.damage}ダメージを受けた";
            UnityEngine.Debug.Log("チェックポイント");
            //

            await GameOverMethod.PreGameOver();
            await Task.Delay(2000);
        }
    }
    public void magic21()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("魔法を使う21b") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    public void magicInvisible()
    {
        if (tarot.magic >= 5)
        {
            SE6.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う19") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();


            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            all.walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }
    public void magicSleep()
    {
        if (tarot.magic >= 5)
        {
            SE6.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う15") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();

            all.walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    public void magicRecovery()
    {
        if (tarot.magic >= 5)
        {
            SE8.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う14") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            tarot.hitP += 10;
            Te4.GetComponent<Text>().text = tarot.magic.ToString();
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            all.walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    public void magic8()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("魔法を使う8") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    public void magic6()
    {
        if (tarot.magic >= 5)
        {
            var textAsset = Resources.Load("魔法を使う6") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }

    public void magic1Method()
    {
        if (tarot.magic >= 5)
        {
            SE8.GetComponent<AudioSource>().Play();

            var textAsset = Resources.Load("魔法を使う1") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

            tarot.magic -= 5;
            tarot.luck += 5;

            Te4.GetComponent<Text>().text = tarot.magic.ToString();
            Te3.GetComponent<Text>().text = tarot.luck.ToString();
            /*
            magic -= 5;     //UIテスト
            Te4.GetComponent<Text>().text = magic.ToString();
            UnityEngine.Debug.Log(magic);
            */
            all.walk = true;
        }
        else
        {
            var textAsset = Resources.Load("魔法を使う0") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();
        }
    }
}
