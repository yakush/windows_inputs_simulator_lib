using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private const int MOUSEEVENTF_WHEEL = 0x0800; //The wheel has been moved, if the mouse has a wheel. The amount of movement is specified in dwData


        public static void DoMouseClick(uint x, uint y)
        {
            //Call the imported function with the cursor's current position
            //int X = Cursor.Position.X;
            //int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void DoMouseWheel(int amount)
        {
            //Call the imported function with the cursor's current position
            //int X = Cursor.Position.X;
            //int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, amount, 0);
        }

        static void Main(string[] args)
        {
            var DELAY = 0;

            Console.WriteLine("wait for it...");
            Thread.Sleep(5000);
            Console.WriteLine("bam");
            /*
            System.Console.WriteLine("sending");
            var res = SendInputWrapper.SendInputWithAPI();
            System.Console.WriteLine(res);
            

            System.Console.ReadKey();
            System.Console.ReadKey();
            System.Console.ReadKey();
            System.Console.ReadKey();
            System.Console.ReadKey();
            */
            /*
            for (int i = 0; i < 31; i++)
            {
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_A).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_B).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_C).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_D).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_E).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_F).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_G).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_H).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_I).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_J).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_K).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_L).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_M).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_N).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_O).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_P).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_Q).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_R).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_S).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_T).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_U).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_V).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_W).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_X).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_Y).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);
                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.KEY_Z).execute();
                if (DELAY > 0) Thread.Sleep(DELAY);

                new InputSequencer().keyClickScan(SendInputWrapper.ScanCodeShort.RETURN).execute();
            }
            */
            /*
            for (int i = 0; i < 31; i++)
            {
                var seq = new InputSequencer();
                seq
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_A)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_B)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_C)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_D)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_E)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_B)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_G)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_B)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_I)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_J)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_K)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_L)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_M)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_N)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_O)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_P)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_Q)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_R)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_S)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_T)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_U)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_V)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_W)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_X)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_Y)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.KEY_X)
                   .keyClickScan(SendInputWrapper.ScanCodeShort.RETURN);
                seq.execute();
                Thread.Sleep(500);
            }
            */


            for (int i = 0; i < 5; i++)
            {
                new InputSequencer().keyDownScan(SendInputWrapper.ScanCodeShort.LCONTROL).execute();
                new InputSequencer().mouseWheelVertical(200).execute();
                new InputSequencer().keyUpScan(SendInputWrapper.ScanCodeShort.LCONTROL).execute();
                Thread.Sleep(60);
            }

            for (int i = 0; i < 5; i++)
            {
                new InputSequencer().keyDownScan(SendInputWrapper.ScanCodeShort.LCONTROL).execute();
                new InputSequencer().mouseWheelVertical(-200).execute();
                new InputSequencer().keyUpScan(SendInputWrapper.ScanCodeShort.LCONTROL).execute();
                Thread.Sleep(60);
            }


            /*
            var DELAY = 10;
            InputSequencer seq = new InputSequencer();

            //define the sequence:
            new InputSequencer().mouseMove(InputSequencer.MouseMoveType.ABSOLUTE, 0.50f, 0.50f).execute();
            Thread.Sleep(DELAY);            
            new InputSequencer().mouseDown(InputSequencer.MouseButton.LEFT).execute();
            //.wait(2200)
            Thread.Sleep(DELAY);
            //new InputSequencer().keyDownScan(SendInputWrapper.ScanCodeShort.SHIFT).execute();
            Thread.Sleep(DELAY);
            new InputSequencer().mouseMove(InputSequencer.MouseMoveType.ABSOLUTE, 0.55f, 0.50f).execute();
            //.wait(2200)
            Thread.Sleep(DELAY);
            new InputSequencer().mouseMove(InputSequencer.MouseMoveType.ABSOLUTE, 0.55f, 0.55f).execute();
            //.wait(2200)
            Thread.Sleep(DELAY);
            new InputSequencer().mouseMove(InputSequencer.MouseMoveType.ABSOLUTE, 0.50f, 0.55f).execute();
            //.wait(2200)
            Thread.Sleep(DELAY);
            new InputSequencer().mouseMove(InputSequencer.MouseMoveType.ABSOLUTE, 0.50f, 0.50f).execute();
            Thread.Sleep(DELAY);
            new InputSequencer().mouseUp(InputSequencer.MouseButton.LEFT).execute();
            Thread.Sleep(DELAY);
            //new InputSequencer().keyUpScan(SendInputWrapper.ScanCodeShort.SHIFT).execute();

            //.keyUp();
            */

            //do it:
            //seq.execute();

            //while (true)
            //{
            //    //DoMouseClick(100, 100);
            //    DoMouseWheel(-100);
            //    Thread.Sleep(1000);
            //}

            Thread.Sleep(5000);
        }
    }
}
