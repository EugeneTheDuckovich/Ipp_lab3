using Server.Converters;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Input;
using CursorLibrary;

namespace Server.ViewModels;

public class ServerViewModel : NotifyPropertyChanged
{
    private Cursor _cursor;
    public Cursor Cursor
    {
        get { return _cursor; }
        set
        {
            _cursor = value;
            OnPropertyChanged(nameof(Cursor));
        }
    }

    private TcpListener _listener;

    public ServerViewModel() 
    {
        Cursor = CursorGenerator.GetCursor(ServerCursor.Default);
        _listener = new TcpListener(IPAddress.Loopback,8888);
        _listener.Start();
        Task.Run(async () => await ProcessClient());    
    }

    public async Task ProcessClient()
    {
        var client = await _listener.AcceptTcpClientAsync();
        var stream = client.GetStream();

        while(true)
        {
            var sizeBytes = new byte[4];
            await stream.ReadAsync(sizeBytes);
            ServerCursor cursor = (ServerCursor)BitConverter.ToUInt32(sizeBytes);

            Cursor = CursorGenerator.GetCursor(cursor);
        }
    }
}
