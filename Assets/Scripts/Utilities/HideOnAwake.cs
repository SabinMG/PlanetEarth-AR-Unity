using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Utilities
{ 
    public class HideOnAwake : MonoBehaviour
    {
        public bool hide = true;
        void Awake()
        {
            gameObject.SetActive(!hide);
        }
    }
}
