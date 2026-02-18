using System.Collections.Generic;

public sealed class ActionList
{
    private readonly List<GameAction> _list = new List<GameAction>();
    private GameAction _current;

    public int PendingCount => _list.Count;
    public GameAction Current => _current;

    public void Enqueue(GameAction action)
    {
        if (action != null)
            _list.Add(action); // Add to end (like Enqueue)
    }

    public void Clear()
    {
        _list.Clear();
        _current = null;
    }

    public void Tick(float deltaTime)
    {
        if (_current == null)
        {
            if (_list.Count == 0)
                return;

            _current = _list[0];   // Take first item
            _list.RemoveAt(0);     // Remove it (like Dequeue)
        }

        _current.Update(deltaTime);

        if (_current.Done)
            _current = null;
    }
}
