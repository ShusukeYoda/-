using System.Collections;
using TMPro;
using UnityEngine;

public class KilledBranch : MonoBehaviour
{
    CommandSelect all;
    GameObject SE3;
    public GameObject TextTMP;

    // Start is called before the first frame update
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<CommandSelect>();
        this.SE3 = GameObject.Find("destroySE");
        this.TextTMP = GameObject.Find("TextTMP");

    }
    public bool destroyingBranch(int enemyNum)
    {
        SE3.GetComponent<AudioSource>().Play();

        StartCoroutine(GoToCoroutine());
        IEnumerator GoToCoroutine()
        {
            yield return new WaitForSeconds(2);
        }

        if (enemyNum == 0)
        {
            var textAsset = Resources.Load("battle2") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }

        if (enemyNum == 1 || enemyNum == 3)
        {
            var textAsset = Resources.Load("battle7.11") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 2)
        {
            var textAsset = Resources.Load("battle9") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 4)
        {
            var textAsset = Resources.Load("battle13") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 5)
        {
            var textAsset = Resources.Load("battle15") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 6)
        {
            var textAsset = Resources.Load("battle17") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 7)
        {
            var textAsset = Resources.Load("battle18") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 8)
        {
            var textAsset = Resources.Load("battle19") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 9)
        {
            var textAsset = Resources.Load("battle20") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }
        if (enemyNum == 10)
        {
            var textAsset = Resources.Load("battle21") as TextAsset;
            TextTMP.GetComponent<TextMeshProUGUI>().text = "" + textAsset;
        }

        all.walk = true;
        all.battle = false;

        return all.battle == false;
    }
}
