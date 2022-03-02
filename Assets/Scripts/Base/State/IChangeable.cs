namespace Base.State
{
    public interface IChangeable
    {
        void SubscribeToComponentChangeDelegates();
        void UnsubscribeToComponentChangeDelegates();
    }
}