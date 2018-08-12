using System;

public class AttackerHealthController : HealthController
{
    private CountdownPane countdownPane;

    protected override void Start()
    {
        base.Start();
        countdownPane = FindObjectOfType<CountdownPane>();
        if (countdownPane == null)
        {
            throw new NullReferenceException("Could not find CountdownPane in the scene!");
        }
    }

    public override void Destroy()
    {
        countdownPane.Decrement();
        base.Destroy();
    }
}
