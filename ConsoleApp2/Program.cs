using System;
using System.Xml.Serialization;
using System.IO;

// Шерстнев Алексей ИУ6-74
// B1 и 1
namespace HW
{
    public enum VagonTypeEnum
    {
        Passenger,
        Commodity
    }

    public enum LocomotiveTypeEnum
    {
        Thermal,
        Electric
    }

    [Serializable]
    public class Vagon
    {
        public string Model { get; set; }
        public int SerialNumber { get; set; }
        public VagonTypeEnum VagonType { get; set; }
        public int CapacityPassengers { get; set; }
        public int CapacityCarrying { get; set; }

        public Vagon() { }

        public Vagon(string model, int serialNumber, VagonTypeEnum vagonType, int capacityPassengers, int capacityCarrying)
        {
            Model = model;
            SerialNumber = serialNumber;
            VagonType = vagonType;
            CapacityPassengers = capacityPassengers;
            CapacityCarrying = capacityCarrying;
        }
    }

    [Serializable]
    public class Locomotive
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public LocomotiveTypeEnum LocomotiveType { get; set; }

        public Locomotive() { }

        public Locomotive(string name, int serialNumber, LocomotiveTypeEnum locomotiveType)
        {
            Name = name;
            SerialNumber = serialNumber;
            LocomotiveType = locomotiveType;
        }
    }

    [Serializable]
    public class Structure
    {
        public int Numm { get; set; }
        public Vagon[] Vagons { get; set; }
        public Locomotive Loco { get; set; }

        public Structure() { }


        public Structure(int numm, Vagon[] vagons, Locomotive loco)
        {
            Numm = numm;
            Vagons = vagons;
            Loco = loco;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vagon1 = new Vagon("USSR", 789, VagonTypeEnum.Passenger, 60, 1000);
            var vagon2 = new Vagon("UK", 788, VagonTypeEnum.Commodity, 61, 1001);
            Vagon[] vagons = new Vagon[] { vagon1, vagon2 };
            var loco = new Locomotive("Burya", 123, LocomotiveTypeEnum.Thermal);
            var structure = new Structure(555, vagons, loco);

            XmlSerializer formatter = new XmlSerializer(typeof(Structure));

            using (FileStream fs = new FileStream("scructure.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, structure);
            }
        }
    }
}