using AntDesign;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Mockaco.Gui.Web.Components
{
    public partial class HttpMethodBadge
    {
        private IDictionary<string, string> _methodColors = new Dictionary<string, string>
            {
                { "POST",   BadgeColor.Green    },
                { "PUT",    BadgeColor.Volcano  },
                { "DELETE", BadgeColor.Red      },
            };

        private string _method;

        [Parameter]
        public string Method { get => _method; set => _method = value?.ToUpper(); }

        private string BagdeColor => _methodColors.TryGetValue(Method, out var color) ? color : BadgeColor.Blue;
    }
}
