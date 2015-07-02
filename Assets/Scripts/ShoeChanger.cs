using UnityEngine;
using System.Collections;

public class ShoeChanger : MonoBehaviour {
    GameObject[] Shoes;
    int numShoes;
    int num = -1; 
	// Use this for initialization
	void Start () {
        numShoes = transform.childCount;
        Shoes = new GameObject[numShoes];
        for (int i = 0; i < numShoes; i++)
        {
            Shoes[i] = transform.GetChild(i).gameObject;
        }
	}
    public void Reset()
    {
        if (num != -1)
        {
            Shoes[num].SetActive(false);
            num = -1;
        }
        
    }
    public void ChangeShoe()
    {
        num++;
        if (num == numShoes)
            num = -1;

        if (num == -1)
        {
            Shoes[numShoes - 1].SetActive(false);
        }
        else if(num == 0)
        {
            Shoes[0].SetActive(true);
        }
        else
        {
            Shoes[num - 1].SetActive(false);
            Shoes[num].SetActive(true);
        }
    }
    public bool IsTheRightShoe(int ground){
        return ground == -1 || ground == num;
    }
}
