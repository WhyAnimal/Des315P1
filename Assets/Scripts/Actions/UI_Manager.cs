using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public Dealer dealerObject;

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
            AppearMainMenu();
        }
    }

    /*********************************************************
    *                    Fade Out Menus                      * 
    **********************************************************/

    private void DisappearMenu(List<Button> Menu)
    {
        foreach (Button button in Menu)
        {
            CanvasGroup cg = button.GetComponent<CanvasGroup>();

            if (cg != null)
            {
                cg.alpha = 0;
                cg.interactable = false;
                cg.blocksRaycasts = false;

            }
            //button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
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
            CanvasGroup cg = button.GetComponent<CanvasGroup>();

            if (cg != null)
            {
                cg.alpha = 1;
                cg.interactable = true;
                cg.blocksRaycasts = true;

            }
            //button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
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
        dealerObject.PLAYSPEED = speed;
        DisappearPlaySpeedMenu();
    }

    /*********************************************************
    *                    Hand Size Menu                      * 
    **********************************************************/

    public void SetHandSize(int HandSize)
    {
        dealerObject.HANDSIZE = HandSize;
        DisappearHandSizeMenu();
    }

    /*********************************************************
    *                    Hand Number Menu                    * 
    **********************************************************/

    public void SetHandNumber(int HandNumber)
    {
        dealerObject.HANDNUMBER = HandNumber;
        DisappearHandNumberMenu();
    }
}
