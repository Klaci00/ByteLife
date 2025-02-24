using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    /// <summary>
    /// Represents a work activity.
    /// </summary>
    /// <param name="year">Year of entry.</param>
    /// <param name="name">Name of company.</param>
    /// <param name="salary" ></param>
    /// <param name="performance"></param>
    /// <param name="workhours"></param>
    public class Work(int year, string name, int salary, int performance, int workhours) : Activity(year, name)
    {
        /// <summary>
        /// Gets or sets the year of entry.
        /// </summary>
        public new int Year { get; set; } = year;

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public new string Name { get; set; } = name;

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public int Salary { get; set; } = salary;

        /// <summary>
        /// Gets or sets the performance.
        /// </summary>
        public int Performance { get; set; } = performance;

        /// <summary>
        /// Gets or sets the work hours.
        /// </summary>
        public int WorkHours { get; set; } = workhours;
    }
}
