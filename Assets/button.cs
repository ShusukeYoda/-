using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //宣言
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Sprite sprite2;

    void OnMouseDown()
    {
        //表示されてる画像によって処理を変える
        if (spriteRenderer.sprite == sprite2)
        {
            //画像切り替え�@
            spriteRenderer.sprite = sprite;
        }
        else
        {
            //画像切り替え�A
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
