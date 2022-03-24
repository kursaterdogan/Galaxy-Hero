using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class EndGameComponent : MonoBehaviour, IComponent, IConstructable
    {
        public delegate void EndGameChangeDelegate();

        public void Initialize(ComponentContainer componentContainer)
        {
            //TODO Handle EndGameComponent
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
        }

        public void OnConstruct()
        {
        }
    }
}