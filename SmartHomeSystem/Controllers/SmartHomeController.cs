using SmartHomeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private List<ISwitchable> switchableDevices = new List<ISwitchable>();
        private List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device) => switchableDevices.Add(device);
        public void AddEnergyDevice(IEnergyConsumer device) => energyDevices.Add(device);

        public void TurnAllOn()
        {
            foreach (var device in switchableDevices)
                device.TurnOn();
        }

        public void TurnAllOff()
        {
            foreach (var device in switchableDevices)
                device.TurnOff();
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"\nЗвіт про споживання енергії за {hours} год:");
            double total = 0;

            foreach (var device in energyDevices)
            {
                double energy = device.GetEnergyUsage(hours);
                total += energy;
                Console.WriteLine($"{device.DeviceName}: {energy:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            }

            Console.WriteLine($"Загальне споживання: {total:F2} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {total * 4:F2} грн\n");
        }
    }
}
