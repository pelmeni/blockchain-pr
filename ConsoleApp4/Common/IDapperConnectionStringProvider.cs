using System;

namespace Common
{
    public interface IDapperConnectionStringProvider
    {
        string ConnectionString { get; }
    }

}
