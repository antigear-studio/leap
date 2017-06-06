using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Game {
    /// <summary>
    /// This is the root class for each level. We use this to adjust where to
    /// position levels after they load.
    /// </summary>
    public class LevelController : MonoBehaviour {
        /// <summary>
        /// Calculates the length of this level.
        /// </summary>
        public float CalculateLength() {
            Collider[] colliders = GetComponentsInChildren<Collider>();

            Bounds b = new Bounds();

            foreach (Collider c in colliders) {
                b.Encapsulate(c.bounds.min);
                b.Encapsulate(c.bounds.max);
            }

            return b.size.x;
        }

        /// <summary>
        /// Positions this level so that it aligns with the previous level.
        /// </summary>
        /// <param name="prevLvEnd">Previous lv end.</param>
        public void PositionLevel(float prevLvEnd) {
            transform.position = new Vector3(prevLvEnd, 0);
        }
    }
}
