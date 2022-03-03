using Base.Component;
using UnityEngine;

namespace Game.Components
{
    public class SettingsComponent : MonoBehaviour, IComponent
    {
        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
            //TODO Handle SettingsComponent
        }
    }
}