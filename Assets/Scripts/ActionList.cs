using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour
{
    private enum ActionType
    {
        Move,
        Wait
    }

    private class Action
    {
        public ActionType type;

        // Move
        public Transform target;
        public Vector3 destination;
        public float speed;

        // Wait
        public float duration;
        public float timer;
    }

    private Queue<Action> actions = new Queue<Action>();
    private Action currentAction;


    //--------------------

    public void AddMove(Transform target, Vector3 destination, float speed)
    {
        actions.Enqueue(new Action
        {
            type = ActionType.Move,
            target = target,
            destination = destination,
            speed = speed
        });
    }

    public void AddWait(float duration)
    {
        actions.Enqueue(new Action
        {
            type = ActionType.Wait,
            duration = duration,
            timer = 0f
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAction == null && actions.Count > 0)
        {
            currentAction = actions.Dequeue();
        }

        if (currentAction == null)
            return;

        switch (currentAction.type)
        {
            case ActionType.Move:
                UpdateMove();
                break;

            case ActionType.Wait:
                UpdateWait();
                break;
        }
    }

    //---------- ACTION LOGIC ----------
    private void UpdateMove()
    {
        currentAction.target.position = Vector3.MoveTowards(
            currentAction.target.position,
            currentAction.destination,
            currentAction.speed * Time.deltaTime
        );

        if (Vector3.Distance(
            currentAction.target.position,
            currentAction.destination) < 0.01f)
        {
            currentAction = null;
        }
    }

    private void UpdateWait()
    {
        currentAction.timer += Time.deltaTime;

        if (currentAction.timer >= currentAction.duration)
        {
            currentAction = null;
        }
    }

}
