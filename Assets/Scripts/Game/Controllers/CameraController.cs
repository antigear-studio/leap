using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap {
    /// <summary>
    /// Controls camera movement. Smoothly pans the camera to the player's
    /// position.
    /// </summary>
    public class CameraController : MonoBehaviour {
        /// <summary>
        /// The camera to pan.
        /// </summary>
        public Transform Camera;

        /// <summary>
        /// The target object to follow.
        /// </summary>
        public Transform Target;

        /// <summary>
        /// The speed in which panning takes place.
        /// </summary>
        public float PanSpeed;

        void Update() {
		    if (Camera != null && Target != null) {
                float t = Time.deltaTime * PanSpeed;
                Vector3 pos = Vector2.Lerp(Camera.position, Target.position, t);
                pos.z = Camera.position.z;
                Camera.position = pos;
            }
        }
    }
}