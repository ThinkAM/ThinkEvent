using System;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;

namespace ThinkAM.ThinkEvent.Currencies
{
    using Dto;

    [AbpAuthorize]
    public class CurrencyAppService: AsyncCrudAppService<Currency, CurrencyDto, Guid, PagedResultRequestDto, CreateCurrencyDto, CurrencyDto>, ICurrencyAppService
    { 
        public CurrencyAppService(IRepository<Currency, Guid> currencyRepository) 
            :base(currencyRepository)
        {
            
        }
    }
}
