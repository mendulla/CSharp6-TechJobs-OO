using System;
namespace TechJobsOOAutoGraded6
{
    public class Job
    {
        // Fields and properties for the Job class
        public int Id { get; }
        private static int nextId = 1; // Static field to track the last used ID
        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Task 3: Add the two necessary constructors.
        // Parameterless constructor to initialize the Job object with a unique ID
        public Job()
        {
            Id = nextId;
            nextId++; // Increment the static ID counter after assigning the ID
        }

        // Constructor that takes five parameters to set the job's properties
        // This constructor calls the parameterless constructor with ':this()' to ensure the ID is set
        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency)
            : this() // Calls the parameterless constructor first to handle ID initialization
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Task 3: Generate Equals() and GetHashCode() methods.
        // Overrides the Equals method to compare Job objects based on their ID for uniqueness
        public override bool Equals(object obj)
        {
            return obj is Job job && Id == job.Id;
        }

        // Overrides GetHashCode to return a hash code based on the Job's ID
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // TODO: Task 5: Generate custom ToString() method.
        //Until you create this method, you will not be able to print a job to the console.
        // Generates a custom string format that represents the Job object.
        public override string ToString()
        {
            string nl = Environment.NewLine; // Use Environment.NewLine for consistency with class coding style
            // Construct the job information string
            return nl +
                   "ID: " + Id + nl +
                   "Name: " + (Name ?? "Data not available") + nl +
                   "Employer: " + (EmployerName?.Value ?? "Data not available") + nl +
                   "Location: " + (EmployerLocation?.Value ?? "Data not available") + nl +
                   "Position Type: " + (JobType?.Value ?? "Data not available") + nl +
                   "Core Competency: " + (JobCoreCompetency?.Value ?? "Data not available") + nl;
        }
    }
}
