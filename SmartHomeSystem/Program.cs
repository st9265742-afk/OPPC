using SmartHomeSystem;

namespace SmartHomeSystem
{
    class Program
    {
        static void Main()
        {
            SmartHomeController controller = new SmartHomeController();

            Light light = new Light { Name = "Лампа у вітальні" };
            AirConditioner ac = new AirConditioner { Name = "Кондиціонер у спальні" };
            CoffeeMachine coffee = new CoffeeMachine { Name = "Кавомашина на кухні" };
            MotionSensor sensor = new MotionSensor { Name = "Датчик руху у коридорі" };

            controller.AddDevice(light);
            controller.AddDevice(ac);
            controller.AddDevice(coffee);
            controller.AddDevice(sensor);

            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(ac);
            controller.AddEnergyDevice(coffee);

            controller.TurnAllOn();

            light.PrintStatus();
            ac.PrintStatus();
            coffee.PrintStatus();
            sensor.PrintStatus();

            controller.ShowEnergyReport(5);

            controller.TurnAllOff();
        }
    }
}
