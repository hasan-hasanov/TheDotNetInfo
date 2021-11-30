namespace TheDotNetInfo.Store.Dom.Actions
{
    public record SetLoadingAction
    {
        public SetLoadingAction(bool isLoading)
        {
            IsLoading = isLoading;
        }

        public bool IsLoading { get; }
    }
}
