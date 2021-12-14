using UnityEngine;
using UnityEngine.UI;

public class pullDown : MonoBehaviour
{
    All all;
    Dropdown ddtmp;

    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<All>();
        this.ddtmp = GameObject.Find("Dropdown").GetComponent<Dropdown>();
    }
    public void pullClick()
    {
        all.CommandSelected(ddtmp.value);
    }
}
