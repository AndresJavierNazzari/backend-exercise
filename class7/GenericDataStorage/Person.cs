namespace GenericDataStorage
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} years";
        }
    }


}
