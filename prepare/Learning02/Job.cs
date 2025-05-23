using System;

namespace Learning02
{
    public class Job
    {
        // Member variables (start with underscore and lowercase)
        private string _company;
        private string _jobTitle;
        private int _startYear;
        private int _endYear;

        // Constructor (optional, but good practice for initializing)
        public Job()
        {
            _company = "";
            _jobTitle = "";
            _startYear = 0;
            _endYear = 0;
        }

        // Public properties (PascalCase) - Not used in the original problem, but good practice
        public string Company { get => _company; set => _company = value; }
        public string JobTitle { get => _jobTitle; set => _jobTitle = value; }
        public int StartYear { get => _startYear; set => _startYear = value; }
        public int EndYear { get => _endYear; set => _endYear = value; }

        // Method to display job details
        public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }
}