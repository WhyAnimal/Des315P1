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

    public Vector3 MouseClickPosition;

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
        float moveDuration = 0.1f;
        
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

            if(isPlayerHandFlag == true)
            {
                //flip the card
                ActionSystem.Instance.Actions.Enqueue(
                new RotateAction(card, Quaternion.Euler(0f, 180f, 0f), delaySeconds: 0.0f, durationSeconds: 0.1f)
                );
            }
            else
            {
                // Optional: match hand rotation
                ActionSystem.Instance.Actions.Enqueue(
                    new RotateAction(card, transform.rotation, delaySeconds: 0f, durationSeconds: moveDuration)
                );
            }

        }
    }

    public void GiveCardsToDiscard(int CardToDiscardIndex = 0)
    {
        if (Hand.Count == 0 || Discard == null) return;

        Vector3 discardPosition = Discard.transform.position; // Base position of the Discard
        float zOffset = 0.01f; // Small offset to stack cards properly
        int discardCount = Discard.Discard.Count; // Start stacking on top of existing cards

        Transform card = Hand[CardToDiscardIndex];
        Hand.RemoveAt(CardToDiscardIndex);    // Remove from hand
        Discard.Discard.Add(card);            // Add to Discard list

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

    public void PlayARound()
    {
        if(!isPlayerHandFlag)
        {
            //1 in 5 chance it would draw a card
            if(Random.Range(1, 6) == 1)
            {
                //pull a card
                DeckScript.GiveCardToHand(this);
            }
            else
            {
                //discard a card
                GiveCardsToDiscard();
            }
            
        }
    }

    public bool PlayerClickACard()
    {
        if(!isPlayerHandFlag)
        {
            return false;
        }
        if (!Input.GetMouseButtonDown(0) || Hand.Count == 0)
        {
            return false;
        }

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);

        if (hit == null)
            return false;

        // Check if the clicked object is one of the cards in hand
        if (Hand.Contains(hit.transform))
        {
            int cardIndex = Hand.IndexOf(hit.transform);
            GiveCardsToDiscard(cardIndex);
            return true;
        }

        return false;
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

        //if (Input.GetMouseButtonDown(0))
        //{
        //    MouseClickPosition = Input.mousePosition;
        //    PlayerClickACard();
        //}
    }
}
