using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests.Graphs
{
    public class CourseSchedule
    {
        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {

        }

        private HashSet<Course> MakeGraph(int[,] prerequisites)
        {
            var courses = new HashSet<Course>();

            return courses;
        }

        public class Course
        {
            public List<Course> Prerequisites;
            public int CourseNumber;
        }
    }
}
