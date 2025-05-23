using System;
using System.Collections.Generic;

namespace Learning02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Job instances
            Job job1 = new Job();
            job1.JobTitle = "Software Engineer";
            job1.Company = "Microsoft";
            job1.StartYear = 2019;
            job1.EndYear = 2022;

            Job job2 = new Job();
            job2.JobTitle = "Manager";
            job2.Company = "Apple";
            job2.StartYear = 2022;
            job2.EndYear = 2023;

            // Create a Resume instance
            Resume myResume = new Resume();
            myResume.Name = "Allison Rose";

            // Add the jobs to the resume
            myResume.AddJob(job1);
            myResume.AddJob(job2);

            // Display the resume
            myResume.Display();
        }
    }
}
