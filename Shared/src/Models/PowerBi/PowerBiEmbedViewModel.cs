using System.Collections.Generic;

namespace Nebula.Shared.Models.PowerBi
{
    public class PowerBiEmbedViewModel
    {
        public string Type { get; set; } = null!;
        public List<PowerBiDataViewModel> Data { get; set; } = null!;
        public PowerBiEmbedTokenViewModel EmbedToken { get; set; } = null!;
    }
}