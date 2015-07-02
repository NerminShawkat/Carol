using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public int levelNum;
    public GameObject gameObj;
    private bool Done;
    private bool Unlocked;
    public int[] ToUnlockWhenDone;
    public float NormalSpeed = 1;
    public float Speed = 0.1f;
    Animator anim;

    public bool GetDone()
    {
        Done = PlayerPrefs.GetInt("level " + levelNum + " Done") > 1;
        return Done;
    }
    public bool GetUnlocked()
    {
        Unlocked = PlayerPrefs.GetInt("level " + levelNum + " Unlocked") > 1;
        return Unlocked;
    }
    void Awake()
    {
        Done = PlayerPrefs.GetInt("level " + levelNum + " Done") > 1;
        Unlocked = PlayerPrefs.GetInt("level " + levelNum + " Unlocked") > 1;
        anim = GetComponent<Animator>();

        gameObj = gameObject;
        
    }

    public void Slow()
    {
        anim.speed = Speed;
    }
    public void Normal()
    {
        anim.speed = NormalSpeed;

    }
    public void Stop()
    {
        anim.speed = 0f;        
    }

    public void LoadLevel()
    {

    }

    public void SetDone()
    {
        Done = true;
        print("Done :D");
        PlayerPrefs.SetInt("level " + levelNum + " Done",2);
    }
    public void SetUnlocked()
    {
        Unlocked = true;
        PlayerPrefs.SetInt("level " + levelNum + " Unlocked", 2);
    }
}
