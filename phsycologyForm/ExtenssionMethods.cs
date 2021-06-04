using System;
using System.Drawing;
using System.Linq;

namespace phsycologyForm
{
    internal static class ExtenssionMethods
    {
        public static Color FromHex(this string hex) =>
            ColorTranslator.FromHtml(hex);
    }
}
