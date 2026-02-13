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

    public Trick_Action TrickPile;
    //Discard pile
    public Discard_Action Discard;

    public bool GameStarted = false;

    public int HandsTurn = -1;

    public bool AutoPlay = false;

    public bool HandOneEmpty = false;
    public bool HandTwoEmpty = false;
    public bool HandPlayerEmpty = false;
    public bool HandFourEmpty = false;

    //menu things

    public float PLAYSPEED = 1.0f;
    public int HANDSIZE = 7;
    public int HANDAMOUNT = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = PLAYSPEED;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ActionSystem.Instance.Actions.Clear();
            //turn on the main menu

        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            AutoPlay = !AutoPlay;
        }

        if(GameStarted)
        {
            if(HandsTurn == -1)
            {
                DeckPile.StartTheGame();
                HandsTurn = 0;
            }
            else
            {
                switch (HandsTurn % 5)
                {
                    case 0:
                        if (HandOne.Hand.Count > 0)
                        {
                            HandOne.PlayARound();
                        }
                        else
                        {
                            HandOneEmpty = true;
                        }
                        ++HandsTurn;
                        break;
                    case 1:
                        if (HandTwo.Hand.Count > 0)
                        {
                            HandTwo.PlayARound();
                        }
                        else
                        {
                            HandTwoEmpty = true;
                        }
                        ++HandsTurn;
                        break;
                    case 2: // player hand
                        if(AutoPlay)
                        {
                            playerHand.PlayARound();
                            ++HandsTurn;
                        }
                        else
                        {
                            if (playerHand.PlayerClickACard())
                            {
                                ++HandsTurn;
                            }
                            else
                            {
                                //draw discard card on click
                            }
                        }

                        if (playerHand.Hand.Count > 0)
                        {

                        }
                        else
                        {
                            HandPlayerEmpty = true;
                        }

                        break;
                    case 3:
                        if (HandFour.Hand.Count > 0)
                        {
                            HandFour.PlayARound();
                        }
                        else
                        {
                            HandFourEmpty = true;
                        }
                            ++HandsTurn;
                        break;
                    case 4: // put trick into the discard pile
                        if(TrickPile.Trick.Count > 0)
                        {
                            TrickPile.GiveAllCardsToDiscard();
                            ++HandsTurn;
                        }
                        break;
                };

                if(HandOneEmpty && HandTwoEmpty && HandPlayerEmpty && HandFourEmpty)
                {
                    GameStarted = false;
                    AutoPlay = false;
                }
            }
        }
        else
        {
            //play give cards to different hands
            if (Input.GetKeyDown(KeyCode.Space) || AutoPlay == true)
            {
                GameStarted = true;
                HandOneEmpty = false;
                HandTwoEmpty = false;
                HandPlayerEmpty = false;
                HandFourEmpty = false;
            }
        }

    }
}
