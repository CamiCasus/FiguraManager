using System;

namespace Infrastructure.CrossCutting.Common
{
    public static class CommonUtils
    {
        #region numero to letra

        public static string ConvertirNumeroALetrasES(double cantidad)
        {

            string res, dec = "";

            Int64 entero;

            int decimales;

            entero = Convert.ToInt64(Math.Truncate(cantidad));

            decimales = Convert.ToInt32(Math.Round((cantidad - entero) * 100, 2));

            dec = " CON " + RellenarCadenaPorLaIzquierda(decimales.ToString(), '0', 2) + "/100";

            res = ToText(Convert.ToDouble(entero)) + " " + dec + " ";

            return res;

        }

        private static string RellenarCadenaPorLaIzquierda(string cadena, char relleno, int tamanio)
        {
            string cadenaRellenada = cadena;

            while (cadenaRellenada.Length < tamanio)
            {
                cadenaRellenada = relleno + cadenaRellenada;
            }
            return cadenaRellenada;
        }

        private static string ToText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            ToText01(value, ref Num2Text);
            return Num2Text;
        }

        private static void ToText01(double value, ref string Num2Text)
        {
            if (value == 0) Num2Text = "CERO";

            else if (value == 1) Num2Text = "UNO";

            else if (value == 2) Num2Text = "DOS";

            else if (value == 3) Num2Text = "TRES";

            else if (value == 4) Num2Text = "CUATRO";

            else if (value == 5) Num2Text = "CINCO";

            else if (value == 6) Num2Text = "SEIS";

            else if (value == 7) Num2Text = "SIETE";

            else if (value == 8) Num2Text = "OCHO";

            else if (value == 9) Num2Text = "NUEVE";

            else
                ToText02(value, ref Num2Text);
        }

        private static void ToText02(double value, ref string Num2Text)
        {
            if (value == 10) Num2Text = "DIEZ";

            else if (value == 11) Num2Text = "ONCE";

            else if (value == 12) Num2Text = "DOCE";

            else if (value == 13) Num2Text = "TRECE";

            else if (value == 14) Num2Text = "CATORCE";

            else if (value == 15) Num2Text = "QUINCE";

            else if (value < 20) Num2Text = "DIECI" + ToText(value - 10);

            else if (value == 20) Num2Text = "VEINTE";

            else
                ToText03(value, ref Num2Text);
        }

        private static void ToText03(double value, ref string Num2Text)
        {
            if (value < 30)
            {

                string segundaCifra;

                if ((value % 20).Equals(1))
                {

                    segundaCifra = "UN";

                }

                else
                {

                    segundaCifra = ToText(value % 20);

                }

                Num2Text = "VEINTI" + segundaCifra;

            }

            else if (value == 30) Num2Text = "TREINTA";

            else if (value == 40) Num2Text = "CUARENTA";

            else if (value == 50) Num2Text = "CINCUENTA";

            else if (value == 60) Num2Text = "SESENTA";

            else if (value == 70) Num2Text = "SETENTA";

            else if (value == 80) Num2Text = "OCHENTA";

            else if (value == 90) Num2Text = "NOVENTA";

            else
                ToText04(value, ref Num2Text);
        }

        private static void ToText04(double value, ref string Num2Text)
        {
            if (value < 100)
            {

                string segundaCifra;

                if ((value % 10).Equals(1))
                {

                    segundaCifra = "UN";

                }

                else
                {

                    segundaCifra = ToText(value % 10);

                }

                Num2Text = ToText(Math.Truncate(value / 10) * 10) + " Y " + segundaCifra;

            }

            else if (value == 100) Num2Text = "CIEN";

            else if (value < 200) Num2Text = "CIENTO " + ToText(value - 100);

            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = ToText(Math.Truncate(value / 100)) + "CIENTOS";

            else if (value == 500) Num2Text = "QUINIENTOS";

            else if (value == 700) Num2Text = "SETECIENTOS";

            else if (value == 900) Num2Text = "NOVECIENTOS";

            else if (value < 1000) Num2Text = ToText(Math.Truncate(value / 100) * 100) + " " + ToText(value % 100);

            else if (value == 1000) Num2Text = "MIL";

            else if (value < 2000) Num2Text = "MIL " + ToText(value % 1000);

            else ToText05(value, ref Num2Text);
        }

        private static void ToText05(double value, ref string Num2Text)
        {
            if (value < 1000000)
            {

                Num2Text = ToText(Math.Truncate(value / 1000)) + " MIL";

                if ((value % 1000) > 0)
                {

                    Num2Text = Num2Text + " " + ToText(value % 1000);

                }

            }

            else if (value == 1000000) Num2Text = "UN MILLON";

            else if (value < 2000000) Num2Text = "UN MILLON " + ToText(value % 1000000);

            else if (value < 1000000000000)
            {

                Num2Text = ToText(Math.Truncate(value / 1000000)) + " MILLONES ";

                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {

                    Num2Text = Num2Text + " " + ToText(value - Math.Truncate(value / 1000000) * 1000000);

                }

            }

            else if (value == 1000000000000)
            {

                Num2Text = "UN BILLON";

            }

            else if (value < 2000000000000)
            {

                Num2Text = "UN BILLON " + ToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            }

            else
            {

                Num2Text = ToText(Math.Truncate(value / 1000000000000)) + " BILLONES";

                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {

                    Num2Text = Num2Text + " " + ToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

                }

            }
        }

        public static string ConvertirNumeroALetrasEN(double cantidad, string postfijoMontoEnLetras)
        {
            string numb = cantidad.ToString();
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = postfijoMontoEnLetras;
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        //andStr = ("point");// just to separate whole numbers from points/Rupees
                        andStr = ("and");
                        pointStr = (Convert.ToInt32(points)).ToString() + "/00";

                    }
                }
                val = String.Format("{0} {1} {2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                ;
            }
            return val;
        }

        private static string translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };

                string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };

                string[] words2 = { "", "ten", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

                string[] words3 = { "Thousand ", "Lakh ", "Crore " };

                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = (Convert.ToInt32(number) > 0) ? words0[Convert.ToInt32(number)] : "";
                            isDone = true;
                            break;
                        case 2://tens' range
                            if (Convert.ToInt32(number) < 20)
                            {
                                word = words1[Convert.ToInt32(number) % 10];
                            }
                            else
                            {
                                word = words2[Convert.ToInt32(number) / 10] + words2[Convert.ToInt32(number) % 10];
                            }
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        public static string ConvertirNumeroALetrasEN(int number, string moneda, string postfijoMontoEnLetras)
        {
            if (number == 0) return "Zero";

            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();


            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }


            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ", "Five " ,"Six ", "Seven ", "Eight ", "Nine "};

            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};

            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ","Eighty ", "Ninety "};

            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }

            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;


                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens


                if (h > 0) sb.Append(words0[h] + "Hundred ");


                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");


                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }


                if (i != 0) sb.Append(words3[i - 1]);


            }
            return sb.ToString().TrimEnd();
        }

        #endregion

        #region Mes a Letra

        public static string NumberToMonthName(string numero)
        {
            string monthName = string.Empty;
            switch (numero)
            {
                case "01":
                    monthName = "ENERO";
                    break;
                case "02":
                    monthName = "FEBRERO";
                    break;
                case "03":
                    monthName = "MARZO";
                    break;
                case "04":
                    monthName = "ABRIL";
                    break;
                case "05":
                    monthName = "MAYO";
                    break;
                case "06":
                    monthName = "JUNIO";
                    break;
                case "07":
                    monthName = "JULIO";
                    break;
                case "08":
                    monthName = "AGOSTO";
                    break;
                case "09":
                    monthName = "SETIEMBRE";
                    break;
                case "10":
                    monthName = "OCTUBRE";
                    break;
                case "11":
                    monthName = "NOVIEMBRE";
                    break;
                case "12":
                    monthName = "DICIEMBRE";
                    break;
                default:
                    break;
            }
            return monthName;
        }

        #endregion
    }
}
