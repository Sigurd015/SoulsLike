public class Button
{
    public bool IsPressing { get; private set; }
    public bool OnPressed { get; private set; }
    public bool OnReleased { get; private set; }
    public bool IsExtending { get; private set; }
    public bool IsDelaying { get; private set; }

    public float ExtendingDuration = 0.15f;
    public float DelayingDuration = 0.15f;

    private bool currState = false;
    private bool prevState = false;

    private Timer ExtendTimer = new Timer();
    private Timer DelayTimer = new Timer();

    public void Tick(bool isPressed, float deltaTime)
    {
        ExtendTimer.Tick(deltaTime);
        DelayTimer.Tick(deltaTime);
        IsPressing = currState = isPressed;

        OnPressed = false;
        OnReleased = false;

        if (currState != prevState)
        {
            if (currState)
            {
                OnPressed = true;
                DelayTimer.Pause();
                DelayTimer.Start(DelayingDuration);
            }
            else
            {
                OnReleased = true;
                ExtendTimer.Pause();
                ExtendTimer.Start(ExtendingDuration);
            }
        }

        prevState = currState;

        IsExtending = ExtendTimer.IsRunning();
        IsDelaying = DelayTimer.IsRunning();
    }
}