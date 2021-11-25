namespace TheDotNet.Store.Dom
{
    public record DomState
    {
        public DomState()
        {
            IsLoading = false;
            ErrorMessage = string.Empty;
        }

        public bool IsLoading { get; set; }

        public string ErrorMessage { get; set; }
    }
}
