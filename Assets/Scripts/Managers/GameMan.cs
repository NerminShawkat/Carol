using UnityEngine;
using System.Collections;

public class GameMan : MonoBehaviour {

    public static InputMan inputManager;
    public static UIMan uiManager;
    public static LevelMan levelManager;
    public static bool Died;
    void Awake()
    {
# if UNITY_EDITOR || UNITY_STANDALONE
        inputManager = (InputMan)gameObject.AddComponent<PCInputMan>();
#endif
        uiManager = GetComponent<UIMan>();
        levelManager = GetComponent<LevelMan>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
