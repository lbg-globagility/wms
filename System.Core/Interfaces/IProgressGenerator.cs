using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem.Core.Interfaces
{
    public interface IProgressGenerator
    {
        int Progress { get; }
        string CurrentMessage { get; }
    }
}
