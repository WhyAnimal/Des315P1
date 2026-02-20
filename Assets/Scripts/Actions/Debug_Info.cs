using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debug_Info : MonoBehaviour
{
    public PreforanceTracker FPS_INFO;

    public bool DEBUGSHOW = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            DEBUGSHOW = !DEBUGSHOW;

            //change aplha to visable
            CanvasGroup cg = this.GetComponent<CanvasGroup>();
            
            if(DEBUGSHOW)
            {
                cg.alpha = 1.0f;//fade in when done

            }
            else
            {
                cg.alpha = 0.0f;//fade out when done
            }                
        }

        if(DEBUGSHOW)
        {
            //visable
            TMP_Text text = this.GetComponentInChildren<TMP_Text>();

            if (text != null)
            {
                //fps
                string meanFPSString = "Mean FPS: " + ((int)(FPS_INFO.meanFPS)).ToString() + "\n";
                string mediumFPSString = "Medium FPS: " + ((int)(FPS_INFO.mediumFPS)).ToString() + "\n";
                string worstFPSString = "Worst FPS: " + ((int)(FPS_INFO.worstFPS)).ToString() + "\n";

                //Action List thing idk



                text.text = meanFPSString + mediumFPSString + worstFPSString;
            }
        }
        else
        {
            //not visable

        }
        
        
    }

    //need to change text to 

    /*
    FPS: 0
    Mean: 0
    Median: 0
    Worst: 0

    Action List Info
    asdfadfadsf %
    */
}
