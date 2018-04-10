using System;

namespace ArduinoDriver.SerialProtocol
{
    public class ExtShiftOutRequest : ArduinoRequest
    {
        public const int MaxShiftOuts = 14;

        public ExtShiftOutRequest(params ShiftOutInfo[] shiftOuts) : base(CommandConstants.ExtShiftOut)
        {
            // buffer = 64 - command + request length + crc = 4 - number of writes = 1 == 
            // 59 / datapin = 1 + clock pin = 1 + bit order = 1 + value = 1 == 59 / 4 == 14 writes
            if (shiftOuts == null)
            {
                throw new ArgumentNullException(nameof(shiftOuts));
            }
            if (shiftOuts.Length < 1 || shiftOuts.Length > MaxShiftOuts)
            {
                throw new ArgumentOutOfRangeException(nameof(shiftOuts), shiftOuts.Length, $"Should be called with array of length 1 to {MaxShiftOuts}");
            }

            Bytes.Add((byte)shiftOuts.Length);
            foreach (var shiftOut in shiftOuts)
            {
                Bytes.Add(shiftOut.DataPin);
                Bytes.Add(shiftOut.ClockPin);
                Bytes.Add((byte)shiftOut.BitOrder);
                Bytes.Add(shiftOut.Value);
            }
        }
    }
}
