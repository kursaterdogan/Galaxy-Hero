using Base.UserInterface;

namespace Game.UserInterfaces.Main
{
    public class InventoryCanvas : BaseCanvas
    {
        public delegate void InventoryRequestDelegate();

        public event InventoryRequestDelegate OnReturnToMainMenuRequest;

        public void RequestReturnToMainMenu()
        {
            //TODO Handle Inventory
            OnReturnToMainMenuRequest?.Invoke();
        }
    }
}