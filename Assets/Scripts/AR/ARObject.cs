using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.AR
{
    public class ARObject : MonoBehaviour,IMovable,IRotatable,IScalable
    {
        public Camera arCamera;
        private LayerMask _arObjectLayer;

        protected virtual void Start()
        {
            _arObjectLayer |= (1 << gameObject.layer); 
        }

        protected virtual void Update()
        {

        }

        public virtual void Move(Vector3 position)
        {
            transform.position = position;
        }

        public virtual void Rotate(float deltaRotation)
        {
            transform.Rotate(0, deltaRotation, 0); // for  now only y axis
        }

        public virtual void Scale(float scaleDelta)
        {
            transform.localScale *= scaleDelta;
        }

        public void SetObjectActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public bool IsObjectInFrontTouch(Vector3 touchInput)
        {
            Ray ray = arCamera.ScreenPointToRay(touchInput);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _arObjectLayer))
            {
                return true;
            }
            return false;
        }
    }
}
