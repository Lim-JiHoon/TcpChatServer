using TcpChatLib.Extensions;
using TcpChatLib.Models;
using System.Net.Sockets;
using TcpChatLib.Utils;

namespace TcpChatServer.Controllers
{
  public class ServerController
  {
    private IServer _view;
    private bool _isRunning;
    private CancellationTokenSource? _source;
    private CancellationToken _token;
    private Socket? _listenSocket;
    private ChatInfo _chatInfo;
    private List<Socket> _clients;

    private void Listen(string ip, int port)
    {
      _listenSocket = SocketUtils.Listen(ip, port); // 요청 수신 대기

      try
      {
        while (true)
        {
          Socket client = _listenSocket.Accept(); // 연결 요청 허가. 동기적 대기 ( 멀티 스레드가 필요한 이유 )
          _clients.Add(client); // 연결된 클라이언트들 등록

          //_view.SendText($"{(client.LocalEndPoint as IPEndPoint)!.Address} 클라이언트가 접속했습니다.");

          Task task = Task.Run(() => Receive(client));
        }
      }
      catch (SocketException ex)
      {
        if (ex.ErrorCode == (int)SocketError.Interrupted)
        {
          // client가 연결되어있는데 서버가 종료된 경우
        }
      }
    }

    private void Receive(Socket client)
    {
      while (true)
      {
        if (_token.IsCancellationRequested) return;

        byte[] buffer = new byte[1024];
        int length = client.Receive(buffer, 0, buffer.Length, SocketFlags.None);
        ChatInfo? chatInfo = JsonUtils.DeserializeByBytes(buffer);

        if (!client.IsConnected())
        {
          _clients.Remove(client);
          string outMessage = $"{chatInfo?.NikName}님이 채팅방에서 나갔습니다.!!";
          foreach (var _client in _clients)
          {
            _client.SendMsgWithSerialize(chatInfo!, outMessage);
          }
          _view.DisplayMessage(outMessage);
          
          return;
        }else if (chatInfo?.ComeIn == true)
        {
          _view.DisplayMessage($"{chatInfo?.NikName}님이 채팅방에 입장하였습니다.!!");
        }
        else
        {
          string? message = chatInfo?.Message;
          if (string.IsNullOrWhiteSpace(message)) continue;

          foreach (var _client in _clients)
            _client.Send(buffer);
          _view.DisplayMessage($"{chatInfo?.NikName}: {chatInfo?.Message}");
        }
      }
    }

    public ServerController(IServer view)
    {
      _view = view;
      _view.SetController(this);
      _chatInfo = new ChatInfo();
      _clients = new List<Socket>();
    }

    internal async void Start(string ip, int port)
    {
      _isRunning = !_isRunning;
      if (_isRunning) // 리스너 쓰래드 시작
      {
        _source = new CancellationTokenSource();
        _token = _source.Token;
        Task task = Task.Run(() => Listen(ip, port));
        await task;
      }
      else // 쓰래드 종료
      {
        Dispose();
      }
    }

    internal void Dispose()
    {
      _token.ThrowIfCancellationRequested();
      _source?.Dispose();
      _listenSocket?.Close();
      _listenSocket?.Dispose();
    }
    public void SetNickName(string nickName)
    {
      _chatInfo.NikName = nickName;
    }
    public void Send(string message)
    {
      if (_listenSocket == null || !_listenSocket.IsConnected())
      {
        MessageBox.Show("서버가 실행되지 않았습니다.!!");
        return;
      }
      foreach (Socket client in _clients)
      {
        client.SendMsgWithSerialize(_chatInfo, message);
      }
      _view.DisplayMessage(message);
    }
  }
}
