using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOfCards_Action : MonoBehaviour
{
    //public Transform Entity;
    public List<Transform> Deck;

    private void Start()
    {
        MakeDeck();
        //ActionSystem.Instance.Actions.Enqueue(
        //    new MoveAction(Entity, new Vector3(10, 0, 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        //);

        //for (int i = 0; i < Deck.Count; i++)
        //{
        //    ActionSystem.Instance.Actions.Enqueue(
        //    new RotateAction(Deck[i], Quaternion.Euler(0f, 180f, 0f), delaySeconds: 2.0f, durationSeconds: 0.75f)
        //    );
        //}


        //ActionSystem.Instance.Actions.Enqueue(
        //    new MoveAction(Entity, new Vector3(0f, -20f, 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        //);
    }

    private void MakeDeck()
    {
        Vector3 deckPosition = Vector3.zero;
        float xOffset = 0.005f;
        float yOffset = 0.005f;
        float zOffset = 0.01f;
        

        for (int i = 0; i < Deck.Count; i++)
        {
            Transform card = Deck[i];

            Vector3 stackedPosition = deckPosition + new Vector3(-i * xOffset, -i * yOffset, i * zOffset);

            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, stackedPosition, delaySeconds: 0f, durationSeconds: 0.0f)
            );
        }
    }

    private void MoveAllToDeck()
    {
        for (int i = 0; i < Deck.Count; ++i)
        {
            ActionSystem.Instance.Actions.Enqueue(
            new MoveAction(Deck[i], new Vector3(0f, 0f, 0f), delaySeconds: 0.1f, durationSeconds: 0.1f)
            );
        }

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

    private void ShuffleDeck()
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
            MoveAllToDeck();
            ShuffleDeck();
        }

        //play give cards to different hands
        if (Input.GetKeyDown(KeyCode.P))
        {
            RandomPlace();
        }
    }

}