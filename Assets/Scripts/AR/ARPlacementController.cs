using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using SpaceOrigin.Planets;
using DigitalRubyShared;

namespace SpaceOrigin.AR
{
    public class ARPlacementController : MonoBehaviour
    {
        public ARRaycastManager raycastManager;
        public GameObject placementHintObject;
        public LayerMask placementHintLayer;
        public Camera arCamera;
        public ARObject arObject;

        private TapGestureRecognizer tapGesture;
        private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
        private Vector2 _screenCenter;

        void Start()
        {
            _screenCenter = new Vector2((Screen.width / 2), (Screen.height / 2));
            CreateTapGesture();
            placementHintObject.SetActive(false);
        }

        void Update()
        {
            if (raycastManager.Raycast(_screenCenter, _hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = _hits[0].pose;
                placementHintObject.SetActive(true);
                placementHintObject.transform.position = hitPose.position;
            }
            else
            {
                placementHintObject.SetActive(false);
            }
        }

        private void CreateTapGesture()
        {
            tapGesture = new TapGestureRecognizer();
            tapGesture.StateUpdated += TapGestureCallback;
            FingersScript.Instance.AddGesture(tapGesture);
        }

        private void TapGestureCallback(GestureRecognizer gesture)
        {
            if (gesture.State == GestureRecognizerState.Ended)
            {
                OnTapped();
            }
        }

        private void OnTapped( )
        {
            Ray ray = arCamera.ScreenPointToRay(_screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, placementHintLayer))
            {
                arObject.SetObjectActive(true);
                arObject.Move(placementHintObject.transform.position +Vector3.up*1.1f);
            }

            #if UNITY_EDITOR
            arObject.SetObjectActive(true);
            arObject.Move(placementHintObject.transform.position + Vector3.up * 1.1f);
            #endif
        }
    }
}
