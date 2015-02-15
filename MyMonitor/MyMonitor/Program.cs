/*Author: Ryan Lafferty*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace MyMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceCounter cpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            PerformanceCounter avaMem = new PerformanceCounter("Memory", "Available MBytes");
            SpeechSynthesizer syn = new SpeechSynthesizer();
            float cpuP = 0;
            int aMem = 0;

            while(true)
            {
                //pull data
                cpuP = cpuCount.NextValue();
                aMem = (int) avaMem.NextValue();

                //write to console/terminal
                Console.WriteLine("CPU Load:         {0:0.00} %", cpuP);
                Console.WriteLine("Available Memory: {0} MB", aMem);

                //create messages for synthesizer
                String message1 = String.Format("CPU load is {0:0.00} percent", cpuP);
                String message2 = String.Format("Available memory is {0} mega bytes", aMem);
                
                //output messages using synthesizer
                syn.Speak(message1);
                syn.Speak(message2);

                //sleep (ms)
                Thread.Sleep(5000);
            }
        }
    }
}
