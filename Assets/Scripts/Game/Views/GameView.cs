using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leap.Game {
    /// <summary>
    /// Manages the main game UI overlays.
    /// </summary>
    public class GameView : MonoBehaviour {
        /// <summary>
        /// The game model, passed as reference. This class is not the owner.
        /// </summary>
        public GameModel GameModel;

        /// <summary>
        /// The label that displays how many leaps are left.
        /// </summary>
        public Text LeapCountText;

        void Update() {
            LeapCountText.text = GameModel.LeapCount.ToString();
        }

    }
}