using Fluxor;
using TheDotNet.Store.Dom.Actions;

namespace TheDotNet.Store.Dom.Reducers
{
    public class OnSetLoadingReducer : Reducer<DomState, SetLoadingAction>
    {
        public override DomState Reduce(DomState state, SetLoadingAction action)
        {
            return new DomState
            {
                IsLoading = action.IsLoading,
                ErrorMessage = state.ErrorMessage,
            };
        }
    }
}
