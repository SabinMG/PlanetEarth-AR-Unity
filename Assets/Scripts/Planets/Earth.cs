using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceOrigin.ObjectPool;
using SpaceOrigin.Utilities;

namespace SpaceOrigin.Planets
{
    public class Earth : Planet
    {
        public CityDatasScriptableObject cityDatasSO;
        public string cityDataVisPrefabname = "CityDataVisualizer";
       
        public float minScale = .3f;
        public float maxScale = 3.0f;

        private bool _initializedPlanet = false ;
        private float _radius = .5f;
        public float Radius { get => _radius; set => _radius = value; }

        protected override void Start()
        {
          base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        public override void Move(Vector3 location)
        {
            base.Move(location);
            if (!_initializedPlanet)
            {
                CreateCityDataVisulizers();
                _initializedPlanet = true;
            }
        }

        public override void Scale(float scaleDelta)
        {
            Vector3 localScale = transform.localScale;
            localScale  *= scaleDelta;
            float x = Mathf.Clamp(localScale.x, minScale, maxScale);
            _radius = x/2.0f;
            transform.localScale = new Vector3(x,x,x);
        }

        private void CreateCityDataVisulizers()
        {
            for (int i = 0; i < cityDatasSO.cityDataList.Count; i++)
            {
                CityData cityData = cityDatasSO.cityDataList[i];
                GameObject cityDataVisObj = PoolManager.Instance.GetObjectFromPool(cityDataVisPrefabname);
                CityDataVisualizer cityDataVisualizerComp = cityDataVisObj.GetComponent<CityDataVisualizer>();
                cityDataVisObj.GetComponent<CameraFacingBillboard>().mainCamera = arCamera;

                cityDataVisualizerComp.SetCityData(cityData, this);
                cityDataVisObj.SetActive(transform);
            }
        }
    }
}

