    using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proyecto_IPO1s
{
    public class ReglaRangoLongitudCaracteres : ValidationRule
    {
        public int MinimoCaracteres { set; get; }
        public int MaximoCaracteres { set; get; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int longitud = ((string)value).Length;
            if ((longitud < MinimoCaracteres) || (longitud > MaximoCaracteres))
                return new ValidationResult(false, "Longitud: " +
                MinimoCaracteres.ToString() + "-" + MaximoCaracteres.ToString() + " dígitos"); return new ValidationResult(true, null);
        }
    }
}
