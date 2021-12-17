using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackMethod : MonoBehaviour
{
    CommandSelect CSelect;
    Tarot tarot;
    EnemyList enemyList;
    public GameObject TextTMP;
    GameObject SE1;
    GameObject SE2;
    public GameObject Te0;
    GameOverMethod GameOverMethod;
    KilledBranch killedBranch;

    // Start is called before the first frame update
    void Start()
    {
        this.CSelect = GameObject.Find("Main Camera").GetComponent<CommandSelect>();
        this.tarot = GameObject.Find("card").GetComponent<Tarot>();
        this.enemyList = GameObject.Find("EnemyList").GetComponent<EnemyList>();
        this.TextTMP = GameObject.Find("TextTMP");
        this.SE1 = GameObject.Find("attackDamegeSE");
        this.SE2 = GameObject.Find("criticalSE");
        this.Te0 = GameObject.Find("Te0");
        this.GameOverMethod = GameObject.Find("GameOver").GetComponent<GameOverMethod>();
        this.killedBranch = GameObject.Find("KilledBranch").GetComponent<KilledBranch>();
    }
    public void Attack()
    {
        var textAsset = Resources.Load($"斬りつける{CSelect.sNum}") as TextAsset;
        TextTMP.GetComponent<TextMeshProUGUI>().text = textAsset.ToString();

        //battle
        CSelect.battle = true;

        if (CSelect.cri <= tarot.luck)
        {
            CSelect.critical = true;

            CSelect.eDamage = tarot.attack * 2 - enemyList.enemys[CSelect.enemyNum].eDef;
        }
        else
        {
            CSelect.eDamage = tarot.attack - enemyList.enemys[CSelect.enemyNum].eDef;
        }
        CSelect.damage = enemyList.enemys[CSelect.enemyNum].eAtt - tarot.defense;

        if (CSelect.eDamage < 0)
        {
            CSelect.eDamage = 0;
        }
        if (CSelect.damage < 0)
        {
            CSelect.damage = 0;
        }

        SwBattlePre(CSelect.damage, CSelect.eDamage, enemyList.enemys[CSelect.enemyNum].eAgi, enemyList.enemys[CSelect.enemyNum].eHp);
    }

    public bool destroy = false;
    private async void SwBattlePre(int damage, int eDamage, int eAgi, int eHp)
    {
        if (tarot.agility >= eAgi)
        {
            if (CSelect.critical)
            {
                SE2.GetComponent<AudioSource>().Play();
                CSelect.critical = false;
                TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{eDamage}ダメージを与えた";

                //与ダメージ
                enemyList.enemys[CSelect.enemyNum].eHp -= eDamage;

                await Task.Delay(2000);
                //倒したとき
                if (enemyList.enemys[CSelect.enemyNum].eHp <= 0)
                {
                    destroy = true;
                    killedBranch.destroyingBranch(CSelect.enemyNum);
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
                enemyList.enemys[CSelect.enemyNum].eHp -= eDamage;

                await Task.Delay(2000);
                //倒したとき
                if (enemyList.enemys[CSelect.enemyNum].eHp <= 0)
                {
                    destroy = true;
                    killedBranch.destroyingBranch(CSelect.enemyNum);
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
            tarot.hitP -= CSelect.damage;
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
                if (CSelect.critical)
                {
                    SE2.GetComponent<AudioSource>().Play();
                    CSelect.critical = false;
                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{eDamage}ダメージを与えた";

                    //与ダメージ
                    enemyList.enemys[CSelect.enemyNum].eHp -= eDamage;

                    await Task.Delay(2000);
                    //倒したとき
                    if (enemyList.enemys[CSelect.enemyNum].eHp <= 0)
                    {
                        destroy = true;
                        killedBranch.destroyingBranch(CSelect.enemyNum);
                    }
                }
                else
                {
                    SE1.GetComponent<AudioSource>().Play();
                    TextTMP.GetComponent<TextMeshProUGUI>().text = $"\n{ eDamage}ダメージを与えた";

                    //与ダメージ
                    enemyList.enemys[CSelect.enemyNum].eHp -= eDamage;

                    await Task.Delay(2000);
                    //倒したとき
                    if (enemyList.enemys[CSelect.enemyNum].eHp <= 0)
                    {
                        killedBranch.destroyingBranch(CSelect.enemyNum);
                    }
                }
            }
        }
        else if (destroy) destroy = false;
    }
}
