using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pullDown : MonoBehaviour
{
    GameObject Dropdown;
    CommandManager all;

    // Start is called before the first frame update
    void Start()
    {
        this.Dropdown = GameObject.Find("Dropdown");
        this.all = GameObject.Find("Main Camera").GetComponent<CommandManager>();
    }
    public void OnClick()
    {
        Dropdown ddtmp;

        ddtmp = GameObject.Find("Dropdown").GetComponent<Dropdown>();

        all.CommandSelected(ddtmp.value);

        Debug.Log(ddtmp.value);
    }
}
