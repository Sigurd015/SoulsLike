public class Timer
{
    private enum TimerState
    {
        Stopped,
        Running,
        Paused
    }
    private TimerState state;
    private float durationTime;
    private float elpasedTime;

    public void Tick(float deltaTime)
    {
        if (state == TimerState.Running)
        {
            elpasedTime += deltaTime;
            if (elpasedTime >= durationTime)
            {
                state = TimerState.Stopped;
            }
        }
    }

    public void Start(float durationTime)
    {
        this.durationTime = durationTime;
        elpasedTime = 0;
        state = TimerState.Running;
    }

    public void Pause()
    {
        state = TimerState.Paused;
    }

    public bool IsRunning()
    {
        return state == TimerState.Running;
    }

    public bool IsStopped()
    {
        return state == TimerState.Stopped;
    }
}