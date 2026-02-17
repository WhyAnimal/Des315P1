using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    public List<Button> MainMenu;

    public List<Button> PlaySpeed;

    public List<Button> HandSize;

    public List<Button> HandNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(Button button in MainMenu)
            {
                button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
            }
        }
    }

    /*********************************************************
    *                    Fade Out Menus                      * 
    **********************************************************/

    private void DisappearMenu(List<Button> Menu)
    {
        foreach (Button button in Menu)
        {
            button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
        }
    }

    public void DisappearMainMenu()
    {
        DisappearMenu(MainMenu);
    }

    public void DisappearPlaySpeedMenu()
    {
        DisappearMenu(PlaySpeed);
    }

    public void DisappearHandSizeMenu()
    {
        DisappearMenu(HandSize);
    }

    public void DisappearHandNumberMenu()
    {
        DisappearMenu(HandNumber);
    }

    /*********************************************************
    *                    Fade In Menus                       * 
    **********************************************************/

    private void AppearMenu(List<Button> Menu)
    {
        foreach (Button button in Menu)
        {
            button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
        }
    }

    public void AppearMainMenu()
    {
        AppearMenu(MainMenu);
    }

    public void AppearPlaySpeedMenu()
    {
        AppearMenu(PlaySpeed);
    }

    public void AppearHandSizeMenu()
    {
        AppearMenu(HandSize);
    }

    public void AppearHandNumberMenu()
    {
        AppearMenu(HandNumber);
    }

    /*********************************************************
    *                       Main Menu                        * 
    **********************************************************/



    public void ResumeGame()
    {
        //disapper Main Menu
        DisappearMainMenu();
    }

    public void PlaySpeedMenu()
    {
        //disapper Main Menu
        DisappearMainMenu();

        //appear sub Menu
        AppearPlaySpeedMenu();
    }

    public void HandSizeMenu()
    {
        //disapper Main Menu
        DisappearMainMenu();

        //appear sub Menu
        AppearHandSizeMenu();
    }

    public void HandNumberMenu()
    {
        //disapper Main Menu
        DisappearMainMenu();

        //appear sub Menu
        AppearHandNumberMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /*********************************************************
    *                    Play Speed Menu                     * 
    **********************************************************/

    public void SetPlaySpeed(float speed)
    {
        speed *= speed;
    }

    /*********************************************************
    *                    Hand Size Menu                      * 
    **********************************************************/


    /*********************************************************
    *                    Hand Number Menu                    * 
    **********************************************************/
}
