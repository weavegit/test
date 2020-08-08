using System;
using System.Collections.Generic;
using System.Text;

namespace SWIMSDataAccessLayer.query
{
    public interface ISearchable
    {
        IEnumerable<dto.ResultsDTO> List(string searchValue);
    }
}
