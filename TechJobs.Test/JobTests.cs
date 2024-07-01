using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        // Test to ensure that each job has a unique ID and IDs are sequential
        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsFalse(job1.Id == job2.Id, "IDs should not be the same");
            Assert.IsTrue(job2.Id - job1.Id == 1, "IDs should be sequential and differ by 1");
        }

        // Test to ensure constructor correctly assigns values to all fields
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", job3.Name, "Name should match constructor input.");
            Assert.AreEqual("ACME", job3.EmployerName.Value, "Employer should match constructor input.");
            Assert.AreEqual("Desert", job3.EmployerLocation.Value, "Location should match constructor input.");
            Assert.AreEqual("Quality control", job3.JobType.Value, "Job type should match constructor input.");
            Assert.AreEqual("Persistence", job3.JobCoreCompetency.Value, "Core competency should match constructor input.");
        }

        // Test to ensure that two jobs are not considered equal if their IDs are different
        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(job3.Equals(job4), "Jobs with different IDs should not be considered equal.");
        }

        // Test to ensure that the ToString method starts and ends with a newline
        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            string nl = Environment.NewLine;
            Job testJob = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            string output = testJob.ToString();
            Assert.IsTrue(output.StartsWith(nl) && output.EndsWith(nl), "The ToString() method should start and end with a newline.");
        }

        // Test to ensure that the ToString method contains correct labels and data
        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            string nl = Environment.NewLine;
            Job testJob = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            string output = testJob.ToString();
            string expected = nl +
                              "ID: " + testJob.Id + nl +
                              "Name: Web Developer" + nl +
                              "Employer: LaunchCode" + nl +
                              "Location: St. Louis" + nl +
                              "Position Type: Front-end developer" + nl +
                              "Core Competency: JavaScript" + nl;
            Assert.AreEqual(expected, output, "The ToString() method should contain correct labels and data.");
        }

        // Test to ensure that the ToString method handles empty fields appropriately
        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            string nl = Environment.NewLine;
            Job testJob = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            string output = testJob.ToString();
            string expected = nl +
                              "ID: " + testJob.Id + nl +
                              "Name: Data not available" + nl +
                              "Employer: Data not available" + nl +
                              "Location: Data not available" + nl +
                              "Position Type: Data not available" + nl +
                              "Core Competency: Data not available" + nl;
            Assert.AreEqual(expected, output, "The ToString() method should handle empty fields correctly.");
        }
    }
}
