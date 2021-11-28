using Fluxor;
using Microsoft.AspNetCore.Components;
using TheDotNet.Store.Dom;

namespace TheDotNet.Shared
{
    public partial class Header
    {
        [Inject] public IState<DomState> DomState { get; set; }
    }
}
