namespace ArduinoDriver.SerialProtocol
{
    public struct ShiftOutInfo
    {
        public ShiftOutInfo(byte dataPin, byte clockPin, BitOrder bitOrder, byte value)
        {
            DataPin = dataPin;
            ClockPin = clockPin;
            BitOrder = bitOrder;
            Value = value;
        }

        public byte DataPin { get; }
        public byte ClockPin { get; }
        public BitOrder BitOrder { get; }
        public byte Value { get; }
    }
}
