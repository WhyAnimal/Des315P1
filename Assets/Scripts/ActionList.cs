using System.Collections.Generic;

public sealed class ActionList
{
    private readonly Queue<GameAction> _queue = new Queue<GameAction>();
    private GameAction _current;

    public int PendingCount => _queue.Count;
    public GameAction Current => _current;

    public void Enqueue(GameAction action)
    {
        if (action != null)
            _queue.Enqueue(action);
    }

    public void Clear()
    {
        _queue.Clear();
        _current = null;
    }


    public void Tick(float deltaTime)
    {

        if (_current == null)
        {
            if (_queue.Count == 0) return;
            _current = _queue.Dequeue();
        }

        _current.Update(deltaTime);


        if (_current.Done)
            _current = null;
    }
}
