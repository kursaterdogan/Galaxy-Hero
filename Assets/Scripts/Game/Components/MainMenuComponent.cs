using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class MainMenuComponent : MonoBehaviour, IComponent
    {
        public enum SuperPowerName
        {
            Saturn,
            Mars
        }

        public delegate void SelectionButtonChangeDelegate(bool isInteractable);

        public event SelectionButtonChangeDelegate OnLeftSelectionButtonInteractableChange;
        public event SelectionButtonChangeDelegate OnRightSelectionButtonInteractableChange;

        public void Initialize(ComponentContainer componentContainer)
        {
            Debug.Log("<color=lime>" + gameObject.name + " initialized!</color>");
        }
    }
}