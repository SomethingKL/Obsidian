using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal
{
    static class Stale
    {
        public static string Version = "Andesite [version 1.0.0]";
        public static string Author = "(c) Ross Brandt. All rights reserved.";

        public static Keys[] ValidKeys = {
            Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5,
            Keys.D6, Keys.D7, Keys.D8, Keys.D9,
            Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3,
            Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7,
            Keys.NumPad8, Keys.NumPad9,
            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G,
            Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N,
            Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U,
            Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z,
            Keys.OemQuestion, Keys.Oemcomma, Keys.OemPeriod, Keys.OemQuotes,
            Keys.OemOpenBrackets, Keys.OemCloseBrackets, Keys.OemBackslash,
            Keys.OemMinus, Keys.Subtract, Keys.Oemplus, Keys.Add, Keys.Oemtilde,
            Keys.Divide, Keys.Multiply, Keys.OemSemicolon, Keys.Oem5
        };
    }
}
