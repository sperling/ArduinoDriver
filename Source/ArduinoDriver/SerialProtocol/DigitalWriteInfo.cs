namespace ArduinoDriver.SerialProtocol
{
    public struct DigitalWriteInfo
    {
        public DigitalWriteInfo(byte pinToWrite, DigitalValue pinValue)
        {
            PinToWrite = pinToWrite;
            PinValue = pinValue;
        }

        public byte PinToWrite { get; }

        public DigitalValue PinValue { get; }
    }
}
