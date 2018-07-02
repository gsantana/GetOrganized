using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace GetOrganizedTest
{
    public class TodoWebServicesTest
    {
        [Fact]
        public void Should_Authenticate_Against_Form()
        {
            HttpWebResponse response =
            WebServiceUtil.AuthenticateWithForms("jonathan@test.com", "Abc123!",
            "https://localhost:44342/Account/Login");
            Assert.Single(response.Cookies);
            Assert.Equal(".ASPXAUTH", response.Cookies[0].Name);
        }
    }
}
