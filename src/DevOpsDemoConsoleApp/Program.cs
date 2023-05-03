using System;
using System.Net;
using System.Text;
using System.Xml;

namespace DevOpsDemoConsoleApp
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main()
        {

            Calculator c = new Calculator();


            Console.WriteLine(c.Add(5, 5).ToString());
            Console.WriteLine();
            Console.WriteLine(c.Multiply(5, 5).ToString());



        }
    }


























    /*
     * export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1 
/dotnet/dotnet build /var/jenkins_home/workspace/DevOpsJob/DevOpsDemoConsoleApp
if [ $? -eq 0 ]
then
/dotnet/dotnet test --nodereuse:false --no-build --blame --logger "trx;LogFileName=UnitTests.xml" /var/jenkins_home/workspace/DevOpsJob/DevOpsDemoTest/DevOpsDemoTest.csproj
# sleep 2
# curl -X POST -H "X-APIKey:KNEH369SKRS64T5W7SUFE5XU8FI0HQV7" -H "Content-Type:application/xml" -d @/var/jenkins_home/workspace/DevOpsJob/DevOpsDemoTest/TestResults/UnitTests.xml https://myappformdev02.centennialcollege.ca/CencolCoreLibraryWebApi/api/scm/unittest/log
fi
    */



}
