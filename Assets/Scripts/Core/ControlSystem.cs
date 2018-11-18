using System;
using UnityEngine;

namespace Core.ControlSystem
{
    public class ControlSystem
    {
        /// <summary>
        /// Returns the axis for Horizontal and Vertical without any modification.
        /// </summary>
        public static Vector2 Axis
        {
            get
            {
                return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }

        /// <summary>
        /// Returns the axis for Horizontal and Vertical multiplied by delta time.
        /// </summary>
        public static Vector2 FixedAxis
        {
            get
            {
                return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;
            }
        }

        /// <summary>
        /// Moves something in Forward and Horizontal Axis.
        /// </summary>
        /// <param name="t">The trasnform of the object for move it</param>
        /// <param name="speed">The speed value of the movement</param>
        public static void Move(Transform t, float speed)
        {
            t.Translate(new Vector3(FixedAxis.x, 0f, FixedAxis.y) * speed);
        }

        public static bool Attack1
        {
            get
            {
                return Input.GetButtonDown("Fire1");
            }
        }

        public static bool SpaceBar
        {
            get
            {
                return Input.GetButtonDown("Jump");
            }
        }
    }
}
