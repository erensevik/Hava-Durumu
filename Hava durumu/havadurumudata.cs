using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAVADURUMU0
{
    public class WeatherData
    {
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public ForecastData[] Forecast { get; set; }
    }




}