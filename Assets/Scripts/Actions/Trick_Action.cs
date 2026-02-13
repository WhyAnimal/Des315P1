using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trick_Action : MonoBehaviour
{
    public List<Transform> Trick;        // Cards currently in Trick Pile

    public Discard_Action Discard;        // Reference to the Discard

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GiveAllCardsToDiscard()
    {
        if (Trick.Count == 0 || Discard == null) return;

        Vector3 discardPosition = Discard.transform.position; // Base position of the Discard
        float zOffset = 0.01f; // Small offset to stack cards properly
        int discardCount = Discard.Discard.Count; // Start stacking on top of existing cards

        float cardsDelay = 1.5f;

        for (int i = Trick.Count - 1; i >= 0; i--)
        {
            Transform card = Trick[i];
            Trick.RemoveAt(i);                 // Remove from Trick
            Discard.Discard.Add(card);        // Add to Discard list

            // Calculate stacked position in Discard
            Vector3 targetPos = discardPosition + new Vector3(0f, 0f, -discardCount * zOffset);
            discardCount++;

            // Animate moving back to Discard
            ActionSystem.Instance.Actions.Enqueue(
                new MoveAction(card, targetPos, delaySeconds: cardsDelay, durationSeconds: 0.2f)
            );

            cardsDelay = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
