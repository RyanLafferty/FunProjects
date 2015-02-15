/*Author: Ryan Lafferty*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace PcPrank
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mouseThread;
            Thread keyboardThread;
            Thread messageThread;
            Thread noiseThread;
            int delay;
            int runTime;

            mouseThread = new Thread(new ThreadStart(mouse));
            keyboardThread = new Thread(new ThreadStart(keyboard));
            messageThread = new Thread(new ThreadStart(message));
            noiseThread = new Thread(new ThreadStart(noise));
            delay = 0;
            runTime = 0;

            mouseThread.Start();
            keyboardThread.Start();
            messageThread.Start();
            noiseThread.Start();
        }


        //Jitter mouse around
        private static void mouse()
        {
            int x;
            int y;
            int xBump;
            int yBump;
            int pTive;
            Random rand = new Random();

            x = 0;
            y = 0;
            xBump = 0;
            yBump = 0;
            pTive = 0;

            while (true)
            {
                x = (int)Cursor.Position.X;
                y = (int)Cursor.Position.Y;

                xBump = rand.Next(11);
                yBump = rand.Next(11);

                pTive = rand.Next(2);
                if (pTive == 1)
                {
                    x = x + xBump;
                }
                else
                {
                    x = x - xBump;
                }

                pTive = rand.Next(2);
                if (pTive == 1)
                {
                    y = y + yBump;
                }
                else
                {
                    y = y - yBump;
                }

                //move cusor position
                Cursor.Position = new System.Drawing.Point(x, y);

                Thread.Sleep(500);
            }
        }

        //Enter random letters
        private static void keyboard()
        {
            char key;
            Random rand = new Random();

            key = (char)0;

            while (true)
            {
                key = (char)rand.Next(64, 91);

                if (rand.Next(2) == 0)
                {
                    key = char.ToLower(key);
                }

                //send character
                SendKeys.SendWait(key.ToString());

                Thread.Sleep(500);
            }
        }

        private static void message()
        {
            int mess;
            Random rand = new Random();

            mess = 0;

            while (true)
            {
                mess = rand.Next(3);
                switch (mess)
                {
                    case 0:
                        {
                            MessageBox.Show("Running low on memory",
                                            "Windows",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            break;
                        }
                    case 1:
                        {
                            MessageBox.Show("Heavy cpu load",
                                            "Windows",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            break;
                        }
                    case 2:
                        {
                            MessageBox.Show("Virus Detected",
                                            "Windows",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                Thread.Sleep(10000);
            }
        }

        private static void noise()
        {
            int sound;
            Random rand = new Random();

            sound = 0;

            while (true)
            {
                sound = rand.Next(3);
                switch (sound)
                {
                    case 0:
                        {
                            SystemSounds.Asterisk.Play();
                            break;
                        }
                    case 1:
                        {
                            SystemSounds.Beep.Play();
                            break;
                        }
                    case 2:
                        {
                            SystemSounds.Hand.Play();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                Thread.Sleep(10000);
            }

        }
    }
}
