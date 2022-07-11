namespace Battleships;

public enum ShotResult
{
    Unknown = 0,

    /// <summary>
    /// No ship was hit at the location.
    /// </summary>
    Miss = 1,

    /// <summary>
    /// Ship part was hit.
    /// </summary>
    Hit = 2
}