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

    IEnumerator EndMessage() //(�����j���\
    {
        Debug.Log("�n�܂�");
        yield return new WaitForSeconds(3);
        Debug.Log("�I���");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
    �Q��
    IEumerator Start(){
        Debug.Log("�n�܂�");
        yield return new WaitForSeconds(3);
        Debug.Log("�I���");
    }
*
*   �Q��
    void Start(){
        Debug.Log("�n�܂�");
        Invoke("EndMsg",3);
    }
    void EndMsg()
    {
        Debug.Log("�r��");
    }
*
*   �Q��
    void Start(){
        Debug.Log("�n�܂�");
        //Invoke("EndMsg",3);
        InvokeRepeating("EndMsg",1,5);
    }
    void EndMsg()
    {
        Debug.Log("�r��");�@
    }
 */
    //Debug�ʒu��instantiate�Ƃ�