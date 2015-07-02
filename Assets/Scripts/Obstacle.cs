using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    void OnTriggerEnter(Collider Other)
    {
        
        if (Other.gameObject.tag == "Player")
        {
            GameMan.Died = true;
            print("Died");
        }
    }
}
