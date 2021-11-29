using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndMessage());
    }

    IEnumerator EndMessage()
    {
        Debug.Log("始まり");
        yield return new WaitForSeconds(3);
        Debug.Log("終わり");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
