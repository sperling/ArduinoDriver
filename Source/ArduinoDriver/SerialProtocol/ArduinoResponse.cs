using System.Collections.Generic;
using System.IO;

namespace ArduinoDriver.SerialProtocol
{
    public abstract class ArduinoResponse : ArduinoMessage
    {
        public static ArduinoResponse Create(byte[] bytes)
        {
            var commandByte = bytes[0];
            switch (commandByte)
            {
                case CommandConstants.HandshakeAck:
                {
                    return new HandShakeResponse(bytes[1], bytes[2]);
                }
                case CommandConstants.DigitalReadAck:
                {
                    return new DigitalReadResponse(bytes[1], (DigitalValue) bytes[2]);
                }
                case CommandConstants.DigitalWriteAck:
                {
                    return new DigitalWriteReponse(bytes[1], (DigitalValue) bytes[2]);
                }
                case CommandConstants.PinModeAck:
                {
                    return new PinModeResponse(bytes[1], (PinMode) bytes[2]);
                }
                case CommandConstants.AnalogReadAck:
                {
                    return new AnalogReadResponse(bytes[1], bytes[2], bytes[3]);
                }
                case CommandConstants.AnalogWriteAck:
                {
                    return new AnalogWriteResponse(bytes[1], bytes[2]);
                }
                case CommandConstants.Error:
                {
                    return new ErrorResponse(bytes[1], bytes[2], bytes[3]);
                }
                case CommandConstants.ToneAck:
                {
                    return new ToneResponse();
                }
                case CommandConstants.NoToneAck:
                {
                    return new NoToneResponse();
                }
                case CommandConstants.AnalogReferenceAck:
                {
                    return new AnalogReferenceResponse((AnalogReferenceType) bytes[1]);
                }
                case CommandConstants.ShiftOutAck:
                {
                    return new ShiftOutResponse(bytes[1], bytes[2], (BitOrder)bytes[3], bytes[4]);
                }
                case CommandConstants.ShiftInAck:
                {
                    return new ShiftInResponse(bytes[1], bytes[2], (BitOrder)bytes[3], bytes[4]);
                }
                case CommandConstants.ExtDigitalWriteAck:
                {
                    return new ExtDigitalWriteReponse();
                }
                case CommandConstants.ExtShiftOutAck:
                {
                    return new ExtShiftOutResponse();
                }
                case CommandConstants.ExtDigitalReadAck:
                {
                    var readValues = new List<DigitalInfo>(bytes[1]);
                    for (int i = 0; i < bytes[1]; i++)
                    {
                        readValues.Add(new DigitalInfo(bytes[2 + i * 2], bytes[2 + i * 2 + 1] == 0 ? DigitalValue.Low : DigitalValue.High));
                    }
                    return new ExtDigitalReadResponse(readValues);
                }
                default:
                {
                    throw new IOException(string.Format("Unexpected command byte in response: {0}!", commandByte));
                }
            }
        }
    }
}
