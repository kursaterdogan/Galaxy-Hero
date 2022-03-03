using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class SuperPowerComponent : MonoBehaviour, IComponent
    {
        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
            //TODO Handle SuperPowerComponent
        }
    }
}