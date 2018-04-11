using System;

namespace ArduinoDriver.SerialProtocol
{
    public class ExtDigitalReadRequest : ArduinoRequest
    {
        public const int MaxDigitalReads = 29;

        public ExtDigitalReadRequest(params byte[] pinsToRead) : base(CommandConstants.ExtDigitalRead)
        {
            // buffer = 64 - command + request length + crc = 4 - number of reads = 1 == 59 / pin = 1 == 59 / 1 == 59 reads
            if (pinsToRead == null)
            {
                throw new ArgumentNullException(nameof(pinsToRead));
            }
            if (pinsToRead.Length < 1 || pinsToRead.Length > MaxDigitalReads)
            {
                throw new ArgumentOutOfRangeException(nameof(pinsToRead), pinsToRead.Length, $"Should be called with array of length 1 to {MaxDigitalReads}");
            }

            Bytes.Add((byte)pinsToRead.Length);
            foreach (var pinToRead in pinsToRead)
            {
                Bytes.Add(pinToRead);
            }
        }
    }
}
