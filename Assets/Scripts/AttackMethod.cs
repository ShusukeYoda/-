using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackMethod : MonoBehaviour
{
    All all;
    Tarot tarot;
    public GameObject TextTMP;
    GameObject SE1;
    GameObject SE2;
    public GameObject Te0;
    GameOverMethod GameOverMethod;


    // Start is called before the first frame update
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<All>();
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.TextTMP = GameObject.Find("TextTMP");
        this.SE1 = GameObject.Find("attackDamegeSE");
        this.SE2 = GameObject.Find("criticalSE");
        this.Te0 = GameObject.Find("Te0");
        this.GameOverMethod = GameObject.Find("GameOver").GetComponent<GameOverMethod>();

    }
    public void Attack()
    {
        var textAsset = Resources.Load($"斬りつける{all.sNum}") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        all.battle = true;

        if (all.cri <= tarot.luck)
        {
            all.critical = true;

            all.eDamage = tarot.attack * 2 - all.enemys[all.enemyNum].eDef;
        }
        else
        {
            all.eDamage = tarot.attack - all.enemys[all.enemyNum].eDef;
        }
        all.damage = all.enemys[all.enemyNum].eAtt - tarot.defense;

        if (all.eDamage < 0)
        {
            all.eDamage = 0;
        }
        if (all.damage < 0)
        {
            all.damage = 0;
        }

        SwBattlePre(all.damage, all.eDamage, all.enemys[all.enemyNum].eAgi, all.enemys[all.enemyNum].eHp);
    }

    public bool destroy = false;
    private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
    {
        if (tarot.agility >= eAgi)
        {
            if (all.critical)
            {
                SE2.GetComponent<AudioSource>().Play();
                all.critical = false;
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{eDamage}ダメージを与えた";

                //与ダメージ
                all.enemys[all.enemyNum].eHp -= eDamage;

                await Task.Delay(2000);
                //倒したとき
                if (all.enemys[all.enemyNum].eHp <= 0)
                {
                    destroy = true;
                    all.KilledBranch(all.enemyNum);
                }
                if (destroy == false)
                {
                    SwBattlePost(damage, eDamage, eAgi, eHp);
                }
            }
            else
            {
                SE1.GetComponent<AudioSource>().Play();
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{eDamage}ダメージを与えた";

                //与ダメージ
                all.enemys[all.enemyNum].eHp -= eDamage;

                await Task.Delay(2000);
                //倒したとき
                if (all.enemys[all.enemyNum].eHp <= 0)
                {
                    destroy = true;
                    all.KilledBranch(all.enemyNum);
                }
                if (destroy == false)
                {
                    SwBattlePost(damage, eDamage, eAgi, eHp);
                }
            }
        }
        else if(tarot.agility < eAgi)
        {
            SE1.GetComponent<AudioSource>().Play();
            TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            //被ダメージ
            tarot.hitP -= all.damage;
            Te0.GetComponent<Text>().text = tarot.hitP.ToString();

            if (tarot.hitP <= 0)
            {
                await GameOverMethod.PreGameOver();
            }

            if (destroy == false || GameOverMethod.gameover == false)
            {
                //続行：通常
                await Task.Delay(2000);

                SwBattlePost(damage, eDamage, eAgi, eHp);
            }
        }
    }

    private async void SwBattlePost(int damage, int eDamage, int eAgi, int eHp)
    {
        if (destroy == false)
        {
            if (tarot.agility >= eAgi)
            {
                SE1.GetComponent<AudioSource>().Play();
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{damage}ダメージを受けた";
                Te0.GetComponent<Text>().text = tarot.hitP.ToString();

                //被ダメージ
                tarot.hitP -= damage;
                Te0.GetComponent<Text>().text = tarot.hitP.ToString();

                if (tarot.hitP <= 0)
                {
                    await GameOverMethod.PreGameOver();
                }
                await Task.Delay(2000);
            }
            else if (tarot.agility < eAgi)
            {
                if (all.critical)
                {
                    SE2.GetComponent<AudioSource>().Play();
                    all.critical = false;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{eDamage}ダメージを与えた";

                    //与ダメージ
                    all.enemys[all.enemyNum].eHp -= eDamage;

                    await Task.Delay(2000);
                    //倒したとき
                    if (all.enemys[all.enemyNum].eHp <= 0)
                    {
                        destroy = true;
                        all.KilledBranch(all.enemyNum);
                    }
                }
                else
                {
                    SE1.GetComponent<AudioSource>().Play();
                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";

                    //与ダメージ
                    all.enemys[all.enemyNum].eHp -= eDamage;

                    await Task.Delay(2000);
                    //倒したとき
                    if (all.enemys[all.enemyNum].eHp <= 0)
                    {
                        all.KilledBranch(all.enemyNum);
                    }
                }
            }
        }
        else if (destroy) destroy = false;
    }
}
