namespace Seed.Save
{
    using Seed.Achievements;

    public interface IGameSaveData
    {
        string Language { get; protected set; }

        BaseAudioOptions Audio { get; protected set; }

        BaseGraphicsOptions Graphics { get; protected set; }

        BaseControlsOptions Controls { get; protected set; }

        List<Achievement> Achievements { get; protected set; }
    }
}