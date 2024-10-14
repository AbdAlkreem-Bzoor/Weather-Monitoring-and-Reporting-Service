using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Monitoring_and_Reporting_Service;
using Weather_Monitoring_and_Reporting_Service.Temperature_Units;

namespace WMARS.Tests
{
    public class TemperatureUnitsDecoratorShould
    {
        [Fact]
        public void CelsiusShouldLeadToCelsius()
        {
            ITemperatureUnit unit = new CelsiusTemperatureUnit() { Temperature = 20 };
            unit = new CelsiusFactory().Create(new FahrenheitFactory().Create(new CelsiusFactory().Create(unit)));

            Assert.Equal(20, unit.Temperature);
        }
    }
}
