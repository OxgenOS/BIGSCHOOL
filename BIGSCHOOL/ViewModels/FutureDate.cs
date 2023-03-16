using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BIGSCHOOL.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override CultureInfo IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value)),
                "dd/M/yyy",
                CultureInfo.CurrentCulture ,
                DateTimeStyles.None,
                out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }
}