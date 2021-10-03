using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace ThinkAM.ThinkEvent.Currencies
{
    using Dto;

    public interface ICurrencyAppService: IAsyncCrudAppService<CurrencyDto, Guid, PagedResultRequestDto, CreateCurrencyDto, CurrencyDto>
    {
         
    }
}
