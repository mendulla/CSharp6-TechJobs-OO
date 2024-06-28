using System;

namespace TechJobsOOAutoGraded6
{
    // Inherits from JobField to use its common properties and methods
    public class Employer : JobField
    {
        // Constructor that accepts a 'value' parameter and passes it to the base class constructor
        public Employer(string value) : base(value)
        {
        }

        // All common properties and methods are inherited from JobField
    }
}
