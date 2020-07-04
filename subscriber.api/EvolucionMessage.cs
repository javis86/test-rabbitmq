using System;

namespace subscriber.api
{
    public class EvolucionMessage
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}  - Temperatura: {TemperatureC}"; 
        }
    }
}
