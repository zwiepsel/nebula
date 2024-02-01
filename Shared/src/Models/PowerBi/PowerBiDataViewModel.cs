using System;

namespace Nebula.Shared.Models.PowerBi
{
    public class PowerBiDataViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string EmbedUri { get; set; } = null!;
    }
}