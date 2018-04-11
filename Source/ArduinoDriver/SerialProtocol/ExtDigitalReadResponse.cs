using System.Collections.Generic;

namespace ArduinoDriver.SerialProtocol
{
    public class ExtDigitalReadResponse : ArduinoResponse
    {
        public ExtDigitalReadResponse(IList<DigitalInfo> readValues)
        {
            ReadValues = readValues;
        }

        public IList<DigitalInfo> ReadValues { get; }
    }
}
