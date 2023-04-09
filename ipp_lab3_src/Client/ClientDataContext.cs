using CursorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client;

public class ClientDataContext
{
    public ServerCursor[] Cursors { get; }

    public ClientDataContext() 
    {
        Cursors = new ServerCursor[]{
            ServerCursor.Default,
            ServerCursor.Cross,
            ServerCursor.RedCar,
        };
    }
}
