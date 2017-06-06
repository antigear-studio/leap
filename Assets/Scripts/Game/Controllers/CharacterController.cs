using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap {
    /// <summary>
    /// Manages player controls. This reads input from the player.
    /// </summary>
    public class CharacterController : MonoBehaviour {
        bool isJumping;
        float jumpDuration;

        /// <summary>
        /// The game model used in the game. This class is a collaborator and
        /// the game model is set by its parent controller.
        /// </summary>
        public GameModel GameModel;

        /// <summary>
        /// The character's rigid body. The script controls this body to achieve
        /// movement.
        /// </summary>
        public Rigidbody CharacterBody;

        /// <summary>
        /// The rate at which jump energy decays when user holds down the jump
        /// button. 0 means jump never decays and player will keep going up.
        /// </summary>
        public float JumpDecayFactor;

        /// <summary>
        /// The initial jump speed.
        /// </summary>
        public float JumpSpeed;

        /// <summary>
        /// The movement speed.
        /// </summary>
        public float MoveSpeed;

        void Update() {
            HandleInput();
            Move();
        }

        void HandleInput() {
            // Jump is triggered if either player taps anywhere on screen that
            // is not UI or space-key is pressed. We handle space here.
            if (Input.GetKeyDown(KeyCode.Space)) {
                BeginJump();
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                EndJump();
            }
        }

        /// <summary>
        /// Starts a jump. Detects whether there are reamining jumps. The longer
        /// the jump is the higher the character gets, to a certain point. If
        /// for any reason character is already jumping (here jumping means jump
        /// key is held down), then nothing happens.
        /// </summary>
        public void BeginJump() {
            if (isJumping || GameModel.LeapCount == 0) {
                return;
            }

            GameModel.LeapCount -= 1;
            isJumping = true;

            // We reset jump force here, and sets initial jump velocity.
            Vector3 v = CharacterBody.velocity;
            v.y = JumpSpeed;
            CharacterBody.velocity = v;
            jumpDuration = 0;
        }

        /// <summary>
        /// Ends a jump. The longer the jump is the higher the character gets,
        /// to a certain point.
        /// </summary>
        public void EndJump() {
            isJumping = false;
        }

        void Move() {
            Vector3 v = CharacterBody.velocity;

            if (isJumping) {
                // Apply upward force.
                jumpDuration += Time.deltaTime;
                v.y += JumpSpeed * Mathf.Exp(jumpDuration * JumpDecayFactor);
            }

            // Apply forward force.
            v.x = MoveSpeed;

            CharacterBody.velocity = v;
        }

        /// <summary>
        /// Determines whether the character fell and is game over.
        /// </summary>
        public bool IsDead() {
            return CharacterBody.transform.position.y < 0;
        }
    }
}
