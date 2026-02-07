using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOfCards_Action : MonoBehaviour
{
    //public Transform Entity;
    public List<Transform> Deck;

    public Hands_Action HandOne;
    public Hands_Action HandTwo;
    public Hands_Action playerHand;
    public Hands_Action HandFour;

    public Dealer Dealer;

    // D send all cards to the deck
    // R Randomize pos of all cards in the deck only
    // S shuffle cards in the deck
    // Space give 7 cards the all hands
    // P give one card to the player hand
    // F give all cards in the hand to the discard pile
    // G give one card from the hand to the discard pile

    private void Start()
    {
        MakeDeck();
        //ShuffleDeck();
    }

    private void MakeDeck()
    {
        Vector3 deckPosition = Vector3.zero;
        float xOffset = 0.005f;
        float yOffset = 0.005f;
        float zOffset = 0.01f;
        

        for (int i = 0; i < Deck.Count; i++)
        {
            ////move to 0
            //ActionSystem.Instance.Actions.Enqueue(
            //new MoveAction(Deck[i], new Vector3(0f, 0f, 0f), delaySeconds: 0.0f, durationSeconds: 0.0f)
            //);

            Transform card = Deck[i];

            Vector3 stackedPosition = deckPosition + new Vector3(-i * xOffset, -i * yOffset, i * zOffset);
            //offset the post
            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, stackedPosition, delaySeconds: 0f, durationSeconds: 0.0f)
            );
        }
    }

    private void MoveAllToDeck()
    {
        MakeDeck();
    }

    private void RandomPlace()
    {
        for (int i = 0; i < Deck.Count; ++i)
        {
            //random
            ActionSystem.Instance.Actions.Enqueue(
            new MoveAction(Deck[i], new Vector3(Random.Range(-9, 9), 
                                                Random.Range(-4, 4), 
                                                0f), 
                                    delaySeconds: 0.1f, 
                                    durationSeconds: 0.1f)
            );

            //flip the card
            ActionSystem.Instance.Actions.Enqueue(
            new RotateAction(Deck[i], Quaternion.Euler(0f, 180f, 0f), delaySeconds: 0.0f, durationSeconds: 0.1f)
            );
        }
    }

    private void ShuffleCards()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            int randomIndex = Random.Range(i, Deck.Count);
            (Deck[i], Deck[randomIndex]) = (Deck[randomIndex], Deck[i]);
        }
    }

    public void ShuffleDeck()
    {
        ShuffleCards();

        Vector3 deckPosition = Vector3.zero;
        float scatterRadius = 1.5f;
        float delay = 0f;

        for (int i = 0; i < Deck.Count; i++)
        {
            Transform card = Deck[i];
            
            Vector3 scatterPos = deckPosition + new Vector3(
                                                    Random.Range(-scatterRadius, scatterRadius),
                                                    0f,
                                                    0f
            );

            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, scatterPos, delaySeconds: delay, durationSeconds: 0.1f)
            );

            // Return card to deck stack
            Vector3 stackedPos = deckPosition + new Vector3(0f, 0f, -i * 0.01f);

            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, stackedPos, delaySeconds: delay, durationSeconds: 0.1f)
            );
        }

        MakeDeck();
    }

    public void GiveCardToHand(Hands_Action theHand)
    {
        if (Deck.Count == 0) return; // no cards left

        // Take the top card from the deck
        Transform card = Deck[Deck.Count - 1];
        Deck.RemoveAt(Deck.Count - 1);

        // Add it to the hand list
        theHand.Hand.Add(card);

        // Move the card visually to the hand
        Vector3 handPosition = theHand.transform.position;

        // Optional: offset cards in hand horizontally
        float xOffset = 0f;//-0.7f;
        float zOffset = 0f;//0.01f;
        float handWidth = (theHand.Hand.Count - 1) * xOffset;

        Vector3 targetPos = handPosition + new Vector3(theHand.Hand.Count * xOffset - handWidth / 2f, 
                                                       0f,
                                                       theHand.Hand.Count * zOffset);

        // Animate move
        ActionSystem.Instance.Actions.Enqueue(
            new MoveAction(card, targetPos, delaySeconds: 0f, durationSeconds: 0.2f, false, 1)
        );

        //flip the correct way
        ActionSystem.Instance.Actions.Enqueue(
            new RotateAction(card, theHand.transform.rotation, delaySeconds: 0.0f, durationSeconds: 0.1f)
            );

        //fix card hand
        theHand.fixHandPlaceMentFlag = true;
    }

    public void StartTheGame()
    {
        for(int i = 0; i < 7; ++i)
        {
            GiveCardToHand(HandOne);
            GiveCardToHand(HandTwo);
            GiveCardToHand(playerHand);
            GiveCardToHand(HandFour);
        }
        //tell each hand to fix the hand placement
        HandOne.fixHandPlaceMentFlag = true;
        HandTwo.fixHandPlaceMentFlag = true;
        playerHand.fixHandPlaceMentFlag = true;
        HandFour.fixHandPlaceMentFlag = true;

    }

    public bool PlayerClickedDiscardPile()
    {
        return false;
    }

    private void Update()
    {
        //make deck again
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveAllToDeck();
        }

        //randomize pos
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomPlace();
        }

        //make deck again shuffle the deck
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShuffleDeck();
        }

        //play give cards to different hands
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dealer.GameStarted = true;
        }

        //test give card to the hands
        if (Input.GetKeyDown(KeyCode.P))
        {
            GiveCardToHand(playerHand);
            playerHand.fixHandPlaceMentFlag = true;
        }
    }

}