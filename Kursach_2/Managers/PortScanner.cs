using System.Net.Sockets;

namespace Kursach_2.Managers
{
    internal class PortScanner
    {
        public List<Port> ports { get; set; }
        private string host;
        private PortList portList;

        List<Port> list = new List<Port>();

        public PortScanner(string host, int portStart, int portStop)
        {
            this.host = host;
            this.portList = new PortList(portStart, portStop);
        }

        public List<Port> start(int threadCounter)
        {
            for (int i = 0; i < threadCounter; i++)
            {
                Thread thread1 = new Thread(new ThreadStart(RunScanTcp));
                thread1.Start();
            }
            return list;
        }

        public void RunScanTcp()
        {
            int port;
            TcpClient tcp = new TcpClient();

            while ((port = portList.NextPorts()) != -1)
            {

                try
                {
                    tcp = new TcpClient(host, port);
                }
                catch
                {
                    //if error just continue
                    continue;
                }
                finally
                {
                    try
                    {
                        tcp.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    list.Add(new Port()
                    {
                        TCP_Port = port,
                        is_Open = true
                    });
                }
            }
        }
    }
}
