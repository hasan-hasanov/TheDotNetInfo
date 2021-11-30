using Fluxor;
using TheDotNetInfo.Store.Dom.Actions;

namespace TheDotNetInfo.Store.Dom.Reducers
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
