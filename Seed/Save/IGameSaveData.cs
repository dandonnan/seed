namespace Seed.Save
{
    using Seed.Achievements;

    public interface IGameSaveData
    {
        List<Achievement> Achievements { get; protected set; }
    }
}