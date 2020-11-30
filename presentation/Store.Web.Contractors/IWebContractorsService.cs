using System;

namespace Store.Web.Contractors
{
    public interface IWebContractorsService
    {
        string UniqueCode { get; }

        string GetUri { get;  }
    }
}
