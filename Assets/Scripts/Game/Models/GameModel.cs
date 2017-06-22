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

        // What are platforms?
        // They give jump counts, well some do anyway. Do they need to be
        // recorded by the model? Well they are part of the model alright, the
        // level that is. But do we need to keep track of them HERE? Do we need
        // to access individual platforms in the game model?
        // We might! We want to speed up the platform the player is on! But then
        // we can do that without grabbing everything...HMM...

        // We should have view referring to the model, updating and changing as
        // we go. 
    }
}
