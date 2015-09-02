using UnityEngine;
using System.Collections;

/*
*
* This script manages Main menu and the buttons on main menu, configurations screen should have .
* Main menu should be scene (level) 0.
* Configurations Should be scene 1.
* First playable scene should be scene 2
* ...
*/
public class MainMenu : MonoBehaviour {

    /*public void LoadConfig()
    {
        Application.LoadLevel(1);
    }*/

    public void loadLevelTwo()
    {
        Application.LoadLevel(1);
    }

    public void LoadLevelThree()
    {
        Application.LoadLevel(2);
    }


    public void exitGame()
    {
        Application.Quit();
    }



}
