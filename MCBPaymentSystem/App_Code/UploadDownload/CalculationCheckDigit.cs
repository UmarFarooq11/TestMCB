using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CalculationCheckDigit
/// </summary>
public class CalculationCheckDigit
{
    //EXAMPLE : 243BassiSA65432
	public CalculationCheckDigit()
	{

	}
    public string Con2(string STR)

        {

            string SP1 = "";

            int B = STR.Length;

            long P1 = 0;

            for (int A = 0; A <= STR.Length-1; A++)

            {

              P1 = P1 + Convert.ToInt16(STR.Substring(A, 1).ToString()) * B;

              B--;

            }

            P1 = P1 % 97;

            P1 = 97 - P1;

            return P1.ToString();

        }
    public string Con1(string STR)

        {

            STR = STR.ToUpper();
 

            STR = STR.Replace('A', '1');

            STR = STR.Replace('K', '1');

            STR = STR.Replace('U', '1');

 

            STR = STR.Replace('B', '2');

            STR = STR.Replace('L', '2');

            STR = STR.Replace('V', '2');

 

            STR = STR.Replace('C', '3');

            STR = STR.Replace('M', '3');

            STR = STR.Replace('W', '3');

 

            STR = STR.Replace('D', '4');

            STR = STR.Replace('N', '4');

            STR = STR.Replace('X', '4');

 

            STR = STR.Replace('E', '5');

            STR = STR.Replace('O', '5');

            STR = STR.Replace('Y', '5');

 

            STR = STR.Replace('F', '6');

            STR = STR.Replace('P', '6');

            STR = STR.Replace('Z', '6');

 

            STR = STR.Replace('G', '7');

            STR = STR.Replace('Q', '7');

 

            STR = STR.Replace('H', '8');

            STR = STR.Replace('R', '8');

 

            STR = STR.Replace('I', '9');

            STR = STR.Replace('S', '9');

 

            STR = STR.Replace('J', '0');

            STR = STR.Replace('T', '0');

 

            for (int A = 0; A <= STR.Length - 1; A++)

            {

                String S = STR.Substring(A, 1).ToString();

                if ((Convert.ToChar(S) >= 48) && (Convert.ToChar(S) <= 57))

                { }

                else

                { STR = STR.Replace(S, "0"); }

            }
            return  STR;
            //return  Con2(STR);

        }

}






     






