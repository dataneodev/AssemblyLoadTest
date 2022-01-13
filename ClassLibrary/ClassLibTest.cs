using LibTest;
using System;
using Tekla.Structures.Model;

namespace ClassLibrary
{
    public class ClassLibTest
    {
        public string Test()
        {
            var teklaModel = new Model();
            var connectionStatus = teklaModel.GetConnectionStatus();
            if (!connectionStatus)
                throw new Exception("Tekla structures not connected");

            return new ModelTest().GetTest();
        }
    }
}
