## HashSet<T>

Un **HashSet<T>** es una colección que almacena elementos únicos. No permite elementos duplicados. Es útil cuando necesitas almacenar un conjunto único de elementos y realizar operaciones de conjunto como unión, intersección y diferencia de manera eficiente.

**Características**

- **Colección sin orden:** HashSet<T> es una colección no ordenada de elementos únicos donde cada elemento debe ser único.
- **Sin duplicados:** No permite elementos duplicados.
- **Búsqueda rápida:** Proporciona una complejidad promedio de O(1) para operaciones básicas como Add, Remove, Contains.
- **Operaciones de conjunto:** Admite operaciones de conjunto como UnionWith, IntersectWith, ExceptWith, SymmetricExceptWith.
- **Enumerable:** Implementa IEnumerable<T>, lo que permite la iteración a través de sus elementos.
- **Sin indexación:** Los elementos no son accesibles a través de un índice; se debe iterar a través de ellos o usar Contains para verificar un elemento.
- **Sin pares clave-valor:** Almacena elementos individuales, no pares clave-valor.

### Casos de uso de HashSet<>
**Initialization and Adding Elements**
````c#
// Initializing a HashSet of integers
HashSet<int> numbers = new HashSet<int>();
// Adding elements to the HashSet
numbers.Add(3);
numbers.Add(5);
numbers.Add(7);
numbers.Add(3); // Duplicate values are automatically ignored
````
**Checking for Element Existence**
````c#
bool containsSeven = numbers.Contains(7); // Returns true
bool containsTen = numbers.Contains(10); // Returns false
````
**Removing Elements**
````c#
numbers.Remove(5); // Removes 5 from the HashSet
````
**Set Operations**
````c#
HashSet<int> otherNumbers = new HashSet<int> { 3, 9, 11 };

// Union - combining two sets
numbers.UnionWith(otherNumbers); // numbers will contain {3, 7, 9, 11}

// Intersection - elements common to both sets
numbers.IntersectWith(otherNumbers); // numbers will contain {3}

// Difference - elements in the first set but not in the second
numbers.ExceptWith(otherNumbers); // numbers will be empty
````
**Iterating Through Elements**
````c#
foreach (var num in numbers)
{
	Console.WriteLine(num); // Outputs each number in the HashSet
}
````
**Checking Count**
````c#
int count = numbers.Count; // Returns the count of unique elements in the HashSet
````
**Clearing the HashSet**
````c#
numbers.Clear(); // Removes all elements from the HashSet
````
**Use Case: Unique Collection**
````c#
HashSet<string> uniqueNames = new HashSet<string>();

uniqueNames.Add("Foo");
uniqueNames.Add("Bar");
uniqueNames.Add("Foo"); // Ignored as duplicate

foreach (var name in uniqueNames)
{
	Console.WriteLine(name); // Outputs "Foo", "Bar"
}
````
## Dictionary<TKey, TValue>

Un **Dictionary<TKey, TValue>** es una colección de pares clave-valor donde cada clave es única. Permite almacenar datos en forma de pares clave-valor y recuperar rápidamente el valor asociado con una clave dada.

- **Pares clave-valor:** Dictionary<TKey, TValue> es una colección de pares clave-valor.
- **Unicidad de clave:** Cada clave debe ser única dentro de un Dictionary.
- **Búsqueda rápida:** Proporciona una complejidad de búsqueda de O(1) o O(log n) según la implementación subyacente.
- **Acceso basado en clave:** Los elementos se acceden mediante sus claves utilizando el indexador [] o mediante los métodos TryGetValue, ContainsKey.
- **Enumerable**: Implementa IEnumerable<KeyValuePair<TKey, TValue>>, lo que permite la enumeración de pares clave-valor.
- **Modificación de valores:** Los valores pueden modificarse accediendo directamente a ellos a través de sus claves.
- **Sin claves duplicadas:** Si bien los valores pueden ser duplicados, las claves deben ser únicas.

### Casos de uso de Dictionary<k,v>
**Initialization and Adding Key-Value Pairs**
````c#
// Initializing a Dictionary with string keys and int values
Dictionary<string, int> ages = new Dictionary<string, int>();

// Adding key-value pairs to the Dictionary
ages.Add("Alice", 25);
ages.Add("Bob", 30);
ages["Charlie"] = 28; // Alternative way of adding/updating values` 
````
**Accessing and Modifying Values**
````c#
int aliceAge = ages["Alice"]; // Accessing value by key (throws exception if key doesn't exist)
bool exists = ages.TryGetValue("Bob", out int bobAge); // Tries to get value by key, returns true if exists

ages["Alice"] = 26; // Modifying value by key
````
**Checking for Key Existence**
````c#
bool containsCharlie = ages.ContainsKey("Charlie"); // Returns true
bool containsDavid = ages.ContainsKey("David"); // Returns false 
````
**Removing Key-Value Pairs**
````c#
ages.Remove("Bob"); // Removes the key-value pair for "Bob"` 
````
**Iterating Through Key-Value Pairs**
````c#
foreach (var pair in ages)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}"); // Outputs each key-value pair
}
````
**Count of Key-Value Pairs**
````c#
int count = ages.Count; // Returns the count of key-value pairs in the Dictionary 
````
**Clearing the Dictionary**
````c#
ages.Clear(); // Removes all key-value pairs from the Dictionary` 
````
**Use Case: Storing Information**
````c#
Dictionary<string, string> contactInfo = new Dictionary<string, string>();

contactInfo["Alice"] = "alice@example.com";
contactInfo["Bob"] = "bob@example.com";

foreach (var contact in contactInfo)
{
    Console.WriteLine($"{contact.Key}: {contact.Value}"); // Outputs name and contact info
}
````
## Características comunes

- **Tipos genéricos:** Tanto HashSet<T> como Dictionary<TKey, TValue> son tipos genéricos, lo que les permite trabajar con cualquier tipo de datos.
- **Modificación de estructura:** Ambos permiten la modificación de su contenido después de la creación, agregando, eliminando o modificando elementos.
- **Soporte para LINQ:** Ambos admiten consultas LINQ en C#.
- **Eficiencia:** Proporcionan tiempos de búsqueda eficientes para acceder a los elementos.  
## Ejemplos de uso adicionales
````c#
namespace DictionaryHashset  
{  
	internal class Program  
	{  
		static void Main(string[] args)  
		{  
			Dictionary<string, int> diccionarioEdades = new Dictionary<string, int>();

			diccionarioEdades.Add("Alice", 25);  
			diccionarioEdades.Add("Bob", 30);  
			diccionarioEdades.Add("Charlie", 22);

			Console.WriteLine("La edad de Alice es: " + diccionarioEdades["Alice"]);

			string nombre = "Bob";  
			if (diccionarioEdades.ContainsKey(nombre))  
			{  
			Console.WriteLine(nombre + " tiene " + diccionarioEdades[nombre] + " años.");  
			}  
			else  
			{  
			Console.WriteLine(nombre + " no está en el diccionario.");  
			}

			Console.WriteLine("\nIterar a través del diccionario:");  
			foreach (var par in diccionarioEdades)  
			{  
			Console.WriteLine(par.Key + ": " + par.Value + " años");  
			}

			diccionarioEdades["Charlie"] = 23;

			diccionarioEdades.Remove("Alice");

			Console.WriteLine("\nDiccionario después de las modificaciones:");  
			foreach (var par in diccionarioEdades)  
			{  
			Console.WriteLine(par.Key + ": " + par.Value + " años");  
			}

			//Ejemplo de hashSet

			HashSet<string> setNombres = new HashSet<string>();

			setNombres.Add("Alice");  
			setNombres.Add("Bob");  
			setNombres.Add("Charlie");

			bool resultado = setNombres.Add("Alice");  
			Console.WriteLine("¿Se agregó 'Alice' nuevamente al HashSet? " + resultado);

			string nombreHash = "Bob";  
			if (setNombres.Contains(nombreHash))  
			{  
				Console.WriteLine(nombreHash + " está en el HashSet.");  
			}  
			else  
			{  
				Console.WriteLine(nombreHash + " no está en el HashSet.");  
			}

			Console.WriteLine("\nElementos del HashSet:");  
			foreach (var elemento in setNombres)  
			{  
				Console.WriteLine(elemento);  
			}

			setNombres.Remove("Charlie");

			Console.WriteLine("\nHashSet después de la eliminación:");  
			foreach (var elemento in setNombres)  
			{  
				Console.WriteLine(elemento);  
			}  
		}  
	}  
}
````


