using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private string LoadMsg()
    {
        return PlayerPrefs.GetString("storyMode");
    }
    private void SaveMsg(string msg)
    {
        PlayerPrefs.SetString("storyModce", msg);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveMsg("�X�̒�");
            Debug.Log("�ۑ��������܂���");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            string meg = LoadMsg();
            Debug.Log(meg);
        }
    }
}
/*
Debug���ŁAPlayerPrefs�ō쐬�����t�@�C���̏������������ꍇ�A
[Edit] -> [Clear All PlayerPrefs]�Ŏ��s�ł��܂�
 */