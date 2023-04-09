using CursorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Server.Converters;

public static class CursorGenerator
{
    private const string ResourcesPath = "C:\\универ\\ипп\\Ipp_lab3\\ipp_lab3_src\\Server\\Resources\\";
    
    private readonly static Dictionary<ServerCursor, string> CursorNames = new Dictionary<ServerCursor, string>
    {
        { ServerCursor.Default, "DefaultCursor.cur" },
        { ServerCursor.Cross, "CrossCurSor.cur" },
        { ServerCursor.RedCar, "RedCarCurSor.ani" },
    };

    public static Cursor GetCursor(ServerCursor cursor)
    {
        return new Cursor(ResourcesPath + CursorNames[cursor]);
    }
}
