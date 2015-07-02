using UnityEngine;
using System.Collections;

public class UIMan : MonoBehaviour {

    public HUD hudComponent;
    public GameObject HUD;
    public GameObject Map;
    public GameObject MainMenu;
    public Controls controls;

	
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (GameMan.inputManager.ChangeShose)
        {
            hudComponent.ChangeShoesImages();
        }
        if (GameMan.Died)
        {
            ShowMap();
        }
	}
    public void ShowMap()
    {
        Destroy(LevelMan.activeLevelgameObject);
        HUD.SetActive(false);
        controls.enabled = false;
        Map.SetActive(true);
        GameMan.Died = false;
    }
    public void Play()
    {
        //controls.enabled = true;
        MainMenu.SetActive(false);
        Map.SetActive(true);
    }
    public void LoadLevel(int LevelNum)
    {
        hudComponent.Reset();
        
        Map.SetActive(false);
        HUD.SetActive(true);

        GameMan.levelManager.LoadLevel(LevelNum);
        controls.enabled = true;
        controls.Reset();
    }
    
}
