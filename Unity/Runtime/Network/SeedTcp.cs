namespace Seed.Unity.Network
{
    using System;
    using System.Net.Sockets;
    using UnityEngine;

    public class SeedTcp
    {
        public TcpClient Socket;

        protected NetworkStream networkStream;

        protected SeedPacket receivedData;

        protected byte[] receiveBuffer;

        public virtual void Connect()
        {
            Socket = new TcpClient
            {
                ReceiveBufferSize = SeedClient.DataBufferSize,
                SendBufferSize = SeedClient.DataBufferSize,
            };

            receiveBuffer = new byte[SeedClient.DataBufferSize];

            // todo: allow override of timeout, handle exceptions
            if (Socket.ConnectAsync(SeedClient.Instance.Ip, SeedClient.Instance.Port).Wait(5000))
            {
                ConnectCallback();
            }
        }

        public virtual void SendData(SeedPacket packet)
        {
            try
            {
                if (Socket != null)
                {
                    networkStream.BeginWrite(packet.ToArray(), 0, packet.Length, null, null);
                }
            }
            catch (Exception)
            {
            }
        }

        public virtual void Disconnect()
        {
            SeedClient.Instance.Disconnect();

            networkStream = null;
            receiveBuffer = null;
            receivedData = null;
            Socket = null;
        }

        protected virtual void ConnectCallback()
        {
            if (Socket.Connected == true)
            {
                networkStream = Socket.GetStream();
                receivedData = new SeedPacket();
                networkStream.BeginRead(receiveBuffer, 0, SeedClient.DataBufferSize, ReceiveCallback, null);
            }
        }

        protected virtual void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                int byteLength = networkStream.EndRead(result);

                if (byteLength > 0)
                {
                    byte[] data = new byte[byteLength];

                    Array.Copy(receiveBuffer, data, byteLength);

                    receivedData.Reset(HandleData(data));
                    networkStream.BeginRead(receiveBuffer, 0, SeedClient.DataBufferSize, ReceiveCallback, null);
                }
                else
                {
                    SeedClient.Instance.Disconnect();
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);

                Disconnect();
            }
        }

        protected virtual bool HandleData(byte[] data)
        {
            bool handled = false;

            int packetLength = 0;

            receivedData.SetBytes(data);

            if (receivedData.UnreadLength >= 4)
            {
                packetLength = receivedData.ReadInt();

                if (packetLength <= 0)
                {
                    handled = true;
                }
            }

            if (handled == false)
            {
                while (packetLength > 0 && packetLength <= receivedData.UnreadLength)
                {
                    byte[] packetBytes = receivedData.ReadBytes(packetLength);

                    NetworkThreadManager.ExecuteOnMainThread(() =>
                    {
                        using (SeedPacket packet = new SeedPacket(packetBytes))
                        {
                            int packetId = packet.ReadInt();
                            SeedClient.PacketHandlers[packetId](packet);
                        }
                    });

                    packetLength = 0;

                    if (receivedData.UnreadLength >= 4)
                    {
                        packetLength = receivedData.ReadInt();

                        if (packetLength <= 0)
                        {
                            handled = true;
                        }
                    }
                }
            }

            if (packetLength <= 1)
            {
                handled = true;
            }

            return handled;
        }
    }
}