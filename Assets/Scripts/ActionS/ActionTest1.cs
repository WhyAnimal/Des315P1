using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTest1 : MonoBehaviour
{
    public Transform Entity;

    private void Start()
    {

        ActionSystem.Instance.Actions.Enqueue(
            new MoveAction(Entity, new Vector3(10, 0, 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        );


        ActionSystem.Instance.Actions.Enqueue(
            new RotateAction(Entity, Quaternion.Euler(180f, 0f, 0f), delaySeconds: 2.0f, durationSeconds: 0.75f)
        );


        //ActionSystem.Instance.Actions.Enqueue(
        //    new MoveAction(Entity, new Vector3(0f, -20f, 0f), delaySeconds: 0.5f, durationSeconds: 1.5f)
        //);
    }
}