﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButton : MonoBehaviour {
    public int LevelNum;
    Button btn;
    Image btnImage;
	void Start () {
        btnImage = GetComponent<Image>();
        btn = GetComponent<Button>();
        
	}
    void Update()
    {
        btn.interactable = GameMan.levelManager.IsUnlocked(LevelNum);
        if (GameMan.levelManager.IsDone(LevelNum))
        {
            btnImage.color = Color.green;
        }
        else
        {
            btnImage.color = Color.red;
        }
    }
	
	
}
