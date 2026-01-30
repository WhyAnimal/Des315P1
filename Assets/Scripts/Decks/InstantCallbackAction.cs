//public sealed class InstantCallbackAction : GameAction
//{
//    private readonly System.Action _callback;

//    public InstantCallbackAction(System.Action callback)
//        : base(0f, 0f)
//    {
//        _callback = callback;
//    }

//    protected override void OnUpdate(float percent)
//    {
//        _callback?.Invoke();
//    }
//}