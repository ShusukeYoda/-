using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    CommandSelect all;
    GameObject SE11;

    [SerializeField]
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<CommandSelect>();
        this.SE11 = GameObject.Find("cardStopSE");

        button = GetComponent<Button>();

        button.onClick.AddListener(() => 
        {
            SE11.GetComponent<AudioSource>().Play();

            if (all.moving == true && all.one == false)
            {
                all.moving = false;
                all.one = true;
                all.walk = true;
            }
        });
    }
}
