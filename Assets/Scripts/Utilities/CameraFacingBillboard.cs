using UnityEngine;

namespace SpaceOrigin.Utilities
{
    public class CameraFacingBillboard : MonoBehaviour
    {
        public Camera mainCamera { set; private get; }

        void LateUpdate()
        {
            if (mainCamera != null) //_camera = Camera.main; // caching main camera
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
        }
    }
}