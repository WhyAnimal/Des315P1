using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands_Action : MonoBehaviour
{
    public List<Transform> Hand;          // Cards currently in hand
    public DeckOfCards_Action DeckScript; // Reference to the deck
    public Discard_Action Discard;        // Reference to the Discard

    public bool isPlayerHandFlag = false;

    public bool fixHandPlaceMentFlag = false;

    // Move all cards in hand back to the deck
    public void GiveCardsBackToDeck()
    {
        if (Hand.Count == 0 || DeckScript == null) return;

        Vector3 deckPosition = DeckScript.transform.position; // Base position of the deck
        float zOffset = 0.01f; // Small offset to stack cards properly
        int deckCount = DeckScript.Deck.Count; // Start stacking on top of existing cards

        for (int i = Hand.Count - 1; i >= 0; i--)
        {
            Transform card = Hand[i];
            Hand.RemoveAt(i);                 // Remove from hand
            DeckScript.Deck.Add(card);        // Add to deck list

            // Calculate stacked position in deck
            Vector3 targetPos = deckPosition + new Vector3(0f, 0f, -deckCount * zOffset);
            deckCount++;

            // Animate moving back to deck
            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, targetPos, delaySeconds: 0f, durationSeconds: 0.2f)
            );

            // Reset rotation
            ActionSystem.Instance.Actions.Enqueue(
                new RotateAction(card, Quaternion.identity, delaySeconds: 0f, durationSeconds: 0.2f)
            );
        }
    }

    public void GiveAllCardsToDiscard()
    {
        if (Hand.Count == 0 || Discard == null) return;

        Vector3 discardPosition = Discard.transform.position; // Base position of the Discard
        float zOffset = 0.01f; // Small offset to stack cards properly
        int discardCount = Discard.Discard.Count; // Start stacking on top of existing cards

        for (int i = Hand.Count - 1; i >= 0; i--)
        {
            Transform card = Hand[i];
            Hand.RemoveAt(i);                 // Remove from hand
            Discard.Discard.Add(card);        // Add to Discard list

            // Calculate stacked position in Discard
            Vector3 targetPos = discardPosition + new Vector3(0f, 0f, -discardCount * zOffset);
            discardCount++;

            // Animate moving back to Discard
            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, targetPos, delaySeconds: 0f, durationSeconds: 0.2f)
            );

            if(!isPlayerHandFlag)
            {
                //flip card
                ActionSystem.Instance.Actions.Enqueue(
                new RotateAction(card, Quaternion.Euler(0f, 180f, 0f), delaySeconds: 0f, durationSeconds: 0.1f)
                );
            }            
        }

        fixHandPlaceMentFlag = true;
    }

    public void HandCardsPlacement()
    {
        float cardSpacing = 1.2f;
        float moveDuration = 0.2f;
        
        if (Hand.Count == 0) return;

        Vector3 centerPos = transform.position;
        Vector3 rightDir = transform.right; // respects rotation

        float middleIndex = (Hand.Count - 1) / 2f;

        for (int i = 0; i < Hand.Count; i++)
        {
            Transform card = Hand[i];

            float offset = (i - middleIndex) * cardSpacing;
            Vector3 targetPos = centerPos + rightDir * offset;

            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, targetPos, delaySeconds: 0f, durationSeconds: moveDuration)
            );

            // Optional: match hand rotation
            ActionSystem.Instance.Actions.Enqueue(
                new RotateAction(card, transform.rotation, delaySeconds: 0f, durationSeconds: moveDuration)
            );

            if(isPlayerHandFlag == true)
            {
                //flip the card
                ActionSystem.Instance.Actions.Enqueue(
                new RotateAction(card, Quaternion.Euler(0f, 180f, 0f), delaySeconds: 0.0f, durationSeconds: 0.1f)
                );
            }
        }
    }

    public void GiveCardsToDiscard()
    {
        if (Hand.Count == 0 || Discard == null) return;

        Vector3 discardPosition = Discard.transform.position; // Base position of the Discard
        float zOffset = 0.01f; // Small offset to stack cards properly
        int discardCount = Discard.Discard.Count; // Start stacking on top of existing cards

        Transform card = Hand[0];
        Hand.RemoveAt(0);                 // Remove from hand
        Discard.Discard.Add(card);        // Add to Discard list

        // Calculate stacked position in Discard
        Vector3 targetPos = discardPosition + new Vector3(0f, 0f, -discardCount * zOffset);
        discardCount++;

        // Animate moving back to Discard
        ActionSystem.Instance.Actions.Enqueue(
            new MoveAction(card, targetPos, delaySeconds: 0f, durationSeconds: 0.2f)
        );

        if (!isPlayerHandFlag)
        {
            //flip card
            ActionSystem.Instance.Actions.Enqueue(
            new RotateAction(card, Quaternion.Euler(0f, 180f, 0f), delaySeconds: 0.1f, durationSeconds: 0.5f)
            );
        }

        fixHandPlaceMentFlag = true;
    }

    private void Update()
    {
        // Press D to return all cards to the deck
        if (Input.GetKeyDown(KeyCode.D))
        {
            GiveCardsBackToDeck();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GiveAllCardsToDiscard();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GiveCardsToDiscard();
            
        }

        //fix hand card placement
        if(fixHandPlaceMentFlag == true)
        {
            HandCardsPlacement();
            fixHandPlaceMentFlag = false;
        }

        
    }
}
