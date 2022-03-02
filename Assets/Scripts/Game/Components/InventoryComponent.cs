using Base.Component;
using UnityEngine;

namespace Game.Components
{
    public class InventoryComponent : MonoBehaviour, IComponent
    {
        public void Initialize(ComponentContainer componentContainer)
        {
            //TODO Handle Inventory
            Debug.Log("<color=green>InventoryComponent initialized!</color>");
        }
    }
}