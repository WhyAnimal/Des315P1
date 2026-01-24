using UnityEngine;

public sealed class RotateAction : GameAction
{
    private readonly Transform _target;
    private readonly Quaternion _toRotation;
    private readonly bool _useLocal;

    private Quaternion _fromRotation;

    public RotateAction(Transform target, Quaternion toRotation, float delaySeconds, float durationSeconds, bool useLocal = false)
        : base(delaySeconds, durationSeconds)
    {
        _target = target;
        _toRotation = toRotation;
        _useLocal = useLocal;
    }

    protected override void OnStart()
    {
        if (_target == null) return;
        _fromRotation = _useLocal ? _target.localRotation : _target.rotation;
    }

    protected override void OnUpdate(float percent)
    {
        if (_target == null) return;

        Quaternion newPos = Quaternion.Lerp(_fromRotation, _toRotation, percent);

        if (_useLocal) _target.localRotation = newPos;
        else _target.rotation = newPos;
    }

    protected override void OnFinish()
    {
        if (_target == null) return;

        // Snap to exact destination
        if (_useLocal) _target.localRotation = _toRotation;
        else _target.rotation = _toRotation;
    }
}
