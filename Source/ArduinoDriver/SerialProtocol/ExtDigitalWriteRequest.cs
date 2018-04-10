using System;

namespace ArduinoDriver.SerialProtocol
{
    public class ExtDigitalWriteRequest : ArduinoRequest
    {
        public const int MaxDigitalWrites = 29;

        public ExtDigitalWriteRequest(params DigitalWriteInfo[] digitalWrites) : base(CommandConstants.ExtDigitalWrite)
        {
            // buffer = 64 - command + request length + crc = 4 - number of writes = 1 == 59 / pin = 1 + value = 1 == 59 / 2 == 29 writes
            if (digitalWrites == null)
            {
                throw new ArgumentNullException(nameof(digitalWrites));
            }
            if (digitalWrites.Length < 1 || digitalWrites.Length > MaxDigitalWrites)
            {
                throw new ArgumentOutOfRangeException(nameof(digitalWrites), digitalWrites.Length, $"Should be called with array of length 1 to {MaxDigitalWrites}");
            }

            Bytes.Add((byte)digitalWrites.Length);
            foreach (var digitalWrite in digitalWrites)
            {
                Bytes.Add(digitalWrite.PinToWrite);
                Bytes.Add((byte)digitalWrite.PinValue);
            }
        }
    }
}
