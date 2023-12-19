using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pruebasDataTypes {
    internal class Program {
        static void Main(string[] args) {
            RecordExample();
            StructExample();
        }

        public static void StructExample() {


        }

        public struct AreaCuadrado {
            public int Largo { get; }
            public int Ancho { get; }

            public AreaCuadrado(int largo, int ancho) {
                Largo = largo;
                Ancho = ancho;
            }

            public override string ToString() {
                return $"El area del cuadrado es: ${Largo * Ancho}";
            }
        }




        public static void RecordExample() {
            Console.WriteLine("Record Example!");

            Car car1 = new Car("Tesla");
            Console.WriteLine("Auto 1: " + car1);
            car1.Brand = "Ford";
            Console.WriteLine("Persona C 1: " + car1);


            Console.WriteLine("****** Record *******");
            CarRecord car2 = new CarRecord("Ferrari");
            //car2.Brand = "Honda";

            Console.WriteLine("Persona R 1: " + car2);
        }
        public record CarRecord(string Brand);

        public class Car {
            public string Brand { get; set; }
            public Car(string brand) {
                Brand = brand;
            }
            public override string ToString() {
                return $"Auto marca: {Brand}";
            }
        }

    }
}
