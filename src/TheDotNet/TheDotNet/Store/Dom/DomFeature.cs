using Fluxor;

namespace TheDotNet.Store.Dom
{
    public class DomFeature : Feature<DomState>
    {
        public override string GetName() => nameof(DomState);

        protected override DomState GetInitialState()
        {
            return new DomState()
            {
                IsLoading = false,
                ErrorMessage = string.Empty,
            };
        }
    }
}
