using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

namespace SpaceOrigin.AR
{ 
    public class ManipulationHandler : MonoBehaviour
    {
        public float gerstureRotationSpeed = 2.0f;
        public ARObject manipulationTarget;

        private PanGestureRecognizer panGesture;
        private ScaleGestureRecognizer scaleGesture;

        void Start()
        {
            CreatePanGesture();
            CreateScaleGesture();
        }

        private void CreatePanGesture()
        {
            panGesture = new PanGestureRecognizer();
            panGesture.MinimumNumberOfTouchesToTrack = 1;
            panGesture.StateUpdated += PanGestureCallback;
            FingersScript.Instance.AddGesture(panGesture);
        }

        private void CreateScaleGesture()
        {
            scaleGesture = new ScaleGestureRecognizer();
            scaleGesture.StateUpdated += ScaleGestureCallback;
            FingersScript.Instance.AddGesture(scaleGesture);
        }

        private void PanGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Executing)
            {
                float deltaX = (panGesture.DeltaX / 25.0f)* gerstureRotationSpeed;
                if(manipulationTarget.IsObjectInFrontTouch(new Vector3(gesture.FocusX, gesture.FocusY,0))) manipulationTarget.Rotate(-deltaX);
            }
        }

        private void ScaleGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Executing)
            {
                if (manipulationTarget.IsObjectInFrontTouch(new Vector3(gesture.FocusX, gesture.FocusY, 0))) manipulationTarget.Scale(scaleGesture.ScaleMultiplier);
            }
        }  
    }
}
