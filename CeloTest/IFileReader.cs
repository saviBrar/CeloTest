using System;
using System.Collections.Generic;

namespace CeloTest
{
    public interface IFileReader<T> where T : IEntity
    {
        List<T> EntityList();
    }
}
