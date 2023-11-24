namespace Calculator;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter value number 1: ");
            string? input1 = Console.ReadLine();

            while(string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("Value cannot be null or empty. Please try again.");
                Console.Write("Enter value number 1: ");
                input1 = Console.ReadLine();
            }

            Console.Write("Enter value number 2: ");
            string? input2 = Console.ReadLine();

            while(string.IsNullOrEmpty(input2))
            {
                Console.WriteLine("Value cannot be null or empty. Please try again.");
                Console.Write("Enter value number 2: ");
                input2 = Console.ReadLine();
            }

            Console.WriteLine($"Result: {AddOperation(input1, input2)}");
        } catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static dynamic AddOperation(string value1, string value2)
    {
        Type type1 = GetType(value1);
        Type type2 = GetType(value2);

        if((IsNumber(type1) && IsNumber(type2)))
        {
            dynamic v1 = Convert.ChangeType(value1, type1);
            dynamic v2 = Convert.ChangeType(value2, type2);
            return v1 + v2;

        } else if((type1 == typeof(string) && type2 == typeof(string)))
        {
            return value1.ToString() + value2.ToString();
        }

        throw new InvalidOperationException("Data types are diferent for the two values.");
    }

    private static bool IsNumber(Type type)
    {
        return type == typeof(double) || type == typeof(int);
    }

    private static Type GetType(object value)
    {
        if(int.TryParse(value.ToString(), out int _))
        {
            return typeof(int);
        } else if(double.TryParse(value.ToString(), out double _))
        {
            return typeof(double);
        } else
        {
            return typeof(string);
        }
    }
}
