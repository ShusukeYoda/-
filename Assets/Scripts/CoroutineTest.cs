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

    IEnumerator EndMessage() //(引数）も可能
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

/*
    参照
    IEumerator Start(){
        Debug.Log("始まり");
        yield return new WaitForSeconds(3);
        Debug.Log("終わり");
    }
*
*   参照
    void Start(){
        Debug.Log("始まり");
        Invoke("EndMsg",3);
    }
    void EndMsg()
    {
        Debug.Log("途中");
    }
*
*   参照
    void Start(){
        Debug.Log("始まり");
        //Invoke("EndMsg",3);
        InvokeRepeating("EndMsg",1,5);
    }
    void EndMsg()
    {
        Debug.Log("途中");　
    }
 */
    //Debug位置にinstantiateとか