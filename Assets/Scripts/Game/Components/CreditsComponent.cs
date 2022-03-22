using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class CreditsComponent : MonoBehaviour, IComponent
    {
        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
        }
    }
}