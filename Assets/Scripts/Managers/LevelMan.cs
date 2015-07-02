using UnityEngine;
using System.Collections;

public class LevelMan : MonoBehaviour {

    Level[] levels;
    public GameObject[] levelsObj;
    public static Level activeLevel;
    public static GameObject activeLevelgameObject;

    public void Awake(){
        levels = new Level[levelsObj.Length];
        for (int i = 0; i < levelsObj.Length; i++)
        {
            levels[i] = levelsObj[i].GetComponent<Level>();
        }
        levels[0].SetUnlocked();
    }
    public bool IsDone(int levelNum){
        return levels[levelNum].GetDone();
    }

    public bool IsUnlocked(int levelNum)
    {
        return levels[levelNum].GetUnlocked();
    }

    public void LoadLevel(int levelNum)
    {
        activeLevelgameObject = Instantiate(levelsObj[levelNum]);
        activeLevel = activeLevelgameObject.GetComponent<Level>();
    }

    public void SetDone(int levelNum)
    {
        levels[levelNum].SetDone();
        for (int i = 0; i < levels[levelNum].ToUnlockWhenDone.Length; i++)
        {
            levels[levels[levelNum].ToUnlockWhenDone[i]].SetUnlocked();
        }
    }
    public void SetDoneCurrent()
    {
        activeLevel.SetDone();
        for (int i = 0; i < activeLevel.ToUnlockWhenDone.Length; i++)
        {
            levels[activeLevel.ToUnlockWhenDone[i]].SetUnlocked();
        }
    }
}
