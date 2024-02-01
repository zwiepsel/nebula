using System;

namespace Nebula.Shared.Models.PowerBi
{
    public class PowerBiEmbedTokenViewModel
    {
        public string Token { get; set; } = null!;
        public Guid TokenId { get; set; }
        public DateTime Expiration { get; set; }
    }
}