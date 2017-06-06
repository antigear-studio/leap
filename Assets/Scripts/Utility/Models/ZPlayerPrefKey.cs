namespace Leap.Utility {
    /// <summary>
    /// List of secure player preference keys.
    /// </summary>
    public static class ZPlayerPrefKey {
        /// <summary>
        /// Integer of the check point to load into game.
        /// </summary>
        public static string LoadingCheckPoint = "LoadingCheckPoint";

        /// <summary>
        /// Integers of the number of leaps at a check point. This is appended
        /// with the level number, e.g. 4, to form the actual key to the player
        /// prefs.
        /// </summary>
        public static string CheckPointScorePrefix = "CheckPointScorePrefix";
    }
}
