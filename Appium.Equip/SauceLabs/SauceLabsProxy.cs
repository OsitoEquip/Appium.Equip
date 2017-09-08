using RestSharp;
using RestSharp.Authenticators;
using Selenium.WebDriver.Equip.SauceLabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appium.Equip.SauceLabs
{
    public class SauceLabsProxy
    {
        public static void UploadAndriodPackage()
        {
            string FileName = "com.companyname.Ritalin-Signed.apk";
            string FilePath = @"C:\Users\Rick\Documents\GitHub\Appium.Equip\SampleApps\Ritalin\Ritalin\Ritalin.Android\bin\Debug\com.companyname.Ritalin-Signed.apk";

            var client = new RestClient("https://saucelabs.com/rest/v1/");
            client.Authenticator = new HttpBasicAuthenticator(SauceDriverKeys.SAUCELABS_USERNAME, SauceDriverKeys.SAUCELABS_USERNAME);
            var request = new RestRequest("storage/" + SauceDriverKeys.SAUCELABS_USERNAME + "/" + FileName + "?overwrite=true", Method.POST);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddFile(FileName, FilePath);
            var result = client.Execute(request);
            Console.WriteLine(result.Content);
        }
    }
}
