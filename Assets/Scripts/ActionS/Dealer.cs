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
                        if (HandOne.Hand.Count > 0)
                        {
                            HandOne.PlayARound();
                        }
                        ++HandsTurn;
                        break;
                    case 1:
                        if (HandTwo.Hand.Count > 0)
                        {
                            HandTwo.PlayARound();
                        }
                        ++HandsTurn;
                        break;
                    case 2:
                        if (playerHand.PlayerClickACard())
                        {
                            ++HandsTurn;
                        }

                        if(playerHand.Hand.Count == 0)
                        {
                            ++HandsTurn;
                        }

                        break;
                    case 3:
                        if (HandFour.Hand.Count > 0)
                        {
                            HandFour.PlayARound();
                        }
                        ++HandsTurn;
                        break;
                };
            }



        }

    }
}
