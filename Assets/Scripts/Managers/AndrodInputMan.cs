using UnityEngine;
using System.Collections;

public class AndrodInputMan : InputMan {
    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    bool isInput = false;
	
	void Update () {
        if (Input.touchCount == 1) {
		    Touch touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Began) {
					startPosition = touch.position;
                    isInput = false;
            }
            else if (touch.phase == TouchPhase.Ended) {
				
					endPosition = touch.position;
                    isInput = true;
            }
            else
            {
                isInput = false;
            }
        }
        else
        {
            isInput = false;
        }
        if (isInput)
        {
            Vector3 direction = (endPosition - startPosition);
            bool vertical = Mathf.Abs(direction.y) > Mathf.Abs(direction.x);
            if (Mathf.Abs(direction.x) < 10 && Mathf.Abs(direction.y) < 10)
            {
                ChangeShose = true;
            }
            else
            {
                ChangeShose = false;
                if (vertical && direction.y > 0)
                {
                    Jump = true;
                }
                else
                {
                    Jump = false;
                }

                if (vertical && direction.y < 0)
                {
                    Slide = true;
                }
                else
                {
                    Slide = false;
                }

                if (!vertical && direction.x > 0)
                {
                    Right = true;
                }
                else
                {
                    Right = false;
                }

                if (!vertical && direction.x < 0)
                {
                    Left = true;
                }
                else
                {
                    Left = false;
                }
            }

            

            //print("input");
            //bool xTheSame =  Mathf.Abs(endPosition.x - startPosition.x) <1;
            //bool yTheSame =  Mathf.Abs(endPosition.y - startPosition.y) <1;
            //bool DeltaXgreater =  Mathf.Abs(endPosition.x - startPosition.x) > 
            //    Mathf.Abs(endPosition.y - startPosition.y);
            //bool up = endPosition.y > startPosition.y;
            //bool right = endPosition.x > startPosition.x;
            //if (xTheSame && yTheSame)
            //{
            //    ChangeShose = true;
            //}
            //else{
            //    ChangeShose = false;
            //    if (up && !DeltaXgreater)
            //    {
            //        Jump = true;
            //    }
            //    else
            //    {
            //        Jump = false;
            //    }
            //    if (!up && !DeltaXgreater)
            //    {
            //        Slide = true;
            //    }
            //    else
            //    {
            //        Slide = false;
            //    }
            //    if (right && DeltaXgreater)
            //    {
            //        Right = true;
            //    }
            //    else
            //    {
            //        Right = false;
            //    }
            //    if (!right && DeltaXgreater)
            //    {
            //        Right = true;
            //    }
            //    else
            //    {
            //        Right = false;
            //    }
            //}
            
        }
        else
        {
            Jump = false;
            Slide = false;
            ChangeShose = false;
            Left = false;
            Right = false;
        }
        //print(isInput);
	
	}
}
