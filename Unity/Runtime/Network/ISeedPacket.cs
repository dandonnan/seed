namespace Seed.Unity.Network
{
    public interface ISeedPacket
    {
        void SetBytes(byte[] data);

        void WriteBufferLengthToStartOfBuffer();

        void InsertIntegerAtStartOfBuffer(int value);

        byte[] ToArray();

        void Reset(bool forceReset = true);

        void Write(byte value);

        void Write(byte[] value);

        void Write(short value);

        void Write(int value);

        void Write(long value);

        void Write(float value);

        void Write(bool value);

        void Write(string value);

        byte ReadByte(bool moveReadPosition = true);

        byte[] ReadBytes(int length, bool moveReadPosition = true);

        short ReadShort(bool moveReadPosition = true);

        int ReadInt(bool moveReadPosition = true);

        long ReadLong(bool moveReadPosition = true);

        float ReadFloat(bool moveReadPosition = true);

        bool ReadBool(bool moveReadPosition = true);

        string ReadString(bool moveReadPosition = true);

        void Dispose();
    }
}
