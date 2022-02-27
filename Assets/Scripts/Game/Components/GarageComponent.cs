using UnityEngine;
using Base.Component;

namespace Game.Components
{
    public class GarageComponent : MonoBehaviour, IComponent, IStartable, IExitable
    {
        private UIComponent _uiComponent;

        public void Initialize(ComponentContainer componentContainer)
        {
            //TODO GarageState
            //TODO WalletComponent
            //TODO AccountComponent
            //TODO GarageCanvas
            //TODO Add UIComponent, GarageCanvas

            _uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
        }

        public void CallStart()
        {
            throw new System.NotImplementedException();
        }

        public void CallExit()
        {
            throw new System.NotImplementedException();
        }
    }
}