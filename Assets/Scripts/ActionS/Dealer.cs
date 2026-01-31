using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    //Deck
    public DeckOfCards_Action DeckPile;
    //all hands
    public Hands_Action HandOne;
    public Hands_Action HandTwo;
    public Hands_Action playerHand;
    public Hands_Action HandFour;
    //Discard pile
    public Discard_Action Discard;

    public bool GameStarted = false;

    public int HandsTurn = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStarted)
        {
            if(HandsTurn == -1)
            {
                DeckPile.StartTheGame();
                HandsTurn = 0;
            }
            else
            {
                switch (HandsTurn % 4)
                {
                    case 0:
                        HandOne.GiveCardsToDiscard();
                        ++HandsTurn;
                        break;
                    case 1:
                        HandTwo.GiveCardsToDiscard();
                        ++HandsTurn;
                        break;
                    case 2:
                        //playerHand.GiveCardsToDiscard();
                        //++HandsTurn;
                        break;
                    case 3:
                        HandFour.GiveCardsToDiscard();
                        ++HandsTurn;
                        break;
                };
            }



        }

    }
}
