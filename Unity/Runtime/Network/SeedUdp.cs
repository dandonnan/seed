namespace Seed.Unity.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;

    public class SeedUdp
    {
        public UdpClient Socket;

        public IPEndPoint EndPoint;

        public SeedUdp()
        {
            EndPoint = new IPEndPoint(IPAddress.Parse(SeedClient.Instance.Ip), SeedClient.Instance.Port);
        }

        public virtual void Connect(int localPort)
        {
            Socket = new UdpClient(localPort);

            Socket.Connect(EndPoint);
            Socket.BeginReceive(ReceiveCallback, null);

            using (SeedPacket packet = new SeedPacket())
            {
                SendData(packet);
            }

            SeedClient.Instance.Connected();
        }

        public virtual void SendData(SeedPacket packet)
        {
            try
            {
                packet.InsertIntegerAtStartOfBuffer(SeedClient.Instance.Id);

                if (Socket != null)
                {
                    Socket.BeginSend(packet.ToArray(), packet.Length, null, null);
                }
            }
            catch (Exception)
            {
            }
        }

        protected virtual void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                byte[] data = Socket.EndReceive(result, ref EndPoint);
                Socket.BeginReceive(ReceiveCallback, null);

                if (data.Length >= 4)
                {
                    HandleData(data);
                }
                else
                {
                    SeedClient.Instance.Disconnect();
                }
            }
            catch
            {
                Disconnect();
            }
        }

        protected virtual void HandleData(byte[] data)
        {
            using (SeedPacket packet = new SeedPacket(data))
            {
                int packetLength = packet.ReadInt();
                data = packet.ReadBytes(packetLength);
            }

            NetworkThreadManager.ExecuteOnMainThread(() =>
            {
                using (SeedPacket packet = new SeedPacket(data))
                {
                    int packetId = packet.ReadInt();
                    SeedClient.PacketHandlers[packetId](packet);
                }
            });
        }

        protected virtual void Disconnect()
        {
            SeedClient.Instance.Disconnect();

            EndPoint = null;
            Socket = null;
        }
    }
}