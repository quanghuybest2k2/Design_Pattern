abstract class Game
{
    public void Play()
    {
        Initialize();
        StartPlay();
        EndPlay();
    }

    public abstract void Initialize();
    public abstract void StartPlay();
    public abstract void EndPlay();
}