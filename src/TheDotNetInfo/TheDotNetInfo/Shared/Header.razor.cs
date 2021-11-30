using Fluxor;
using Microsoft.AspNetCore.Components;
using TheDotNetInfo.Store.Dom;

namespace TheDotNetInfo.Shared
{
    public partial class Header
    {
        [Inject] public IState<DomState> DomState { get; set; }
    }
}
