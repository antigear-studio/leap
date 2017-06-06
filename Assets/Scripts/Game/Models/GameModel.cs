using UnityEngine;
using System;

namespace Leap.Game {
    /// <summary>
    /// Model for a game. Each level will be incrementally loaded into the game,
    /// but they should be the geometry and not affect the model.
    /// </summary>
    public class GameModel {
        int leapCount;

        /// <summary>
        /// The number of leaps remaining for the player.
        /// </summary>
        public int LeapCount {
            get {
                return leapCount;
            }

            set {
                if (value < 0) {
                    Debug.LogError("Leap count cannot be negative!");
                } else {
                    leapCount = value;
                }
            }
        }

        /// <summary>
        /// Stores the state of the game.
        /// </summary>
        public GameState GameState {
            get;
            set;
        }
    }
}
