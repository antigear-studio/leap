using UnityEngine;
using System.Collections;

namespace Leap.Game {
    /// <summary>
    /// Platform component. This has various options to fine tune behavior.
    /// </summary>
    public class Platform : MonoBehaviour {
        /// <summary>
        /// The amount of jumps awarded to or taken away from the player once
        /// landed on this.
        /// Extra movement/rotation/disappearance should be added as more
        /// components.
        /// </summary>
        public int JumpCountDelta = 3;

        /// <summary>
        /// Whether the player has already landed on this platform and collected
        /// the jump bonus.
        /// </summary>
        public bool BonusCollected;

        /// <summary>
        /// Whether this platform gives repeated bonuses.
        /// </summary>
        public bool IsRecurring;

        void OnCollisionEnter(Collision collision) {
            if (collision.collider.CompareTag("Player") && !BonusCollected) {
                BonusCollected |= !IsRecurring;

                // Deliver bonus to game model. Somehow...
                GameObject g = GameObject.FindWithTag("GameController");
                GameController gc = g.GetComponent<GameController>();
                gc.gameModel.LeapCount += JumpCountDelta;
            }
        }
    }

}