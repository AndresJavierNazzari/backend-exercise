﻿using wakuwakuApi.Models;

namespace wakuwakuApi.Models {
    public class Skill {

        private static int lastId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public Skill(string name, string description, Category category) {
            this.Id = ++lastId;
            this.Name = name;
            this.Description = description;
            this.Category = category;
        }

        // Método estático para obtener el siguiente ID disponible
        public static int GetNextId() {
            return lastId + 1;
        }
    }
}
