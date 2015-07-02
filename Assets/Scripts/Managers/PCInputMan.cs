using UnityEngine;
using System.Collections;

public class PCInputMan : InputMan {

	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            Left = true;
        else
            Left = false;
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            Right = true;
        else 
            Right = false;
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            Jump = true;
        else 
            Jump = false;
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            Slide = true;
        else 
            Slide = false;
        if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.E))
            ChangeShose = true;
        else 
            ChangeShose = false;
	}
}
