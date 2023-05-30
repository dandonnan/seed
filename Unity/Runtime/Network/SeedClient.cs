namespace Seed.Unity.Network
{
    using System.Collections.Generic;

    public class SeedClient
    {
        public static SeedClient Instance;

        public static int DataBufferSize => 4096;

        public string Ip => ip;

        public int Port => port;

        public int Id;

        public int LobbyId;

        public int LobbyIndex;

        public SeedTcp Tcp;

        public SeedUdp Udp;

        public static Dictionary<int, PacketHandler> PacketHandlers;

        public delegate void PacketHandler(SeedPacket packet);

        public event ConnectionChange ConnectionChanged;

        public delegate void ConnectionChange(bool connected);

        protected string ip;

        protected int port;

        public SeedClient(string ipAddress, int port)
        {
            if (Instance == null)
            {
                Instance = this;
            }

            ip = ipAddress;

            this.port = port;
        }

        public virtual void ConnectToServer()
        {
            Tcp = new SeedTcp();
            Udp = new SeedUdp();

            InitialiseClientData();

            Tcp.Connect();
        }

        public virtual void Disconnect()
        {
            Tcp.Socket?.Close();
            Udp.Socket?.Close();

            ConnectionChanged?.Invoke(false);
        }

        public void Connected()
        {
            ConnectionChanged?.Invoke(true);
        }

        protected virtual void InitialiseClientData()
        {
            // todo: make user setup dictionary of packethandlers
        }
    }
}