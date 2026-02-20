using UnityEngine;

public sealed class FadeInAction : GameAction
{
    private readonly CanvasGroup _target;
    private readonly float _toValue;
    private readonly bool _useLocal;
    private int _easingType;

    private float _fromValue;

    public FadeInAction(CanvasGroup target, float toValue, float delaySeconds, float durationSeconds, bool useLocal = false, int EasingType = 0) // set EasingType to 0 for liner and 1 for easeOutSine
        : base(delaySeconds, durationSeconds)
    {
        _target = target;
        _toValue = toValue;
        _useLocal = useLocal;
        _easingType = EasingType;
    }

    protected override void OnStart()
    {
        if (_target == null) return;
        _fromValue = _useLocal ? _target.alpha : _target.alpha;
    }

    protected override void OnUpdate(float percent)
    {
        if (_target == null) return;

        float newValue;

        switch (_easingType)
        { 
            case 0: // linear
                newValue = Mathf.Lerp(_fromValue, _toValue, percent);

                if (_useLocal) _target.alpha = newValue;
                else _target.alpha = newValue;
                break;
        };        
    }

    protected override void OnFinish()
    {
        if (_target == null) return;

        // Snap to exact destination
        if (_useLocal) _target.alpha = _toValue;
        else _target.alpha = _toValue;
    }
}
