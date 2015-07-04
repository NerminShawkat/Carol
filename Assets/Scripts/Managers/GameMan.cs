using UnityEngine;
using System.Collections;

public class GameMan : MonoBehaviour {

    public static InputMan inputManager;
    public static UIMan uiManager;
    public static LevelMan levelManager;
    public static bool Died;
    public static bool Done;
    void Awake()
    {
# if UNITY_STANDALONE
        inputManager = (InputMan)gameObject.AddComponent<PCInputMan>();
#elif UNITY_ANDROID
        inputManager = (InputMan)gameObject.AddComponent<AndrodInputMan>();
#endif
        inputManager.enabled = false;
        uiManager = GetComponent<UIMan>();
        levelManager = GetComponent<LevelMan>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
