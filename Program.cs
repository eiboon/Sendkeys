
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SendKeys
{
    class Program
    {


        const uint VK_LBUTTON =  0x01;	//Left mouse button
        const uint VK_RBUTTON =	0x02;	//Right mouse button
        const uint VK_CANCEL	=   0x03;   //Control-break processing
        const uint VK_MBUTTON =	0x04;	//Middle mouse button(three-button mouse)
        const uint VK_XBUTTON1 =	0x05;	//X1 mouse button
        const uint VK_XBUTTON2 =	0x06;	//X2 mouse button
        const uint VK_BACK =     0x08;	//BACKSPACE key
        const uint VK_TAB =	    0x09;	//TAB key
        const uint VK_CLEAR =	0x0C;	///CLEAR key
        const uint VK_RETURN =	0x0D;	//ENTER key
        const uint VK_SHIFT =	0x10;	//SHIFT key
        const uint VK_CONTROL =	0x11;	//CTRL key
        const uint VK_MENU =	    0x12;	//ALT key
        const uint VK_PAUSE =	0x13;	//PAUSE key
        const uint VK_CAPITAL =	0x14;	//CAPS LOCK key
        const uint VK_KANA =	    0x15;	//IME Kana mode
        const uint VK_HANGUEL =	0x15;	//IME Hanguel mode(maintained for compatibility; use VK_HANGUL)
        const uint VK_HANGUL =	0x15;	//IME Hangul mode
        const uint VK_IME_ON =	0x16;	//IME On
        const uint VK_JUNJA =	0x17;	//IME Junja mode
        const uint VK_FINAL =	0x18;	//IME final mode
        const uint VK_HANJA =	0x19;	//IME Hanja mode
        const uint VK_KANJI =	0x19;	//IME Kanji mode
        const uint VK_IME_OFF =	0x1A;	//IME Off
        const uint VK_ESCAPE =	0x1B;	//ESC key
        const uint VK_CONVERT =	0x1C;	//IME convert
        const uint VK_NONCONVERT =0x1D;	//IME nonconvert
        const uint VK_ACCEPT =   0x1E;	//IME accept
        const uint VK_MODECHANGE =0x1F;	//IME mode change request
        const uint VK_SPACE =	0x20;	//SPACEBAR
        const uint VK_PRIOR =	0x21;	//PAGE UP key
        const uint VK_NEXT =	    0x22;	//PAGE DOWN key
        const uint VK_END =	    0x23;	//END key
        const uint VK_HOME =	    0x24;	//HOME key
        const uint VK_LEFT =	    0x25;	//LEFT ARROW key
        const uint VK_UP =	    0x26;	//UP ARROW key
        const uint VK_RIGHT =	0x27;	//RIGHT ARROW key
        const uint VK_DOWN =	    0x28;	//DOWN ARROW key
        const uint VK_SELECT =	0x29;	//SELECT key
        const uint VK_PRINT =	0x2A;	//PRINT key
        const uint VK_EXECUTE =	0x2B;	//EXECUTE key
        const uint VK_SNAPSHOT =	0x2C;	//PRINT SCREEN key
        const uint VK_INSERT =	0x2D;	//INS key
        const uint VK_DELETE	=   0x2E;	//DEL key
        const uint VK_HELP =	    0x2F;	//HELP key
        const uint VK_LCONTROL =	0xA2;	//Left CONTROL key
        const uint VK_THREE =       0x33;	//3 key
        const uint VK_FOUR =        0x34;	//4 key
        const uint VK_NUMPAD3 =	    0x63;   //num3
        const uint VK_T =           0x54;   // T key

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);



        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        static uint KEYEVENTF_KEYUP = 0x0002;
        static uint KEYEVENTF_KEYDOWN = 0x00020;

        static public void SendKeys(uint key,uint keyEvent, int keyWait)
        {
            keybd_event((byte)key, 0, keyEvent, IntPtr.Zero);
            System.Threading.Thread.Sleep(keyWait);
        }

        static void Main(string[] args)
        {
            IntPtr hwnd = FindWindow(new IntPtr(), "Battlefield­­™ 2042");
            string window = null;
            DateTime timeout = DateTime.Now.AddMinutes(2);
            while ((hwnd == new IntPtr()) && (DateTime.Now < timeout)) { 

                foreach (var p in Process.GetProcesses())
                {
                    if (p.ProcessName.Contains("BF2042")){
                        hwnd = p.MainWindowHandle;
                        break;
     
                    }
                }
            }
            if (hwnd == new IntPtr())
                return;
            //Set window and wait to activate

            //Loop our AFK grind
            while (true) 
            {
                //Set window and wait to activate
                SetForegroundWindow(hwnd);
                System.Threading.Thread.Sleep(3000);
                Program.SendKeys(VK_NUMPAD3,KEYEVENTF_KEYDOWN,256);
                Program.SendKeys(VK_NUMPAD3,KEYEVENTF_KEYUP,200);
                Program.SendKeys(VK_LCONTROL,KEYEVENTF_KEYDOWN,256);
                Program.SendKeys(VK_LCONTROL,KEYEVENTF_KEYUP,200);
                Program.SendKeys(VK_T,KEYEVENTF_KEYDOWN,2056);
                Program.SendKeys(VK_FOUR,KEYEVENTF_KEYDOWN,256);
                Program.SendKeys(VK_FOUR,KEYEVENTF_KEYUP,200);
                Program.SendKeys(VK_T,KEYEVENTF_KEYUP,200);
                System.Threading.Thread.Sleep(30000);
                if (Process.GetProcessesByName("BF2042").Length == 0)
                    return;
            }
        }
    }
}
