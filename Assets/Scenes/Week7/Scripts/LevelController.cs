using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _07_LEVELCONTROLLER
{
    public class LevelController : MonoBehaviour
    {
        [HideInInspector]
        public static float leftSide, rightSide;
        private float intLeft, intRight;

        private void Awake()
        {
            //Declare
            leftSide = -3.5f;
            rightSide = +3.5f;
        }

        private void Update()
        {
            intLeft = leftSide;
            intRight = rightSide;
        }
    }
}