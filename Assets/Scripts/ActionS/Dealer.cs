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
    public Gameplay_Info GameplayUi;

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
    public int HANDNUMBER = 4;

    public int OneWins = 0;
    public int TwoWins = 0;
    public int PlayerWins = 0;
    public int FourWins = 0;

    public int OneCardsPlayed = 0;
    public int TwoCardsPlayed = 0;
    public int PlayerCardsPlayed = 0;
    public int FourCardsPlayed = 0;

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
                            ++OneCardsPlayed;
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
                            ++TwoCardsPlayed;
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
                            ++PlayerCardsPlayed;
                        }
                        else
                        {
                            if (playerHand.PlayerClickACard())
                            {
                                ++HandsTurn;
                                ++PlayerCardsPlayed;
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
                            ++FourCardsPlayed;
                        }
                        else
                        {
                            HandFourEmpty = true;
                        }
                            ++HandsTurn;
                        break;

                    case 4: // put trick into the discard pile
                        //get who won the game

                        int whoWon = 0;
                        switch (HANDNUMBER)
                        {
                            case 2: // hand 1 and player
                                whoWon = Random.Range(1, 3);
                                if (whoWon == 2)
                                {
                                    whoWon = 3;
                                }
                                break;
                            case 3: // hand 1 2 and player
                                whoWon = Random.Range(1, 4);
                                break;
                            case 4: // all four hands
                                whoWon = Random.Range(1, 5);
                                break;
                            default:
                                whoWon = Random.Range(1, 5);
                                break;
                        };

                        switch (whoWon)
                        {
                            case 1: // hand 1 won
                                ++OneWins;
                                break;
                            case 2: // hand 2 won
                                ++TwoWins;
                                break;
                            case 3: // hand player won
                                ++PlayerWins;
                                break;
                            case 4: // hand 4 won
                                ++FourWins;
                                break;
                        };

                        //fade in gameplay ui
                        CanvasGroup cg = GameplayUi.GetComponent<CanvasGroup>();
                        ActionSystem.Instance.Actions.Enqueue(
                        new FadeInAction(cg, 1.0f, delaySeconds: 0f, durationSeconds: 1)
                        );

                        if (TrickPile.Trick.Count > 0)
                        {
                            TrickPile.GiveAllCardsToDiscard();
                            ++HandsTurn;
                        }

                        ActionSystem.Instance.Actions.Enqueue(
                        new FadeInAction(cg, 0.0f, delaySeconds: 1f, durationSeconds: 1)
                        );
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
