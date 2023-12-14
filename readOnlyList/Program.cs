using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.X86;

namespace readOnlyList {
    internal class Program {
        static void Main(string[] args) {

            // En C#, una ReadOnlyList es una interfaz que proporciona acceso de solo lectura a una lista de elementos. 
            // Esta interfaz se introdujo en C# 9.0 como parte de las iniciativas para mejorar el soporte de programación inmutable. 

            // La idea detrás de ReadOnlyList es proporcionar una forma de exponer listas que no se pueden modificar, 
            // lo que puede ser útil en situaciones donde se desea garantizar que los datos no cambien después de su creación

            // Es importante destacar que, aunque IReadOnlyList impide la modificación directa de la lista, no garantiza que los elementos de
            // la lista no puedan cambiar si son objetos mutables. En otras palabras, si la lista contiene referencias a objetos, los objetos
            // en sí mismos aún pueden ser modificados si son mutables.

            // En resumen, ReadOnlyList es una interfaz en C# que proporciona acceso de solo lectura a una lista, ayudando a
            // garantizar la inmutabilidad de la lista en sí misma, aunque no necesariamente de sus elementos si son objetos mutables.

            // En el ejemplo anterior, readOnlyList se crea a partir de la lista mutable listaMutable.Aunque ambas listas comparten los mismos 
            // elementos, cualquier intento de modificar la lista de solo lectura generará un error de compilación, ya
            // que IReadOnlyList solo proporciona operaciones de lectura.

            List<string> users = new List<string>(3);
            Console.WriteLine("List<string> users = new List<string>(3);");
            Console.WriteLine("Capacity: {0}", users.Capacity);

            users.Add("Username 1");
            users.Add("Username 2");
            users.Add("username 3");
            //Normal modifiable list
            foreach(string i in users) {
                Console.WriteLine(i);
            }
            Console.WriteLine("IList<String> readonlyList = users.AsReadOnly();");

            IList<string> readOnlyList = users.AsReadOnly();

            IReadOnlyList<string> readOnlyList2 = users;


            //ReadOnly list, not modifiable
            foreach(string i in readOnlyList) {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nusers[2] = \"New Username\"");
            users[2] = "New Username";

            Console.WriteLine("\nElements in the read-only IList:");
            foreach(string readOnlyUser in readOnlyList) {
                Console.WriteLine(readOnlyUser);
            }
            //readOnlyList.Insert(0, 1);// Unhandled Exception 
            //The ReadOnly List still reflects changes made to the original List
            //To Prevent from adding items to the list anywhere only expose the ReadOnlyList
            //to the rest of the project
        }

        //Endpoint implementation example
        public record User(string name);

        public IReadOnlyList<User> GetUsers() {
            //Validation
            var isValid = false;
            if(isValid) {
                //Read Only list in .net8 allows saving memory using the same cached empty instant
                //Safer option to returning a null or new List<>, avoid use of null pointer(Null reference exceptions risk)
                //Benefit of readOnly, it cannot be modified after exiting this method
                return ReadOnlyCollection<User>.Empty;
                //.AsReadOnly() returns a ReadOnlyCollection<T> type
                //*-View ReadOnlyCollection<> definition
                //Implements Ilist<>, IList, IReadOnlyList<T>
                //Allows methods like count, get object by [index], Contains(), CopyTo(), indexOf()
                //It does NOT Allow methos like Add(), Clear(), Insert(), Remove()
            }
            //Call to DB
            return null;
        }
    }
}
