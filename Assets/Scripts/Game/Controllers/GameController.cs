using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Leap.Utility;

namespace Leap.Game {
    /// <summary>
    /// The topmost controller for the game.
    /// </summary>
    public class GameController : MonoBehaviour {
        Coroutine loadLevelCoroutine;

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

            // We need to load the appropriate level. This depends whether the
            // user started at a check point.
            int lv = ZPlayerPrefs.GetInt(ZPlayerPrefKey.LoadingCheckPoint);
            LoadLevel(lv + 2);

            if (lv == 0) {
                gameModel.LeapCount = 10;
            } else {
                // Load check point leap count
                string key = ZPlayerPrefKey.CheckPointScorePrefix + lv;
                gameModel.LeapCount = ZPlayerPrefs.GetInt(key);
            }
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

        /// <summary>
        /// Loads the given level and push it to wherever the current level
        /// geometry ends.
        /// </summary>
        void LoadLevel(int lv) {
            if (loadLevelCoroutine != null) {
                Debug.LogError("Level loading is still in progress!");
                return;
            }

            loadLevelCoroutine = StartCoroutine(LoadLevelCoroutine(lv));
        }

        IEnumerator LoadLevelCoroutine(int lv) {
            float lvEnd = 0;
            LevelController lvController = FindObjectOfType<LevelController>();

            if (lvController != null) {
                lvEnd = lvController.transform.position.x;
                lvEnd += lvController.CalculateLength();
                Destroy(lvController);
            }

            AsyncOperation task = SceneManager.LoadSceneAsync(lv, 
                                      LoadSceneMode.Additive);

            yield return task;

            lvController = FindObjectOfType<LevelController>();

            if (lvController != null) {
                lvController.PositionLevel(lvEnd);
            } else {
                Debug.LogError("Loaded level has no LevelController!");
            }

            loadLevelCoroutine = null;
        }
    }
}
