using System;
using UnityEngine;

public abstract class GameAction
{
    public float Delay { get; private set; }
    public float Duration { get; private set; }

    public float DelayElapsed { get; private set; }
    public float TimeElapsed { get; private set; }

    public bool Started { get; private set; }
    public bool Done { get; private set; }

    public float Percent
    {
        get
        {
            if (!Started) return 0f;
            if (Duration <= 0f) return 1f;
            return Mathf.Clamp01(TimeElapsed / Duration);
        }
    }

    protected GameAction(float delaySeconds, float durationSeconds)
    {
        Delay = Mathf.Max(0f, delaySeconds);
        Duration = Mathf.Max(0f, durationSeconds);
    }


    public float TimeLeft()
    {
        if (Done) return 0f;

        float delayLeft = Mathf.Max(0f, Delay - DelayElapsed);

        if (!Started)
        {

            return delayLeft + Duration;
        }


        return Mathf.Max(0f, Duration - TimeElapsed);
    }

    public void Update(float deltaTime)
    {
        if (Done) return;

        float dt = Mathf.Max(0f, deltaTime);


        if (!Started)
        {
            if (DelayElapsed < Delay)
            {
                DelayElapsed = Mathf.Min(Delay, DelayElapsed + dt);
                if (DelayElapsed < Delay)
                {

                    return;
                }
            }

            Started = true;
            OnStart();
        }


        if (Duration <= 0f)
        {
            OnUpdate(1f);
            OnFinish();
            Done = true;
            return;
        }


        TimeElapsed = Mathf.Min(Duration, TimeElapsed + dt);
        OnUpdate(Percent);

        if (TimeElapsed >= Duration)
        {
            OnFinish();
            Done = true;
        }
    }


    protected virtual void OnStart() { }


    protected abstract void OnUpdate(float percent);


    protected virtual void OnFinish() { }
}
