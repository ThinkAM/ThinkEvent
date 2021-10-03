using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ThinkAM.ThinkEvent.Currencies
{
    [Table("AppCurrencies")]
    public class Currency: FullAuditedEntity<Guid>
    {
        public const int MaxCodeLength = 3;
        public const int MaxNameLength = 50;
        public const int MaxNamePluralLength = 50;
        public const int MaxSymbolLength = 10;
        public const int MaxSymbolNativeLength = 10;

        [Required]
        [StringLength(MaxCodeLength)]
        public string Code { get; set; }        

        public int DecimalDigits { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxNamePluralLength)]
        public string NamePlural { get; set; }

        public int Rounding { get; set; }

        [Required]
        [StringLength(MaxSymbolLength)]
        public string Symbol { get; set; }

        [Required]
        [StringLength(MaxSymbolNativeLength)]
        public string SymbolNative { get; set; }
    }
}
