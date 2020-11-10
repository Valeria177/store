using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IDetailRepository
    {
        Detail[] GetAllByTitle(string titlePart);
    }
}
