using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay_Info : MonoBehaviour
{
    public TMP_Text HandOneText;
    public TMP_Text HandTwoText;
    public TMP_Text HandPlayerText;
    public TMP_Text HandFourText;

    public Dealer Dealer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandOneTextUpdate();
        HandTwoTextUpdate();
        HandPlayerTextUpdate();
        HandFourTextUpdate();
    }

    void HandOneTextUpdate()
    {
        HandOneText.text = "[Player One Name] | Total Wins: " + Dealer.OneWins + " | Score: " + (Dealer.OneWins * 100 );
    }

    void HandTwoTextUpdate()
    {
        HandTwoText.text = "[Player Two Name] | Total Wins: " + Dealer.TwoWins + " | Score: " + (Dealer.TwoWins * 100);
    }

    void HandPlayerTextUpdate()
    {
        HandPlayerText.text = "[Player Name] | Total Wins: " + Dealer.PlayerWins + " | Score: " + (Dealer.PlayerWins * 100);
    }

    void HandFourTextUpdate()
    {
        HandFourText.text = "[Player Four Name] | Total Wins: " + Dealer.FourWins + " | Score: " + (Dealer.FourWins * 100);
    }
}
