using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //�錾
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Sprite sprite2;

    void OnMouseDown()
    {
        //�\������Ă�摜�ɂ���ď�����ς���
        if (spriteRenderer.sprite == sprite2)
        {
            //�摜�؂�ւ��@
            spriteRenderer.sprite = sprite;
        }
        else
        {
            //�摜�؂�ւ��A
            spriteRenderer.sprite = sprite2;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
