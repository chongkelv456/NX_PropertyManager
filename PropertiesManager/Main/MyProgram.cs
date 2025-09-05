using PropertiesManager.Control;
using PropertiesManager.Services;
using PropertiesManager.View;
using System;

namespace PropertiesManager
{
    public partial class MyProgram
    {        
        public static void Main(string[] args)
        {
            // Log usage - single line addition
            UsageTracker.LogUsage("PropertiesManager");

            Controller controller = new Controller();
        }
    }
}
