using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpChatLib;

namespace TcpChatServer.Controllers
{
  public interface IServer : IMainView
  {
    void SetController(ServerController controller);    
  }
}
