using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard_Action : MonoBehaviour
{
    public List<Transform> Discard;        // Cards currently in Discard
    public DeckOfCards_Action DeckScript; // Reference to the deck prefab/script

    // Move all cards in Discard back to the deck
    public void GiveCardsBackToDeck()
    {
        if (Discard.Count == 0 || DeckScript == null) return;

        Vector3 deckPosition = DeckScript.transform.position; // Base position of the deck
        float zOffset = 0.01f; // Small offset to stack cards properly
        int deckCount = DeckScript.Deck.Count; // Start stacking on top of existing cards

        for (int i = Discard.Count - 1; i >= 0; i--)
        {
            Transform card = Discard[i];
            Discard.RemoveAt(i);                 // Remove from Discard
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

    private void Update()
    {
        // Press D to return all cards to the deck
        if (Input.GetKeyDown(KeyCode.D))
        {
            GiveCardsBackToDeck();

        }
    }
}
