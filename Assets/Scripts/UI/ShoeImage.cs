using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShoeImage : MonoBehaviour {

    public int num;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ChangeImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
