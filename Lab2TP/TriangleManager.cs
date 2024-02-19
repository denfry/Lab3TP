using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2TP.MainForm;

namespace Lab2TP
{
    internal class TriangleManager
    {
        private static isoscelesTriangle activeTriangle;

        public static isoscelesTriangle GetActiveTriangle()
        {
            return activeTriangle;
        }

        public static void SetActiveTriangle(isoscelesTriangle triangle)
        {
            activeTriangle = triangle;
        }
    }
}
