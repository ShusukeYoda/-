using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadText : MonoBehaviour
{
    public string[] textMessage; //�e�L�X�g�̉��H�O�̈�s������ϐ�
    public string[,] textWords; //�e�L�X�g�̕����������2�����͔z�� 

    private int rowLength; //�e�L�X�g���̍s�����擾����ϐ�
    private int columnLength; //�e�L�X�g���̗񐔂��擾����ϐ�

    // Start is called before the first frame update
    void Start()
    {
        TextAsset textasset = new TextAsset(); //�e�L�X�g�t�@�C���̃f�[�^���擾����C���X�^���X���쐬
        textasset = Resources.Load(@"Story\start", typeof(TextAsset)) as TextAsset; //Story�t�H���_����Ώۃe�L�X�g���擾
        string TextLines = textasset.text; //�e�L�X�g�S�̂�string�^�œ����ϐ���p�ӂ��ē����

        //Split�ň�s�Â�������1���z����쐬
        textMessage = TextLines.Split('\n'); //

        //�s���Ɨ񐔂��擾
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2���z����`
        textWords = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split('\t'); //textMessage���J���}���Ƃɕ��������̂��ꎞ�I��tempWords�ɑ��

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n]; //2���z��textWords�ɃJ���}���Ƃɕ�����tempWords�������Ă���
                Debug.Log(textWords[i, n]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
