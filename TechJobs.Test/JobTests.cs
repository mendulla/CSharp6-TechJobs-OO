using System;
namespace TechJobs.Tests
{
    [TestClass]
    public class JobTests
    {
        // Testing Objects
        // Initialize your testing objects here
        private Job job1;
        private Job job2;
        private Job job3;
        private Job job4;

        [TestInitialize]
        public void CreateJobObjects()
        {
            job1 = new Job();
            job2 = new Job();
            job3 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            job4 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        // Each Job object should contain a unique ID number, and these should also be sequential integers.
        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsFalse(job1.Id == job2.Id, "IDs should not be the same");
            Assert.IsTrue(job2.Id - job1.Id == 1, "IDs should be sequential and differ by 1");
        }

        // This test checks if the full constructor correctly assigns all fields.
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", job3.Name, "Name should match constructor input.");
            Assert.AreEqual("ACME", job3.EmployerName.Value, "Employer should match constructor input.");
            Assert.AreEqual("Desert", job3.EmployerLocation.Value, "Location should match constructor input.");
            Assert.AreEqual("Quality control", job3.JobType.Value, "Job type should match constructor input.");
            Assert.AreEqual("Persistence", job3.JobCoreCompetency.Value, "Core competency should match constructor input.");
        }

        // Two Job objects are considered equal if they have the same id value, even if one or more of the other fields differ.
        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4), "Jobs with different IDs should not be considered equal.");
        }

        // Test if the output starts and ends with a newline
        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            string nl = Environment.NewLine;
            Job testJob = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            string output = testJob.ToString();
            Assert.IsTrue(output.StartsWith(nl) && output.EndsWith(nl), "The ToString() method should start and end with a newline.");
        }
    }
}
