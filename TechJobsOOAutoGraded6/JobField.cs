using System;

namespace TechJobsOOAutoGraded6
{
    public abstract class JobField
    {
        public int Id { get; protected set; }
        private static int nextId = 1;
        public string Value { get; set; }

        // Constructor to handle ID initialization
        public JobField()
        {
            Id = nextId;
            nextId++;
        }

        // Constructor that accepts a value
        public JobField(string value) : this()
        {
            Value = value;
        }

        // Equals and GetHashCode methods
        public override bool Equals(object obj)
        {
            return obj is JobField other && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
