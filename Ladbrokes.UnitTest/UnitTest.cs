using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Ladbrokes;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Ladbrokes.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ladbrokes.UnitTest
{
    public class UnitTest
    {
        ValuesController _valuesController;
        private const bool Expected = true;

        public UnitTest()
        {
            _valuesController = new ValuesController(Expected);
        }
      
        [Fact]
        public void Get_CheckValidTypewithString()
        {
            // Arrange
            var codename = "0,0,7";

            // Act
            var expected = typeof(bool);
            bool okResult = _valuesController.Get(codename);

            // Assert#
            Assert.IsType(expected, okResult);
        }

        [Fact]
        public void Get_CheckValidTypewithList()
        {
            // Arrange
            List<int> codename = StringtoList("0,0,7");
            // Act
            var expected = typeof(bool);
            bool okResult = _valuesController.Get(codename);

            // Assert#
            Assert.IsType(expected, okResult);
        }

        [Fact]
        public void Get_CheckValidTypewithListEmpty()
        {
            // Arrange
            List<int> codename = StringtoList("");
            // Act
            var expected = typeof(bool);
            bool okResult = _valuesController.Get(codename);

            // Assert#
            Assert.IsType(expected, okResult);
        }


        public List<int> StringtoList(string message)
        {
            List<int> listmessage = new List<int>();
            try
            {
                listmessage = message.Split(',').Select(Int32.Parse).ToList();
            }
            catch { listmessage.Add(0); }
            return listmessage;
        }

    }
}
