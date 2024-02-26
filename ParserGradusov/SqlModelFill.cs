using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserGradusov
{
    public class SqlModelFill
    {
        public static FullLineUser FillSqlModel(string[] items, int i)
        {
            if (i == 5)
            {
                FullLineUser fullModel = new()
                {
                    Id = Convert.ToInt32(items[0]),
                    FIO = items[1],
                    Adress = items[2],
                    Period = items[3],
                    Sum = double.Parse(items[4], new NumberFormatInfo { NumberDecimalSeparator = "." }),
                    GasId = null,
                    GasMeterReads = null
                };
                return fullModel;
            }
            else
            {
                FullLineUser fullModel = new()
                {
                    Id = Convert.ToInt32(items[0]),
                    FIO = items[1],
                    Adress = items[2],
                    Period = items[3],
                    Sum = double.Parse(items[4], new NumberFormatInfo { NumberDecimalSeparator = "." }),
                    GasId = items[5],
                    GasMeterReads = double.Parse(items[6], new NumberFormatInfo { NumberDecimalSeparator = "." })
                };
                return fullModel;
            }
        }
    }
}
