using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;
using Image = UnityEngine.UI.Image;

public class Button�v : MonoBehaviour
{

    // Image �R���|�[�l���g���i�[����ϐ�
    public Image m_Image;
    // �X�v���C�g�I�u�W�F�N�g���i�[����z��
    public Sprite[] m_Sprite;
    // �X�v���C�g�I�u�W�F�N�g��ύX���邽�߂̃t���O
    bool change;
    //Tarot�N���X�C���X�^���X
    Tarot tarot = new Tarot();

    // Start is called before the first frame update
    void Start()
    {
        // �X�v���C�g�I�u�W�F�N�g��ύX���邽�߂̃t���O�� false �ɐݒ�
        change = false;
        // Image �R���|�[�l���g���擾���ĕϐ� m_Image �Ɋi�[
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �X�v���C�g�I�u�W�F�N�g�̕ύX�t���O�� true �̏ꍇ
            if (change)
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                //�i�z�� m_Sprite[0] �Ɋi�[�����X�v���C�g�I�u�W�F�N�g��ϐ� m_Image �Ɋi�[����Image �R���|�[�l���g�Ɋ��蓖�āj
                m_Image.sprite = m_Sprite[0];
                change = false;
            }
            // �X�v���C�g�I�u�W�F�N�g�̕ύX�t���O�� false �̏ꍇ
            else
            {
                // �X�v���C�g�I�u�W�F�N�g�̕ύX
                //�i�z�� m_Sprite[1] �Ɋi�[�����X�v���C�g�I�u�W�F�N�g��ϐ� m_Image �Ɋi�[����Image �R���|�[�l���g�Ɋ��蓖�āj
                m_Image.sprite = m_Sprite[1];
                change = true;
            }
        }
    }
}
            /*
        public void Click()
        {
            Tarot tarot = new Tarot();

            int[] dice = new int[22];
            int index = Random.Range(0, dice.Length);


            Sprite image = Resources.Load<Sprite>("Images/66px-RWS_Tarot_08_Strength");
            //card.ImageLocation = tarot.tarotImage[index];
        }
        */