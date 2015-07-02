using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    
    ShoeImage[] ShoeImages;
    public Sprite[] Sprites;
    int numShoes;

    void Start()
    {
        numShoes = transform.childCount;
        ShoeImages = new ShoeImage[numShoes];
        for (int i = 0; i < numShoes; i++)
        {
            ShoeImages[i] = transform.GetChild(i).GetComponent<ShoeImage>();
            ShoeImages[i].num = i;
            //ShoeImages[i].ChangeImage(Sprites[i]);
        }
    }
    public void Reset()
    {
        for (int i = 0; i < numShoes; i++)
        {
            ShoeImages[i] = transform.GetChild(i).GetComponent<ShoeImage>();
            ShoeImages[i].num = i;
            ShoeImages[i].ChangeImage(Sprites[i]);
        }
    }
    public void ChangeShoesImages()
    {
        for (int i = 0; i < numShoes; i++)
        {
            
            if(++ShoeImages[i].num == Sprites.Length){
                ShoeImages[i].num = 0;
            }
            ShoeImages[i].ChangeImage(Sprites[ShoeImages[i].num]);
        }
    }

}
