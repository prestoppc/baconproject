using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalanderSystem : MonoBehaviour
{
    //Attach to main camera and Dont Destroy On Loads
    public Text CurrentDayDisplay;
    public int CurrentDay;
    public int FinishDay;
    public bool gamePause;

    //Menu options
    public GameObject FinishMenu;
    public bool contGame;
    public bool replay;
    public bool quit;
    public bool menuactivated;

	void Start ()
    {
        CurrentDay = 1;
        gamePause = false;
        contGame = false;
        replay = false;
        quit = false;
        menuactivated = false;
	}
	
	void Update ()
    {
        //Change Display of the day
        if (CurrentDayDisplay.text != "Day " + CurrentDay)
            CurrentDayDisplay.text = "Day " + CurrentDay;

        //When the regular game ends -------- Day 28 is the finish at the moment
        if (CurrentDay == FinishDay)
        {
            //Turns on the finish menu
            if (!menuactivated)
            {
                menuactivated = true;
                FinishMenu.SetActive(true);
            }
            gamePause = true;
            if (contGame)
            {
                ChangeDay();
                gamePause = false;
            }
        }
	}

    //Changes the Day by one
    public void ChangeDay()
    {
        CurrentDay++;
    }
    //When the player hits the continue
    public void Continue()
    {
        //Turns off the finish menu
        FinishMenu.SetActive(false);
        contGame = true;
    }
    //When the player hits the replay
    public void Replay()
    {
        CurrentDay = 1;
        //Turns off the finish menu
        FinishMenu.SetActive(false);
        //TODO: Reset everything back to Day 1
    }
    //When the player hits the quit
    public void Quit()
    {
        //Turns off the finish menu
        FinishMenu.SetActive(false);
        //TODO: Go to main menu
    }
}
