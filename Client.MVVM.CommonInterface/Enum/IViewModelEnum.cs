using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MVVM.CommonInterface.Enum
{
    /// <summary>
    /// Interfaccia che definisce gli stati della view
    /// </summary>
    public interface IViewModelEnum
    {
        enum StateView { Create, Read, Edit };        
    }
}
