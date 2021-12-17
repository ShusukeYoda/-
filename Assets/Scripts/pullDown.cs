using UnityEngine;
using UnityEngine.UI;

public class pullDown : MonoBehaviour
{
    CommandSelect all;
    Dropdown ddtmp;

    void Start()
    {
        this.all = GameObject.Find("Main Camera").GetComponent<CommandSelect>();
        this.ddtmp = GameObject.Find("Dropdown").GetComponent<Dropdown>();
    }
    public void pullClick()
    {
        all.CommandSelected(ddtmp.value);
    }
}
