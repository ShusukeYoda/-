using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //éŒ¾
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Sprite sprite2;

    void OnMouseDown()
    {
        //•\¦‚³‚ê‚Ä‚é‰æ‘œ‚É‚æ‚Á‚Äˆ—‚ğ•Ï‚¦‚é
        if (spriteRenderer.sprite == sprite2)
        {
            //‰æ‘œØ‚è‘Ö‚¦‡@
            spriteRenderer.sprite = sprite;
        }
        else
        {
            //‰æ‘œØ‚è‘Ö‚¦‡A
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
