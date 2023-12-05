namespace wakuwakuApi.Entities {
    public class Category {

        private static int lastId = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(string name, string description) {
            this.Id = ++lastId;
            this.Name = name;
            this.Description = description;
        }

        // Método estático para obtener el siguiente ID disponible
        public static int GetNextId() {
            return lastId + 1;
        }

    }
}
