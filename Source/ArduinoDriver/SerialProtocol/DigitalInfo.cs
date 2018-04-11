namespace ArduinoDriver.SerialProtocol
{
    public struct DigitalInfo
    {
        public DigitalInfo(byte pin, DigitalValue pinValue)
        {
            Pin = pin;
            PinValue = pinValue;
        }

        public byte Pin { get; }

        public DigitalValue PinValue { get; }
    }
}
