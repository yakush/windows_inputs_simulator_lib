using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApplication1.SendInputWrapper;

namespace ConsoleApplication1
{
    public class SendInput
    {
        private List<InputCommand> inputCommands = new List<InputCommand>();


        public SendInput command(InputCommand command)
        {
            inputCommands.Add(command);
            return this;
        }

        public uint execute()
        {
            INPUT[] inputs = new INPUT[inputCommands.Count];

            for (int i = 0; i < inputCommands.Count; i++)
            {
                var command = inputCommands[i];

                INPUT input = command.toInput();
            }

            return SendInput(4, inputs, INPUT.Size);
        }


        // -------------------------------------------------------------------
        // -------------------------------------------------------------------
        public abstract class InputCommand
        {
            public abstract INPUT toInput();
        }

        public class MouseCommand : InputCommand
        {
            public enum MoveType
            {
                RELATIVE,
                ABSOLUTE,
                VIRTUAL_DESKTOP
            }

            public override INPUT toInput()
            {
                INPUT input = new INPUT();
                input.type = InputType.MOUSE;
                return input;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x">0..1</param>
            /// <param name="y">0..1</param>
            /// <param name="movetype"></param>
            /// <returns></returns>
            public MouseCommand createMove(float x, float y, MoveType movetype)
            {
                var res = new MouseCommand();
                return res;
            }

            public MouseCommand createButton(bool down = true)
            {
                var res = new MouseCommand();
                return res;
            }

            public MouseCommand screateWheel(int amount)
            {
                var res = new MouseCommand();
                return res;
            }

            public MouseCommand screateWheelHorizontal(int amount)
            {
                var res = new MouseCommand();
                return res;
            }


        }

        public class KeyboardCommand : InputCommand
        {
            private enum KeyType
            {
                VIRTUAL_KEY,
                SCAN,
                UNICODE
            }

            private KeyType keyType = KeyType.SCAN;
            private VirtualKeyShort vk;
            private ScanCodeShort scanKey;
            private bool keyDown = true;
            private bool scanExtendedKey;

            private KeyboardCommand()
            {
            }

            public override INPUT toInput()
            {
                INPUT input = new INPUT();
                input.type = InputType.KEYBOARD;

                switch (keyType)
                {
                    case KeyType.VIRTUAL_KEY:
                        {
                            input.U.ki.dwFlags |= (keyDown ? 0 : KEYEVENTF.KEYUP);
                            input.U.ki.wVk = vk;
                        }
                        break;
                    case KeyType.SCAN:
                        {
                            input.U.ki.dwFlags |= (keyDown ? 0 : KEYEVENTF.KEYUP);
                            input.U.ki.dwFlags |= (KEYEVENTF.SCANCODE);
                            input.U.ki.dwFlags |= (scanExtendedKey ? KEYEVENTF.SCANCODE : 0);
                            input.U.ki.wScan = scanKey;
                            input.U.ki.wVk = 0;
                        }
                        break;
                    case KeyType.UNICODE:
                        {
                            input.U.ki.dwFlags |= KEYEVENTF.KEYUP;
                            input.U.ki.dwFlags |= (KEYEVENTF.UNICODE);
                            input.U.ki.dwFlags |= (scanExtendedKey ? KEYEVENTF.SCANCODE : 0);
                            input.U.ki.wScan = scanKey;
                            input.U.ki.wVk = 0;
                        }
                        break;
                }

                return input;
            }

            public KeyboardCommand createVirtualKey(VirtualKeyShort vk, bool keyDown = true)
            {
                var res = new KeyboardCommand();
                res.keyType = KeyType.VIRTUAL_KEY;
                res.vk = vk;
                res.keyDown = keyDown;
                return res;
            }

            public KeyboardCommand createScanKey(ScanCodeShort scanKey, bool extendedKey = false, bool keyDown = true)
            {
                var res = new KeyboardCommand();
                res.keyType = KeyType.SCAN;
                res.scanKey = scanKey;
                res.scanExtendedKey = extendedKey;
                res.keyDown = keyDown;
                return res;
            }

            public KeyboardCommand createUnicodeKey(ScanCodeShort unicode)
            {
                var res = new KeyboardCommand();
                res.keyType = KeyType.UNICODE;
                res.scanKey = unicode;
                res.keyDown = false;
                return res;
            }
        }

        public class HardwareCommand : InputCommand
        {
            public int uMsg { get; set; }
            public short wParamL { get; set; }
            public short wParamH { get; set; }


            public HardwareCommand(int uMsg, short wParamL, short wParamH)
            {
                this.uMsg = uMsg;
                this.wParamL = wParamL;
                this.wParamH = wParamH;
            }

            public override INPUT toInput()
            {
                INPUT input = new INPUT();
                input.type = InputType.HARDWARE;
                input.U.hi.uMsg = uMsg;
                input.U.hi.wParamL = wParamL;
                input.U.hi.wParamH = wParamH;

                return input;
            }
        }
    }
}