using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeNoteBlazor.Client.Services
{
    interface IMasterDetailService
    {
        event Action<Object> OnView;
        event Action<Object> OnCreate;
        event Action<Object> OnEdit;
    }
}
