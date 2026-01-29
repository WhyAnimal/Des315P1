using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOfCards_Action : MonoBehaviour
{
    //public Transform Entity;
    public List<Transform> Deck;

    private void Start()
    {
        foreach(Transform cards in Deck)
        {
            ActionSystem.Instance.Actions.Enqueue(
            new MoveAction(cards, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        );

            ActionSystem.Instance.Actions.Enqueue(
            new RotateAction(cards, Quaternion.Euler(0f, 180f, 0f), delaySeconds: 2.0f, durationSeconds: 0.75f)
        );

        }
        

        //ActionSystem.Instance.Actions.Enqueue(
        //    new MoveAction(Entity, new Vector3(10, 0, 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        //);


        //ActionSystem.Instance.Actions.Enqueue(
        //    new RotateAction(Entity, Quaternion.Euler(0f, 180f, 0f), delaySeconds: 2.0f, durationSeconds: 0.75f)
        //);


        //ActionSystem.Instance.Actions.Enqueue(
        //    new MoveAction(Entity, new Vector3(0f, -20f, 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        //);
    }
}