namespace Base.State
{
    public interface IRequestable
    {
        void SubscribeToCanvasRequestDelegates();
        void UnsubscribeToCanvasRequestDelegates();
    }
}