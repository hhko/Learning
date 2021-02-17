using System;
using System.Collections.Generic;

namespace Step_01_IEquatable
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicants = new List<FullName>();
            var applicant1 = new FullName("고", "길동");
            applicants.Add(applicant1);

            FullName candidate = new FullName("고", "길동");
            if (applicants.Contains(candidate))
                Console.WriteLine($"Found {candidate.FirstName}{candidate.LastName}.");
            else
                Console.WriteLine($"Applicant {candidate.FirstName}{candidate.LastName} not found.");

            Console.WriteLine($"{applicant1.FirstName}{applicant1.LastName} already on file: {FullName.Equals(applicant1, candidate)}.");
        }
    }
}
