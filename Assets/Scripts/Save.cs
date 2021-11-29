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
            SaveMsg("森の中");
            Debug.Log("保存完了しました");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            string meg = LoadMsg();
            Debug.Log(meg);
        }
    }
}
/*
Debug中で、PlayerPrefsで作成したファイルの消去をしたい場合、
[Edit] -> [Clear All PlayerPrefs]で実行できます
 */