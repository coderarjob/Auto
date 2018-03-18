using System;
using static System.Threading.Thread;
using static omnirover.auto.Win32API;
using omnirover.auto;
namespace omnirover.auto.Operations
{
    public class WriteOperation : BaseOperation
    {
        public override string Name => "Write";
        public override string OperationString {
            get {
                return string.Format("Writes: '{0}' To control: ID={1}, Index:{2}, Window: '{3}'",
                    Arguments[0], Control.ControlID, Control.Index, Control.WindowTitle);
            }
        }

        private struct SpecialChar
        {
            public Int16 VK;
            public char SymbolChar;
            public SpecialChar(Int16 vk,char sym)
            {
                this.VK = vk;
                this.SymbolChar = sym;
            }

            public static SpecialChar Invalid = new SpecialChar(0,' ');
            public static bool operator ==(SpecialChar a, SpecialChar b)
            {
                return (a.VK == b.VK && a.SymbolChar == b.SymbolChar);
            }

            public static bool operator !=(SpecialChar a, SpecialChar b)
            {
                return (a.VK != b.VK || a.SymbolChar != b.SymbolChar);
            }
        }

        private SpecialChar[] SpecialChars = { new SpecialChar((Int16)VirtualKeys.VK_CTRL,'^'),
                                               new SpecialChar((Int16)VirtualKeys.VK_SHIFT,'+'),
                                               new SpecialChar((Int16)VirtualKeys.VK_ALT,'%'),
                                               new SpecialChar((Int16)VirtualKeys.VK_ENTER,'~')};
        public override void Execute()
        {
            IntPtr parentHandle;
            IntPtr controlHandle = Control.GetControlHandle(out parentHandle);
            char[] cs = Arguments[0].ToCharArray();

            bool isUnderSpecialCharMode = false;
            SpecialChar current_sc = SpecialChar.Invalid;

            foreach (char c in cs)
            {
                bool isWhiteSpace = false;
                bool isSpecialChar = false;
                SpecialChar sc = SpecialChar.Invalid;

                sc = getSpecialCharecter(c);
                isSpecialChar = (sc != SpecialChar.Invalid);

                if ((isUnderSpecialCharMode && c == '{') ||
                    (isUnderSpecialCharMode && isSpecialChar))
                        isWhiteSpace = true;

                if (isUnderSpecialCharMode == false && isSpecialChar)
                {
                    current_sc = sc;
                    isUnderSpecialCharMode = true;
                    Console.WriteLine("Entering special charecter");
                }

                if (isUnderSpecialCharMode)
                {

                    if (isWhiteSpace)
                        continue;
                    else if (isSpecialChar)
                    {
                        Console.WriteLine($"Sending special char: {current_sc.VK.ToString("X")}");
                        SendKey(current_sc.VK, false);
                    }
                    else if (c == '}')
                    {
                        SendKey(current_sc.VK, true);
                        isUnderSpecialCharMode = false;
                        Console.WriteLine($"Releasing special char: {current_sc.VK.ToString("X")}");
                    }
                    else if (char.IsLetterOrDigit(c))
                    {
                        char uc = char.ToUpper(c);
                        Console.WriteLine($"[{uc}]");
                        SendKey(uc, false);
                        SendKey(uc, true);
                    }
                }
                else
                {
                    Console.WriteLine($"{c}");
                    SendMessage(controlHandle, WM_CHAR, c, 1);
                }
            }   
            
            if (isUnderSpecialCharMode)
            {
                SendKey(current_sc.VK, true);
                Console.WriteLine($"Releasing special char: {current_sc.VK.ToString("X")}");
            }
        }

        public WriteOperation(ControlIdentity control, string[] args) : base(control, args) { }

        private SpecialChar getSpecialCharecter(char c)
        {
            foreach (SpecialChar sc in SpecialChars)
                if (sc.SymbolChar == c)
                    return sc;
            return SpecialChar.Invalid;
        }
    }
}
