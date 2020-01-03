using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csharp_graphical_application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application.Tests
{
    [TestClass()]
    public class CircleTests
    {
        Circle rec_obj = new Circle();
        /// <summary>
        /// test weather the value passed is set or not 
        /// </summary>
        [TestMethod()]
        public void SetParamTest()
        {
            /// arrange
            int x = 23;
            int y = 85;

            /// act
            rec_obj.SetParam(x, y, 45,45);
            /// assert
            Assert.AreEqual(25, rec_obj.x);
            Assert.AreEqual(y, rec_obj.y);
        }
    }
}