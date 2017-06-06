using UnityEngine;

namespace Leap {
    /// <summary>
    /// The topmost controller for the game.
    /// </summary>
    public class GameController : MonoBehaviour {
        /// <summary>
        /// The overall game model. This class owns it.
        /// </summary>
        public GameModel gameModel = new GameModel();

        /// <summary>
        /// The character controller.
        /// </summary>
        public CharacterController CharacterController;

        void Start() {
            CharacterController.GameModel = gameModel;
            gameModel.LeapCount += 10;
        }

        void Update() {
            switch (gameModel.GameState) {
                case GameState.Playing:
                    CheckLoseCondition();
                    break;
            }
        }

        void CheckLoseCondition() {
            if (CharacterController.IsDead()) {
                gameModel.GameState = GameState.Over;
                Time.timeScale = 0;
            }
        }
    }
}
