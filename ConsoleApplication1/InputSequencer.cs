using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApplication1.SendInputWrapper;

namespace ConsoleApplication1
{
    public class InputSequencer
    {
        [DllImport("kernel32")]
        internal extern static UInt64 GetTickCount64();

        public enum MouseButton
        {
            LEFT, RIGHT, MIDDLE, X_BUTTON
        }

        public enum MouseMoveType
        {
            RELATIVE, ABSOLUTE, VIRTUAL_DESKTOP
        }

        private int delay;
        private List<INPUT> inputs = new List<INPUT>();

        public uint execute()
        {

            return SendInput(
                (uint)inputs.Count,
                inputs.ToArray(),
                INPUT.Size);
        }

        // -------------------------------------------------------------------
        // KEYBOARD
        // -------------------------------------------------------------------
        public InputSequencer keyDownScan(ScanCodeShort key)
        {
            var input = new INPUT();
            input.type = InputType.KEYBOARD;

            input.U.ki.wScan = key;
            input.U.ki.wVk = 0;
            input.U.ki.dwFlags |= KEYEVENTF.SCANCODE;
            //input.U.ki.dwFlags |= KEYEVENTF.KEYUP;

            inputs.Add(input);
            return this;
        }

        public InputSequencer keyUpScan(ScanCodeShort key)
        {
            var input = new INPUT();
            input.type = InputType.KEYBOARD;

            input.U.ki.wScan = key;
            input.U.ki.wVk = 0;
            input.U.ki.dwFlags |= KEYEVENTF.SCANCODE;
            input.U.ki.dwFlags |= KEYEVENTF.KEYUP;

            inputs.Add(input);
            return this;
        }

        public InputSequencer keyClickScan(ScanCodeShort key)
        {
            keyDownScan(key);
            keyUpScan(key);
            return this;
        }
        // -------------------------------------------------------------------
        // MOUSE
        // -------------------------------------------------------------------
        public InputSequencer mouseDown(MouseButton button)
        {
            var input = new INPUT();
            input.type = InputType.MOUSE;

            input.U.mi.dwFlags = 0;
            switch (button)
            {
                case MouseButton.LEFT:
                    input.U.mi.dwFlags |= MOUSEEVENTF.LEFTDOWN;
                    break;
                case MouseButton.RIGHT:
                    input.U.mi.dwFlags |= MOUSEEVENTF.RIGHTDOWN;
                    break;
                case MouseButton.MIDDLE:
                    input.U.mi.dwFlags |= MOUSEEVENTF.MIDDLEDOWN;
                    break;
                case MouseButton.X_BUTTON:
                    input.U.mi.dwFlags |= MOUSEEVENTF.XDOWN;
                    break;
                default:
                    break;
            }

            inputs.Add(input);
            return this;
        }
        public InputSequencer mouseUp(MouseButton button)
        {
            var input = new INPUT();
            input.type = InputType.MOUSE;

            input.U.mi.dwFlags = 0;

            switch (button)
            {
                case MouseButton.LEFT:
                    input.U.mi.dwFlags |= MOUSEEVENTF.LEFTUP;
                    break;
                case MouseButton.RIGHT:
                    input.U.mi.dwFlags |= MOUSEEVENTF.RIGHTUP;
                    break;
                case MouseButton.MIDDLE:
                    input.U.mi.dwFlags |= MOUSEEVENTF.MIDDLEUP;
                    break;
                case MouseButton.X_BUTTON:
                    input.U.mi.dwFlags |= MOUSEEVENTF.XUP;
                    break;
                default:
                    break;
            }

            inputs.Add(input);
            return this;
        }
        public InputSequencer mouseClick(MouseButton button)
        {
            //both.
            mouseDown(button);
            mouseUp(button);
            return this;
        }

        /// <summary>
        /// positive : up, negative: down.
        /// one wheel click = 120
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public InputSequencer mouseWheelVertical(int amount)
        {
            var input = new INPUT();
            input.type = InputType.MOUSE;

            input.U.mi.dwFlags = MOUSEEVENTF.WHEEL;
            input.U.mi.mouseData = amount;

            inputs.Add(input);
            return this;
        }

        /// <summary>
        /// positive : right , negative: left.
        /// one wheel click = 120
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public InputSequencer mouseWheelHorizontal(int amount)
        {
            var input = new INPUT();
            input.type = InputType.MOUSE;

            input.U.mi.dwFlags = MOUSEEVENTF.HWHEEL;
            input.U.mi.mouseData = amount;

            inputs.Add(input);
            return this;
        }

        /// <summary>
        /// <para>absolute mode - dx,dy range is : 0..1 , and mapped to the main display coords</para>
        /// <para>virtual desktop mode - dx,dy range is : 0..1 , and mapped to the entire desktop coords</para>
        /// <para>relative mode - dx,dy are in pixels, relative to the previous mouse position</para>
        /// </summary>
        /// <param name="moveType"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public InputSequencer mouseMove(MouseMoveType moveType, float dx, float dy)
        {
            var input = new INPUT();
            input.type = InputType.MOUSE;

            input.U.mi.dwFlags = MOUSEEVENTF.MOVE;

            switch (moveType)
            {
                case MouseMoveType.RELATIVE:
                    input.U.mi.dwFlags |= 0;
                    input.U.mi.dx = (int)(Math.Round(dx));
                    input.U.mi.dy = (int)(Math.Round(dy));

                    break;
                case MouseMoveType.ABSOLUTE:
                    //map x,y from 0..1 to 0..65535:
                    input.U.mi.dx = (int)(ushort.MaxValue * Math.Min(1f, Math.Max(0f, dx)));
                    input.U.mi.dy = (int)(ushort.MaxValue * Math.Min(1f, Math.Max(0f, dy)));
                    input.U.mi.dwFlags |= MOUSEEVENTF.ABSOLUTE;
                    break;
                case MouseMoveType.VIRTUAL_DESKTOP:
                    //map x,y from 0..1 to 0..65535:
                    input.U.mi.dx = (int)(ushort.MaxValue * Math.Min(1f, Math.Max(0f, dx)));
                    input.U.mi.dy = (int)(ushort.MaxValue * Math.Min(1f, Math.Max(0f, dy)));
                    input.U.mi.dwFlags |= MOUSEEVENTF.VIRTUALDESK;
                    break;
            }

            inputs.Add(input);

            return this;
        }

        // -------------------------------------------------------------------
        // HARDWARE
        // -------------------------------------------------------------------
        public InputSequencer hardwareMsg(int uMsg, short wParamL, short wParamH)
        {
            var input = new INPUT();
            input.type = InputType.HARDWARE;

            input.U.hi.uMsg = uMsg;
            input.U.hi.wParamL = wParamL;
            input.U.hi.wParamH = wParamH;

            inputs.Add(input);
            return this;
        }
    }
}