using UnityEngine;
using TMPro;

public class TextMethPro : MonoBehaviour
{
    public GameObject TextTMP;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        var textAsset = Resources.Load("Start") as TextAsset;
        textMeshPro = this.GetComponent<TextMeshProUGUI>();

        textMeshPro.text = textAsset.ToString();
    }
}