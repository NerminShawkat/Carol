using UnityEngine;
using System.Collections;
//-jump , slide, turnleft -, turn right  with animation
//- change shoes and check if they were the right shoes for the ground 
//- check if the player passed a level
public class Controls : MonoBehaviour {
    
    public float secondsToDie = 3;// if the player didn't change the shoes befor 3 sec he slows down and die
    int Ground = -1; // the default ground -- to bereplaced by enum
    private Animator anim;
    public ShoeChanger LeftShoeChanger;// changes the left  shoe
    public ShoeChanger RightShoeChanger;// changes the right  shoe
    bool Done = false;

    void Start()
    {

    }

    public void Reset()
    {
        StopAllCoroutines();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        RightShoeChanger.Reset();
        LeftShoeChanger.Reset();
        Done = false;
        anim.SetTrigger("Reset");
        Camera.main.GetComponent<Animator>().SetTrigger("Reset");
    }
	void Update () {
        if (!Done) { //if the player still didn't finish the level
            if (GameMan.Died )//stop the level if died
                LevelMan.activeLevel.Stop();

            else if (!LeftShoeChanger.IsTheRightShoe(Ground))// if the player wearing the wrong shoe slow down
                LevelMan.activeLevel.Slow();

            else
                LevelMan.activeLevel.Normal();
        
            if (GameMan.inputManager.Left)
            {
            
                GoLeft();
            }
            else if (GameMan.inputManager.Right)
            {
            
                GoRight();
            }
            else if (GameMan.inputManager.Jump)
            {
                Jump();
            }
            else if (GameMan.inputManager.Slide)
            {
                Slide();
            }
            else if (GameMan.inputManager.ChangeShose)
            {
                ChangeShose();
            }
	    }
	}

    void GoLeft()
    {
        if (transform.position.x > -1)
        {
            transform.position -= (Vector3.right);
        }
    }
    void GoRight()
    {

        if (transform.position.x < 1)
        {
            transform.position += (Vector3.right);
        }
    }
    void Jump()
    {
        anim.SetTrigger("Jump");
    }
    void Slide()
    {
        anim.SetTrigger("Slide");
    }
    void ChangeShose()
    {
        LeftShoeChanger.ChangeShoe();
        RightShoeChanger.ChangeShoe();
        if (LeftShoeChanger.IsTheRightShoe(Ground))
        {
            StopAllCoroutines();
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        // get type of the ground that the player is running on
        int ground = Ground;
        if(Other.gameObject.tag == "Normal")
        {
            ground = -1;
            //print("Normal");
        }

        else if (Other.gameObject.tag == "Ice")
        {
            ground = 0;
            //print("Ice");

        }
        else if (Other.gameObject.tag == "Forest")
        {
            ground = 1;
            //print("Forest");

        }
        else if (Other.gameObject.tag == "Desert")
        {
            ground = 2;
            //print("Desert");

        }
        else if (Other.tag == "Done")
        {
            Done = true;
            StartCoroutine(Win());
            print("Done");
        }
        if (ground != Ground && !Done)
        {
            Ground = ground;
            if (!LeftShoeChanger.IsTheRightShoe(Ground))//if they are,nt the same die
                StopAllCoroutines();
                StartCoroutine(Die());
        }
        
    }
    IEnumerator Win()
    {
        GameMan.levelManager.SetDoneCurrent();
        LevelMan.activeLevel.Stop();
        anim.SetTrigger("Done");
        Camera.main.GetComponent<Animator>().SetTrigger("Done");
        yield return new WaitForSeconds(5);
        GameMan.uiManager.ShowMap();
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(secondsToDie);
        GameMan.Died = true;
        
    }
}
