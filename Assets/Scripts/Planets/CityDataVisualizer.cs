using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.Planets;
using TMPro;

namespace SpaceOrigin.Planets
{ 
    public class CityDataVisualizer : MonoBehaviour
    {
        public TextMeshPro cityNameText;
       
        private CityData _cityInfo;
        private bool _initalizedData = false;
        private Earth _planetEarth;

        void Start()
        {
        
        }

        void Update() // TOD0): update ony if therer is a update on postion and roation on the planetEarth, 
        {
            if (_initalizedData)
            {
                Quaternion defaultRotaion = (Quaternion.AngleAxis(_cityInfo.longitude, -_planetEarth.transform.up) * Quaternion.AngleAxis(_cityInfo.latitude, -_planetEarth.transform.right));
                transform.position = _planetEarth.transform.position + ((defaultRotaion * _planetEarth.transform.rotation) * new Vector3(0, 0, _planetEarth.Radius*1.02f));
            } 
        }

        public void SetCityData(CityData cityData, Earth planetEarth)
        {
            _planetEarth = planetEarth;
            _cityInfo = cityData;
            cityNameText.text = _cityInfo.cityName;
            _initalizedData = true;
        }
    }
}
