using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Game {
    /// <summary>
    /// User interface controller.
    /// </summary>
    public class UIController : MonoBehaviour {
        GameModel gameModel;

        public GameModel GameModel {
            get {
                return gameModel;
            }

            set {
                gameModel = value;
                GameView.GameModel = gameModel;
            }
        }

        public GameView GameView;
    }
}
