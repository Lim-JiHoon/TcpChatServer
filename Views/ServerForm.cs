using TcpChatLib.Models;
using TcpChatServer.Controllers;

namespace TcpChatServer
{
  public partial class ServerForm : Form, IServer
  {
    private ServerController _cont = null!;

    private void button1_Click(object sender, EventArgs e)
    {
      _cont.SetNickName("±Í¿ä¹Ì(¼­¹ö)");
      _cont.Start("127.0.0.1", 8080);
    }

    private void SendMessage()
    {
      _cont.Send(txtMessage.Text.Trim());
    }

    private void btnSendMessage_Click(object sender, EventArgs e)
    {
      SendMessage();
    }

    private void txtMessage_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter) SendMessage();
    }

    public ServerForm()
    {
      InitializeComponent();
      FormClosed += (s, e) => _cont.Dispose();
    }

    public void SetController(ServerController controller)
    {
      _cont = controller;
    }
     
    public void DisplayMessage(string message)
    {
      this.Invoke(() =>
      {
        txtChat.AppendText($"{message}\n");
        txtMessage.Clear();
      });
    }
  }
}