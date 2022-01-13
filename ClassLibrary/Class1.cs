using LibTest;
using System;
using Tekla.Structures.Model;

namespace ClassLibrary
{
    public class ClassLibTest
    {
        public string Test()
        {
            var testString = new ModelTest().GetTest();

            try
            {
                var model = new Model().GetProjectInfo();
            }
            catch (Exception e)
            {

            }

            return testString;
        }
    }
}
