﻿// --------------------------------------------------------------------------------------------
// <copyright file="JoinFixture.cs" company="Effort Team">
//     Copyright (C) 2011-2013 Effort Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------

namespace Effort.Test.Features
{
    using System.Linq;
    using Effort.Test.Data.Northwind;
    using Effort.Test.Internal.Queries;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JoinFixture
    {
        private IQueryTester<NorthwindObjectContext> tester;

        [TestInitialize]
        public void Initialize()
        {
            this.tester = new NorthwindQueryTester();
        }

        [TestMethod]
        public void CrossJoin()
        {
            string expected = "[{\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Callahan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Callahan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Callahan\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Callahan\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Callahan\"},{\"LastName\":\"Suyama\",\"LastName1\":\"Callahan\"},{\"LastName\":\"King\",\"LastName1\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Suyama\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"King\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Callahan\",\"LastName1\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Davolio\",\"LastName1\":\"King\"},{\"LastName\":\"Fuller\",\"LastName1\":\"King\"},{\"LastName\":\"Leverling\",\"LastName1\":\"King\"},{\"LastName\":\"Peacock\",\"LastName1\":\"King\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"King\"},{\"LastName\":\"Suyama\",\"LastName1\":\"King\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\"}]";
#if EF6
            expected = "[{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":6,\"LastName\":\"Suyama\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":7,\"LastName\":\"King\",\"LastName1\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":6,\"LastName\":\"Suyama\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":7,\"LastName\":\"King\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":8,\"LastName\":\"Callahan\",\"LastName1\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"King\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"King\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"King\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"King\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"King\"},{\"EmployeeID\":6,\"LastName\":\"Suyama\",\"LastName1\":\"King\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\"}]";
#endif
            
            ICorrectness result = this.tester.TestQuery(
                context =>
                    from 
                        employee1 in context.Employees
                    from 
                        employee2 in context.Employees
                    where
                      employee1.EmployeeID < employee2.EmployeeID
                    select new
                    {
                        E1 = employee1.LastName,
                        E2 = employee2.LastName
                    }, 
                expected);

            Assert.IsTrue(result.Check());
        }

        [TestMethod]
        public void TripleCrossJoin()
        {
            string expected = "[{\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Leverling\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Peacock\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Buchanan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"King\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Peacock\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Buchanan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"King\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Buchanan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"King\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Davolio\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Davolio\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Peacock\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Buchanan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"King\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Buchanan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"King\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Fuller\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Fuller\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"King\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Buchanan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"King\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Leverling\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Leverling\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Peacock\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Peacock\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Suyama\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"LastName\":\"Suyama\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"LastName\":\"Suyama\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"}]";
#if EF6
            expected = "[{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":5,\"LastName\":\"Buchanan\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Leverling\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Peacock\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Buchanan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"King\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Peacock\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Buchanan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"King\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Leverling\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Buchanan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"King\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Peacock\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Peacock\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Buchanan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"King\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Leverling\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Buchanan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"King\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Peacock\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":2,\"LastName\":\"Fuller\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":7,\"LastName\":\"King\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Buchanan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"King\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Peacock\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":3,\"LastName\":\"Leverling\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Suyama\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"King\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Buchanan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\",\"LastName2\":\"King\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Suyama\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":4,\"LastName\":\"Peacock\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":6,\"LastName\":\"Suyama\",\"LastName1\":\"King\",\"LastName2\":\"Callahan\"},{\"EmployeeID\":6,\"LastName\":\"Suyama\",\"LastName1\":\"King\",\"LastName2\":\"Dodsworth\"},{\"EmployeeID\":6,\"LastName\":\"Suyama\",\"LastName1\":\"Callahan\",\"LastName2\":\"Dodsworth\"}]";
#endif

            ICorrectness result = this.tester.TestQuery(
                context =>
                    from
                        employee1 in context.Employees
                    from
                        employee2 in context.Employees
                    from
                        employee3 in context.Employees
                    where
                      employee1.EmployeeID < employee2.EmployeeID &&
                      employee2.EmployeeID < employee3.EmployeeID 
                    select new
                    {
                        E1 = employee1.LastName,
                        E2 = employee2.LastName,
                        E3 = employee3.LastName
                    },
                expected);

            Assert.IsTrue(result.Check());
        }

        [TestMethod]
        public void OuterJoin()
        {
            string expected = "[{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Fuller\",\"LastName1\":null},{\"LastName\":\"Leverling\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Suyama\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"King\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Callahan\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Dodsworth\",\"LastName1\":\"Buchanan\"}]";
#if EF6
            expected = "[{\"C1\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Fuller\",\"LastName1\":null},{\"C1\":1,\"LastName\":\"Leverling\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Peacock\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Buchanan\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Suyama\",\"LastName1\":\"Buchanan\"},{\"C1\":1,\"LastName\":\"King\",\"LastName1\":\"Buchanan\"},{\"C1\":1,\"LastName\":\"Callahan\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Dodsworth\",\"LastName1\":\"Buchanan\"}]";
#endif

            ICorrectness result = this.tester.TestQuery(
                context =>
                    from employee in context.Employees

                    join _principal in context.Employees
                    on employee.ReportsTo equals _principal.EmployeeID into __principal
                    from principal in __principal.DefaultIfEmpty()

                    select new
                    {
                        Name = employee.LastName,
                        PrincipalName = principal.LastName
                    }, 
                expected);


            Assert.IsTrue(result.Check());
        }

        [TestMethod]
        public void OuterJoin2()
        {
            string expected = "[{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Fuller\",\"LastName1\":null},{\"LastName\":\"Leverling\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Suyama\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"King\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Callahan\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Dodsworth\",\"LastName1\":\"Buchanan\"}]";
#if EF6
            expected = "[{\"C1\":1,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Fuller\",\"LastName1\":null},{\"C1\":1,\"LastName\":\"Leverling\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Peacock\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Buchanan\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Suyama\",\"LastName1\":\"Buchanan\"},{\"C1\":1,\"LastName\":\"King\",\"LastName1\":\"Buchanan\"},{\"C1\":1,\"LastName\":\"Callahan\",\"LastName1\":\"Fuller\"},{\"C1\":1,\"LastName\":\"Dodsworth\",\"LastName1\":\"Buchanan\"}]";
#endif

            ICorrectness result = this.tester.TestQuery(
                context =>
                    from emp in context.Employees
                    select new
                    {
                        Name = emp.LastName,
                        PrincipalName = emp.Principal.LastName
                    }, 
                expected);

            Assert.IsTrue(result.Check());
        }

        [TestMethod]
        public void InnerJoin()
        {
            string expected = "[{\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Leverling\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Peacock\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Buchanan\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Suyama\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"King\",\"LastName1\":\"Buchanan\"},{\"LastName\":\"Callahan\",\"LastName1\":\"Fuller\"},{\"LastName\":\"Dodsworth\",\"LastName1\":\"Buchanan\"}]";
#if EF6
            expected = "[{\"EmployeeID\":2,\"LastName\":\"Davolio\",\"LastName1\":\"Fuller\"},{\"EmployeeID\":2,\"LastName\":\"Leverling\",\"LastName1\":\"Fuller\"},{\"EmployeeID\":2,\"LastName\":\"Peacock\",\"LastName1\":\"Fuller\"},{\"EmployeeID\":2,\"LastName\":\"Buchanan\",\"LastName1\":\"Fuller\"},{\"EmployeeID\":5,\"LastName\":\"Suyama\",\"LastName1\":\"Buchanan\"},{\"EmployeeID\":5,\"LastName\":\"King\",\"LastName1\":\"Buchanan\"},{\"EmployeeID\":2,\"LastName\":\"Callahan\",\"LastName1\":\"Fuller\"},{\"EmployeeID\":5,\"LastName\":\"Dodsworth\",\"LastName1\":\"Buchanan\"}]";
#endif

            ICorrectness result = this.tester.TestQuery(
                context =>
                    from employee in context.Employees
                    join principal in context.Employees
                    on employee.ReportsTo equals principal.EmployeeID
                    select new
                    {
                        Name = employee.LastName,
                        PrincipalName = principal.LastName
                    }, 
                expected);

            Assert.IsTrue(result.Check());
        }

        [TestMethod]
        public void OuterApply()
        {
            string expected = "[{\"FirstName\":\"Nancy\",\"FirstName1\":\"Michael\"},{\"FirstName\":\"Andrew\",\"FirstName1\":\"Robert\"},{\"FirstName\":\"Janet\",\"FirstName1\":\"Laura\"},{\"FirstName\":\"Margaret\",\"FirstName1\":\"Anne\"},{\"FirstName\":\"Steven\",\"FirstName1\":null},{\"FirstName\":\"Michael\",\"FirstName1\":null},{\"FirstName\":\"Robert\",\"FirstName1\":null},{\"FirstName\":\"Laura\",\"FirstName1\":null},{\"FirstName\":\"Anne\",\"FirstName1\":null}]";
#if EF6
            expected = "[{\"EmployeeID\":1,\"FirstName\":\"Nancy\",\"FirstName1\":\"Michael\"},{\"EmployeeID\":2,\"FirstName\":\"Andrew\",\"FirstName1\":\"Robert\"},{\"EmployeeID\":3,\"FirstName\":\"Janet\",\"FirstName1\":\"Laura\"},{\"EmployeeID\":4,\"FirstName\":\"Margaret\",\"FirstName1\":\"Anne\"},{\"EmployeeID\":5,\"FirstName\":\"Steven\",\"FirstName1\":null},{\"EmployeeID\":6,\"FirstName\":\"Michael\",\"FirstName1\":null},{\"EmployeeID\":7,\"FirstName\":\"Robert\",\"FirstName1\":null},{\"EmployeeID\":8,\"FirstName\":\"Laura\",\"FirstName1\":null},{\"EmployeeID\":9,\"FirstName\":\"Anne\",\"FirstName1\":null}]";
#endif

            ICorrectness result = this.tester.TestQuery(
                context =>
                    from emp1 in context.Employees
                    from emp2 in context.Employees
                        .Where(e => e.EmployeeID == emp1.EmployeeID + 5)
                        .Take(2)
                        .DefaultIfEmpty()
                    select new { e1 = emp1.FirstName, e2 = emp2.FirstName },
                expected);

            Assert.IsTrue(result.Check());
        }

        [TestMethod]
        public void CrossApply()
        {
            string expected = "[{\"FirstName\":\"Nancy\",\"FirstName1\":\"Michael\"},{\"FirstName\":\"Andrew\",\"FirstName1\":\"Robert\"},{\"FirstName\":\"Janet\",\"FirstName1\":\"Laura\"},{\"FirstName\":\"Margaret\",\"FirstName1\":\"Anne\"}]";
#if EF6
            expected = "[{\"EmployeeID\":1,\"FirstName\":\"Nancy\",\"FirstName1\":\"Michael\"},{\"EmployeeID\":2,\"FirstName\":\"Andrew\",\"FirstName1\":\"Robert\"},{\"EmployeeID\":3,\"FirstName\":\"Janet\",\"FirstName1\":\"Laura\"},{\"EmployeeID\":4,\"FirstName\":\"Margaret\",\"FirstName1\":\"Anne\"}]";
#endif

            ICorrectness result = this.tester.TestQuery(
                context =>
                    from emp1 in context.Employees
                    from emp2 in context.Employees
                        .Where(e => e.EmployeeID == emp1.EmployeeID + 5)
                        .Take(2)
                    select new { e1 = emp1.FirstName, e2 = emp2.FirstName },
                expected);

            Assert.IsTrue(result.Check());
        }
    }
}
