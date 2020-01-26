using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceOrigin.Planets
{
    [CreateAssetMenu(fileName = "CityDatas", menuName = "ScriptableObjects/CityDataList", order = 1)]
    public class CityDatasScriptableObject : ScriptableObject
    {
        public List<CityData> cityDataList;
    }
}
