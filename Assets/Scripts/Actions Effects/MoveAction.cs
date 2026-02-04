using UnityEngine;

public sealed class MoveAction : GameAction
{
    private readonly Transform _target;
    private readonly Vector3 _toPosition;
    private readonly bool _useLocal;
    private int _easingType;

    private Vector3 _fromPosition;

    public MoveAction(Transform target, Vector3 toPosition, float delaySeconds, float durationSeconds, bool useLocal = false, int EasingType = 1) // set EasingType to 0 for liner and 1 for easeOutSine
        : base(delaySeconds, durationSeconds)
    {
        _target = target;
        _toPosition = toPosition;
        _useLocal = useLocal;
        _easingType = EasingType;
    }

    protected override void OnStart()
    {
        if (_target == null) return;
        _fromPosition = _useLocal ? _target.localPosition : _target.position;
    }

    protected override void OnUpdate(float percent)
    {
        if (_target == null) return;

        Vector3 newPos;

        switch (_easingType)
        { 
            default: //linear
                newPos = Vector3.Lerp(_fromPosition, _toPosition, percent);

                if (_useLocal) _target.localPosition = newPos;
                else _target.position = newPos;

                break;
            case 0: // linear
                newPos = Vector3.Lerp(_fromPosition, _toPosition, percent);

                if (_useLocal) _target.localPosition = newPos;
                else _target.position = newPos;

                break;
            case 1: // easeOutSine
                float t = Mathf.Sin(percent * Mathf.PI * 0.5f);
                newPos = Vector3.Lerp(_fromPosition, _toPosition, t);

                if (_useLocal) _target.localPosition = newPos;
                else _target.position = newPos;
                break;
        };        
    }

    protected override void OnFinish()
    {
        if (_target == null) return;

        // Snap to exact destination
        if (_useLocal) _target.localPosition = _toPosition;
        else _target.position = _toPosition;
    }
}
