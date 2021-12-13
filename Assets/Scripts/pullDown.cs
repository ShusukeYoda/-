using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

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
