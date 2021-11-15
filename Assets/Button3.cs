using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{

    GameObject storyCard;

    public List<Sprite> images;         //スプライト
    //public List<string> images;       //間違い

    // Start is called before the first frame update
    void Start()
    {
        this.storyCard = GameObject.Find("storyCard");
        storyCard.GetComponent<SpriteRenderer>().sprite = images[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoryCards()
    {
        images = new List<Sprite>{};
    }
}

/*

            (@"Story\index (1)"),
            ("index (2)"),
            ("index (38)"),
            ("index (4)"),
            ("index (5)"),
            ("index (6)"),
            ("index (7)"),
            ("index (8)"),
            ("index (9)"),
            ("index (10)"),
            ("index (11)"),
            ("index (12)"),
            ("index (13)"),
            ("index (14)"),
            ("index (15)"),
            ("index (16)"),
            ("index (17)"),
            ("index (18)"),
            ("index (19)"),
            ("index (20)"),
            ("index (21)"),
            ("index (22)")
*/