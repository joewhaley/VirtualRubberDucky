using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsInput.Native
{
    /// <summary>
    /// The list of DirectInput keyboard scan codes from dinput.h in dxsdk
    /// </summary>
    public enum DirectInputKeyCode
    {
        /// <summary>
        /// Escape key
        /// </summary>
        DIK_ESCAPE = 0x01,
        /// <summary>
        /// '1' key on main keyboard
        /// </summary>
        DIK_1 = 0x02,
        /// <summary>
        /// '2' key on main keyboard
        /// </summary>
        DIK_2 = 0x03,
        /// <summary>
        /// '3' key on main keyboard
        /// </summary>
        DIK_3 = 0x04,
        /// <summary>
        /// '4' key on main keyboard
        /// </summary>
        DIK_4 = 0x05,
        /// <summary>
        /// '5' key on main keyboard
        /// </summary>
        DIK_5 = 0x06,
        /// <summary>
        /// '6' key on main keyboard
        /// </summary>
        DIK_6 = 0x07,
        /// <summary>
        /// '7' key on main keyboard
        /// </summary>
        DIK_7 = 0x08,
        /// <summary>
        /// '8' key on main keyboard
        /// </summary>
        DIK_8 = 0x09,
        /// <summary>
        /// '9' key on main keyboard
        /// </summary>
        DIK_9 = 0x0A,
        /// <summary>
        /// '0' key on main keyboard
        /// </summary>
        DIK_0 = 0x0B,
        /// <summary>
        /// '-' key on main keyboard
        /// </summary>
        DIK_MINUS = 0x0C,
        /// <summary>
        /// '=' key
        /// </summary>
        DIK_EQUALS = 0x0D,
        /// <summary>
        /// Backspace key
        /// </summary>
        DIK_BACK = 0x0E,
        /// <summary>
        /// Tab key
        /// </summary>
        DIK_TAB = 0x0F,
        /// <summary>
        /// 'q' key
        /// </summary>
        DIK_Q = 0x10,
        /// <summary>
        /// 'w' key
        /// </summary>
        DIK_W = 0x11,
        /// <summary>
        /// 'e' key
        /// </summary>
        DIK_E = 0x12,
        /// <summary>
        /// 'r' key
        /// </summary>
        DIK_R = 0x13,
        /// <summary>
        /// 't' key
        /// </summary>
        DIK_T = 0x14,
        /// <summary>
        /// 'y' key
        /// </summary>
        DIK_Y = 0x15,
        /// <summary>
        /// 'u' key
        /// </summary>
        DIK_U = 0x16,
        /// <summary>
        /// 'i' key
        /// </summary>
        DIK_I = 0x17,
        /// <summary>
        /// 'o' key
        /// </summary>
        DIK_O = 0x18,
        /// <summary>
        /// 'p' key
        /// </summary>
        DIK_P = 0x19,
        /// <summary>
        /// '[' key???
        /// </summary>
        DIK_LBRACKET = 0x1A,
        /// <summary>
        /// ']' key???
        /// </summary>
        DIK_RBRACKET = 0x1B,
        /// <summary>
        /// 'enter' key on main keyboard
        /// </summary>
        DIK_RETURN = 0x1C,
        /// <summary>
        /// Left control key
        /// </summary>
        DIK_LCONTROL = 0x1D,
        /// <summary>
        /// 'a' key
        /// </summary>
        DIK_A = 0x1E,
        /// <summary>
        /// 's' key
        /// </summary>
        DIK_S = 0x1F,
        /// <summary>
        /// 'd' key
        /// </summary>
        DIK_D = 0x20,
        /// <summary>
        /// 'f' key
        /// </summary>
        DIK_F = 0x21,
        /// <summary>
        /// 'g' key
        /// </summary>
        DIK_G = 0x22,
        /// <summary>
        /// 'h' key
        /// </summary>
        DIK_H = 0x23,
        /// <summary>
        /// 'j' key
        /// </summary>
        DIK_J = 0x24,
        /// <summary>
        /// 'k' key
        /// </summary>
        DIK_K = 0x25,
        /// <summary>
        /// 'l' key
        /// </summary>
        DIK_L = 0x26,
        /// <summary>
        /// ';' key
        /// </summary>
        DIK_SEMICOLON = 0x27,
        /// <summary>
        /// ' key
        /// </summary>
        DIK_APOSTROPHE = 0x28,
        /// <summary>
        /// '`' key (Accent grave)
        /// </summary>
        DIK_GRAVE = 0x29,
        /// <summary>
        /// Left shift key
        /// </summary>
        DIK_LSHIFT = 0x2A,
        /// <summary>
        /// '\' key
        /// </summary>
        DIK_BACKSLASH = 0x2B,
        /// <summary>
        /// 'z' key
        /// </summary>
        DIK_Z = 0x2C,
        /// <summary>
        /// 'x' key
        /// </summary>
        DIK_X = 0x2D,
        /// <summary>
        /// 'c' key
        /// </summary>
        DIK_C = 0x2E,
        /// <summary>
        /// 'v' key
        /// </summary>
        DIK_V = 0x2F,
        /// <summary>
        /// 'b' key
        /// </summary>
        DIK_B = 0x30,
        /// <summary>
        /// 'n' key
        /// </summary>
        DIK_N = 0x31,
        /// <summary>
        /// 'm' key
        /// </summary>
        DIK_M = 0x32,
        /// <summary>
        /// ',' key
        /// </summary>
        DIK_COMMA = 0x33,
        /// <summary>
        /// '.' key on main keyboard
        /// </summary>
        DIK_PERIOD = 0x34,
        /// <summary>
        /// '/' key on main keyboard
        /// </summary>
        DIK_SLASH = 0x35,
        /// <summary>
        /// Right shift key
        /// </summary>
        DIK_RSHIFT = 0x36,
        /// <summary>
        /// '*' key on numeric keypad
        /// </summary>
        DIK_MULTIPLY = 0x37,
        /// <summary>
        /// Left alt key
        /// </summary>
        DIK_LMENU = 0x38,
        /// <summary>
        /// ' ' key
        /// </summary>
        DIK_SPACE = 0x39,
        /// <summary>
        /// Caps lock key
        /// </summary>
        DIK_CAPITAL = 0x3A,
        /// <summary>
        /// 'F1' key
        /// </summary>
        DIK_F1 = 0x3B,
        /// <summary>
        /// 'F2' key
        /// </summary>
        DIK_F2 = 0x3C,
        /// <summary>
        /// 'F3' key
        /// </summary>
        DIK_F3 = 0x3D,
        /// <summary>
        /// 'F4' key
        /// </summary>
        DIK_F4 = 0x3E,
        /// <summary>
        /// 'F5' key
        /// </summary>
        DIK_F5 = 0x3F,
        /// <summary>
        /// 'F6' key
        /// </summary>
        DIK_F6 = 0x40,
        /// <summary>
        /// 'F7' key
        /// </summary>
        DIK_F7 = 0x41,
        /// <summary>
        /// 'F8' key
        /// </summary>
        DIK_F8 = 0x42,
        /// <summary>
        /// 'F9' key
        /// </summary>
        DIK_F9 = 0x43,
        /// <summary>
        /// 'F10' key
        /// </summary>
        DIK_F10 = 0x44,
        /// <summary>
        /// Numlock key
        /// </summary>
        DIK_NUMLOCK = 0x45,
        /// <summary>
        /// Scroll lock key
        /// </summary>
        DIK_SCROLL = 0x46    /* Scroll Lock */,
        /// <summary>
        /// '7' key on numeric keypad
        /// </summary>
        DIK_NUMPAD7 = 0x47,
        /// <summary>
        /// '8' key on numeric keypad
        /// </summary>
        DIK_NUMPAD8 = 0x48,
        /// <summary>
        /// '9' key on numeric keypad
        /// </summary>
        DIK_NUMPAD9 = 0x49,
        /// <summary>
        /// '-' key on numeric keypad
        /// </summary>
        DIK_SUBTRACT = 0x4A,
        /// <summary>
        /// '4' key on numeric keypad
        /// </summary>
        DIK_NUMPAD4 = 0x4B,
        /// <summary>
        /// '5' key on numeric keypad
        /// </summary>
        DIK_NUMPAD5 = 0x4C,
        /// <summary>
        /// '6' key on numeric keypad
        /// </summary>
        DIK_NUMPAD6 = 0x4D,
        /// <summary>
        /// '+' key on numeric keypad
        /// </summary>
        DIK_ADD = 0x4E,
        /// <summary>
        /// '1' key on numeric keypad
        /// </summary>
        DIK_NUMPAD1 = 0x4F,
        /// <summary>
        /// '2' key on numeric keypad
        /// </summary>
        DIK_NUMPAD2 = 0x50,
        /// <summary>
        /// '3' key on numeric keypad
        /// </summary>
        DIK_NUMPAD3 = 0x51,
        /// <summary>
        /// '0' key on numeric keypad
        /// </summary>
        DIK_NUMPAD0 = 0x52,
        /// <summary>
        /// '.' key on numeric keypad
        /// </summary>
        DIK_DECIMAL = 0x53,
        /// <summary>
        /// PrintScreen key
        /// </summary>
        DIK_PRINTSCREEN = 0x54,
        /// <summary>
        /// &lt;&gt; or \| on RT 102-key keyboard (Non-U.S.)
        /// </summary>
        DIK_OEM_102 = 0x56,
        /// <summary>
        /// 'F11' key
        /// </summary>
        DIK_F11 = 0x57,
        /// <summary>
        /// 'F12' key
        /// </summary>
        DIK_F12 = 0x58,
        /// <summary>
        /// 'F12' key
        /// </summary>
        DIK_NUMERIC_5 = 0x59,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xEE)
        /// </summary>
        DIK_OEM_EE = 0x5A,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF1)
        /// </summary>
        DIK_OEM_F1 = 0x5B,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF1)
        /// </summary>
        DIK_OEM_EA = 0x5C,
        /// <summary>
        /// Erase EOF key
        /// </summary>
        DIK_ERASE_EOF = 0x5D,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF5)
        /// </summary>
        DIK_OEM_F5 = 0x5E,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xF3)
        /// </summary>
        DIK_OEM_F3 = 0x5F,
        /// <summary>
        /// 'Zoom' key
        /// </summary>
        DIK_ZOOM = 0x62,
        /// <summary>
        /// 'HELP' key
        /// </summary>
        DIK_HELP = 0x63,
        /// <summary>
        /// 'F13' key (NEC PC98)
        /// </summary>
        DIK_F13 = 0x64,
        /// <summary>
        /// 'F14' key (NEC PC98)
        /// </summary>
        DIK_F14 = 0x65,
        /// <summary>
        /// 'F15' key (NEC PC98)
        /// </summary>
        DIK_F15 = 0x66,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F16 = 0x67,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F17 = 0x68,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F18 = 0x69,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F19 = 0x6A,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F20 = 0x6B,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F21 = 0x6C,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F22 = 0x6D,
        /// <summary>
        /// 'F16' key
        /// </summary>
        DIK_F23 = 0x6E,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xED)
        /// </summary>
        DIK_OEM_ED = 0x6F,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DIK_KANA = 0x70,
        /// <summary>
        /// OEM key (VirtualKeyCode 0xE9)
        /// </summary>
        DIK_OEM_E9 = 0x71,
        /// <summary>
        /// /? on Brazilian keyboard
        /// </summary>
        DIK_ABNT_C1 = 0x73,
        /// <summary>
        /// F24 key
        /// </summary>
        DIK_F24 = 0x76,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DIK_CONVERT = 0x79,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DIK_NOCONVERT = 0x7B,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DIK_YEN = 0x7D,
        /// <summary>
        /// Numpad . on Brazilian keyboard
        /// </summary>
        DIK_ABNT_C2 = 0x7E,
        /// <summary>
        /// '=' on numeric keypad (NEC PC98)
        /// </summary>
        DIK_NUMPADEQUALS = 0x8D,
        /// <summary>
        /// Previous Track key (DIK_CIRCUMFLEX on Japanese keyboard)
        /// </summary>
        DIK_PREVTRACK = 0x90,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DIK_AT = 0x91,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DIK_COLON = 0x92,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DIK_UNDERLINE = 0x93,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DIK_KANJI = 0x94,
        /// <summary>
        /// NEC PC98
        /// </summary>
        DIK_STOP = 0x95,
        /// <summary>
        /// Japan AX
        /// </summary>
        DIK_AX = 0x96,
        /// <summary>
        /// J3100
        /// </summary>
        DIK_UNLABELED = 0x97,
        /// <summary>
        /// Next Track key
        /// </summary>
        DIK_NEXTTRACK = 0x99,
        /// <summary>
        /// Enter key on numeric keypad
        /// </summary>
        DIK_NUMPADENTER = 0x9C,
        /// <summary>
        /// Right control key
        /// </summary>
        DIK_RCONTROL = 0x9D,
        /// <summary>
        /// Mute key
        /// </summary>
        DIK_MUTE = 0xA0,
        /// <summary>
        /// Calculator key
        /// </summary>
        DIK_CALCULATOR = 0xA1,
        /// <summary>
        /// Play/Pause key
        /// </summary>
        DIK_PLAYPAUSE = 0xA2,
        /// <summary>
        /// Media Stop key
        /// </summary>
        DIK_MEDIASTOP = 0xA4,
        /// <summary>
        /// Volume down key
        /// </summary>
        DIK_VOLUMEDOWN = 0xAE,
        /// <summary>
        /// Volume up key
        /// </summary>
        DIK_VOLUMEUP = 0xB0,
        /// <summary>
        /// Web home key
        /// </summary>
        DIK_WEBHOME = 0xB2,
        /// <summary>
        /// ',' key on numeric keypad
        /// </summary>
        DIK_NUMPADCOMMA = 0xB3,
        /// <summary>
        /// '/' key on numeric keypad
        /// </summary>
        DIK_DIVIDE = 0xB5,
        /// <summary>
        /// ???
        /// </summary>
        DIK_SYSRQ = 0xB7,
        /// <summary>
        /// Right alt key
        /// </summary>
        DIK_RMENU = 0xB8,
        /// <summary>
        /// Pause key
        /// </summary>
        DIK_PAUSE = 0xC5,
        /// <summary>
        /// Home key on arrow keypad
        /// </summary>
        DIK_HOME = 0xC7,
        /// <summary>
        /// Up arrow key on arrow keypad
        /// </summary>
        DIK_UP = 0xC8,
        /// <summary>
        /// PageUp key on arrow keypad
        /// </summary>
        DIK_PRIOR = 0xC9,
        /// <summary>
        /// Left arrow key on arrow keypad
        /// </summary>
        DIK_LEFT = 0xCB,
        /// <summary>
        /// Right arrow key on arrow keypad
        /// </summary>
        DIK_RIGHT = 0xCD,
        /// <summary>
        /// End key on arrow keypad
        /// </summary>
        DIK_END = 0xCF,
        /// <summary>
        /// Down arrow key on arrow keypad
        /// </summary>
        DIK_DOWN = 0xD0,
        /// <summary>
        /// PageDown key on arrow keypad
        /// </summary>
        DIK_NEXT = 0xD1,
        /// <summary>
        /// Insert key on arrow keypad
        /// </summary>
        DIK_INSERT = 0xD2,
        /// <summary>
        /// Delete key on arrow keypad
        /// </summary>
        DIK_DELETE = 0xD3,
        /// <summary>
        /// Left Windows key
        /// </summary>
        DIK_LWIN = 0xDB,
        /// <summary>
        /// Right Windows key
        /// </summary>
        DIK_RWIN = 0xDC,
        /// <summary>
        /// AppMenu key
        /// </summary>
        DIK_APPS = 0xDD,
        /// <summary>
        /// System power key
        /// </summary>
        DIK_POWER = 0xDE,
        /// <summary>
        /// System sleep key
        /// </summary>
        DIK_SLEEP = 0xDF,
        /// <summary>
        /// System wake key
        /// </summary>
        DIK_WAKE = 0xE3,
        /// <summary>
        /// Web search key
        /// </summary>
        DIK_WEBSEARCH = 0xE5,
        /// <summary>
        /// Web favorites key
        /// </summary>
        DIK_WEBFAVORITES = 0xE6,
        /// <summary>
        /// Web refresh key
        /// </summary>
        DIK_WEBREFRESH = 0xE7,
        /// <summary>
        /// Web stop key
        /// </summary>
        DIK_WEBSTOP = 0xE8,
        /// <summary>
        /// Web forward key
        /// </summary>
        DIK_WEBFORWARD = 0xE9,
        /// <summary>
        /// Web back key
        /// </summary>
        DIK_WEBBACK = 0xEA,
        /// <summary>
        /// My computer key
        /// </summary>
        DIK_MYCOMPUTER = 0xEB,
        /// <summary>
        /// Mail key
        /// </summary>
        DIK_MAIL = 0xEC,
        /// <summary>
        /// Media select
        /// </summary>
        DIK_MEDIASELECT = 0xED,
        /// <summary>
        /// PageUp key on arrow keypad
        /// </summary>
        DIK_PAGE_UP = DIK_PRIOR,
        /// <summary>
        /// PageDown key on arrow keypad
        /// </summary>
        DIK_PAGE_DOWN = DIK_NEXT,
        /// <summary>
        /// Backspace key
        /// </summary>
        DIK_BACKSPACE = DIK_BACK,
        /// <summary>
        /// '*' key on numeric keypad
        /// </summary>
        DIK_NUMPAD_STAR = DIK_MULTIPLY,
        /// <summary>
        /// Left alt key
        /// </summary>
        DIK_LALT = DIK_LMENU,
        /// <summary>
        /// Caps lock key
        /// </summary>
        DIK_CAPSLOCK = DIK_CAPITAL,
        /// <summary>
        /// '-' key on numeric keypad
        /// </summary>
        DIK_NUMPAD_MINUS = DIK_SUBTRACT,
        /// <summary>
        /// '+' key on numeric keypad
        /// </summary>
        DIK_NUMPAD_PLUS = DIK_ADD,
        /// <summary>
        /// '.' key on numeric keypad
        /// </summary>
        DIK_NUMPAD_PERIOD = DIK_DECIMAL,
        /// <summary>
        /// '/' key on numeric keypad
        /// </summary>
        DIK_NUMPAD_SLASH = DIK_DIVIDE,
        /// <summary>
        /// Right alt key
        /// </summary>
        DIK_RALT = DIK_RMENU,
        /// <summary>
        /// Up arrow key on arrow keypad
        /// </summary>
        DIK_UPARROW = DIK_UP,
        /// <summary>
        /// PageUp key on arrow keypad
        /// </summary>
        DIK_PGUP = DIK_PRIOR,
        /// <summary>
        /// Left arrow key on arrow keypad
        /// </summary>
        DIK_LEFTARROW = DIK_LEFT,
        /// <summary>
        /// Right arrow key on arrow keypad
        /// </summary>
        DIK_RIGHTARROW = DIK_RIGHT,
        /// <summary>
        /// Down arrow key on arrow keypad
        /// </summary>
        DIK_DOWNARROW = DIK_DOWN,
        /// <summary>
        /// PageDown key on arrow keypad
        /// </summary>
        DIK_PGDN = DIK_NEXT,
        /// <summary>
        /// Japanese keyboard
        /// </summary>
        DIK_CIRCUMFLEX = DIK_PREVTRACK,
    }
}
