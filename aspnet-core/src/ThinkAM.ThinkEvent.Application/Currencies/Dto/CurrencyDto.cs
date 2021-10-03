using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ThinkAM.ThinkEvent.Currencies.Dto
{
    [AutoMap(typeof(Currency))]
    public class CurrencyDto: FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(Currency.MaxCodeLength)]
        public string Code { get; set; }        

        public int DecimalDigits { get; set; }

        [Required]
        [StringLength(Currency.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(Currency.MaxNamePluralLength)]
        public string NamePlural { get; set; }

        public int Rounding { get; set; }

        [Required]
        [StringLength(Currency.MaxSymbolLength)]
        public string Symbol { get; set; }

        [Required]
        [StringLength(Currency.MaxSymbolNativeLength)]
        public string SymbolNative { get; set; }
    }
}
