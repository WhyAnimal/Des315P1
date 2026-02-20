using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.IO;

public class Telemetry : MonoBehaviour
{
    string filename = "";

    public Dealer dealer;

    public PreforanceTracker FPS_INFO;

    public UI_Manager UiManager;


    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/TelemetryData.csv";
        TextWriter textWriter = new StreamWriter(filename, false);
        textWriter.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TelemetryPrintPlayerData();
        }
    }

    public void TelemetryPrintPlayerData()
    {
        TextWriter textWriter = new StreamWriter(filename, true);
        //player #, ,Cards Played, , Tricks Won, , Esc press, , Options Menu Pressed, , Mean FPS, , Median FPS, , Worst, ,
        //textWriter.WriteLine("Player Number, ,Cards Played, ,Tricks Won, ,Main Menu Opened, ,Options Menu Pressed, ,Mean FPS, , Median FPS, , Worst, ,");

        //Hand 1
        textWriter.WriteLine("");
        textWriter.WriteLine("Player Number," + "One"+ 
                             ",Cards Played," + dealer.OneCardsPlayed.ToString() + 
                             ",Tricks Won,"   + dealer.OneWins);

        //Hand 2
        textWriter.WriteLine("");
        textWriter.WriteLine("Player Number," + "Two" +
                             ",Cards Played," + dealer.TwoCardsPlayed.ToString() +
                             ",Tricks Won," + dealer.TwoWins);

        //Player hand
        textWriter.WriteLine("");
        textWriter.WriteLine("Player Number," + "Player" +
                             ",Cards Played," + dealer.PlayerCardsPlayed.ToString() +
                             ",Tricks Won," + dealer.PlayerWins.ToString());

        //Hand 4
        textWriter.WriteLine("");
        textWriter.WriteLine("Player Number," + "Four" +
                             ",Cards Played," + dealer.FourCardsPlayed.ToString() +
                             ",Tricks Won," + dealer.FourWins.ToString());

        //other info
        textWriter.WriteLine("");
        textWriter.WriteLine(",Main Menu Opened," + UiManager.MainMenuOpened.ToString() +
                             ",Options Menu Pressed," + UiManager.MenusOpened.ToString() +
                             ",Mean FPS," + ((int)(FPS_INFO.meanFPS)).ToString() +
                             ",Median FPS," + ((int)(FPS_INFO.mediumFPS)).ToString() +
                             ",Worst, " + ((int)(FPS_INFO.worstFPS)).ToString());

        textWriter.Close();
    }

    //info wants

    //player cards played, player hand won
    //number times esc was pressed, and how many menu options pressed
    //performance data mean, median and worst
}
