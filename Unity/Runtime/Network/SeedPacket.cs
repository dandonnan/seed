namespace Seed.Unity.Network
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SeedPacket : IDisposable, ISeedPacket
    {
        public int Length => buffer.Count;

        public int UnreadLength => buffer.Count - readPosition;

        private const int ByteLength = 1;
        private const int ShortLength = 2;
        private const int IntegerLength = 4;
        private const int LongLength = 8;

        private List<byte> buffer;
        private byte[] readableBuffer;
        private int readPosition;

        private bool disposed = false;

        public SeedPacket()
        {
            buffer = new List<byte>();
            readPosition = 0;
        }

        public SeedPacket(int id)
            : this()
        {
            Write(id);
        }

        public SeedPacket(byte[] data)
            : this()
        {
            SetBytes(data);
        }

        public void SetBytes(byte[] data)
        {
            Write(data);
            readableBuffer = buffer.ToArray();
        }

        public void WriteBufferLengthToStartOfBuffer()
        {
            buffer.InsertRange(0, BitConverter.GetBytes(buffer.Count));
        }

        public void InsertIntegerAtStartOfBuffer(int value)
        {
            buffer.InsertRange(0, BitConverter.GetBytes(value));
        }

        public byte[] ToArray()
        {
            return buffer.ToArray();
        }

        public void Reset(bool forceReset = true)
        {
            if (forceReset == true)
            {
                buffer.Clear();
                readableBuffer = null;
                readPosition = 0;
            }
            else
            {
                readPosition -= 4;
            }
        }

        public void Write(byte value)
        {
            buffer.Add(value);
        }

        public void Write(byte[] value)
        {
            buffer.AddRange(value);
        }

        public void Write(short value)
        {
            buffer.AddRange(BitConverter.GetBytes(value));
        }

        public void Write(int value)
        {
            buffer.AddRange(BitConverter.GetBytes(value));
        }

        public void Write(long value)
        {
            buffer.AddRange(BitConverter.GetBytes(value));
        }

        public void Write(float value)
        {
            buffer.AddRange(BitConverter.GetBytes(value));
        }

        public void Write(bool value)
        {
            buffer.AddRange(BitConverter.GetBytes(value));
        }

        public void Write(string value)
        {
            Write(value.Length);
            buffer.AddRange(Encoding.ASCII.GetBytes(value));
        }

        public byte ReadByte(bool moveReadPosition = true)
        {
            return Read<byte>("byte", () =>
            {
                byte value = readableBuffer[readPosition];

                if (moveReadPosition == true)
                {
                    MoveReadPosition(ByteLength);
                }

                return value;
            });
        }

        public byte[] ReadBytes(int length, bool moveReadPosition = true)
        {
            return Read<byte[]>("bytes", () =>
            {
                byte[] value = buffer.GetRange(readPosition, length).ToArray();

                if (moveReadPosition == true)
                {
                    MoveReadPosition(length);
                }

                return value;
            });
        }

        public short ReadShort(bool moveReadPosition = true)
        {
            return Read<short>("short", () =>
            {
                short value = BitConverter.ToInt16(readableBuffer, readPosition);

                if (moveReadPosition == true)
                {
                    MoveReadPosition(ShortLength);
                }

                return value;
            });
        }

        public int ReadInt(bool moveReadPosition = true)
        {
            return Read<int>("int", () =>
            {
                int value = BitConverter.ToInt32(readableBuffer, readPosition);

                if (moveReadPosition == true)
                {
                    MoveReadPosition(IntegerLength);
                }

                return value;
            });
        }

        public long ReadLong(bool moveReadPosition = true)
        {
            return Read<long>("long", () =>
            {
                long value = BitConverter.ToInt64(readableBuffer, readPosition);

                if (moveReadPosition == true)
                {
                    MoveReadPosition(LongLength);
                }

                return value;
            });
        }

        public float ReadFloat(bool moveReadPosition = true)
        {
            return Read<float>("float", () =>
            {
                float value = BitConverter.ToSingle(readableBuffer, readPosition);

                if (moveReadPosition == true)
                {
                    MoveReadPosition(IntegerLength);
                }

                return value;
            });
        }

        public bool ReadBool(bool moveReadPosition = true)
        {
            return Read<bool>("bool", () =>
            {
                bool value = BitConverter.ToBoolean(readableBuffer, readPosition);

                if (moveReadPosition == true)
                {
                    MoveReadPosition(ByteLength);
                }

                return value;
            });
        }

        public string ReadString(bool moveReadPosition = true)
        {
            return Read<string>("string", () =>
            {
                int length = ReadInt();
                string value = Encoding.ASCII.GetString(readableBuffer, readPosition, length);

                if (moveReadPosition == true && value.Length > 0)
                {
                    MoveReadPosition(length);
                }

                return value;
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    buffer = null;
                    readableBuffer = null;
                    readPosition = 0;
                }

                disposed = true;
            }
        }

        private T Read<T>(string typeOfT, Func<T> action)
        {
            if (buffer.Count > readPosition)
            {
                return action();
            }
            else
            {
                throw new IndexOutOfRangeException($"Unable to read {typeOfT} from buffer, as the read position is greater than the buffer count.");
            }
        }

        private void MoveReadPosition(int amount)
        {
            readPosition += amount;
        }
    }
}