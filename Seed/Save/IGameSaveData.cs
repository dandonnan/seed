namespace Seed.Save
{
    using Seed.Achievements;

    public interface IGameSaveData
    {
        string Language { get; set; }

        BaseAudioOptions Audio { get; set; }

        BaseGraphicsOptions Graphics { get; set; }

        BaseControlsOptions Controls { get; set; }

        List<Achievement> Achievements { get; set; }
    }
}