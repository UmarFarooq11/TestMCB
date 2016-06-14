using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1 : DictionaryBase
{
	public Class1()
	{
        
	}
    public void clstest()
    {
        string aID = "a1";
        string a = "Abdul Rauf";

        Dictionary.Add(aID, a);

        aID = "a2";
        a = "Abdul Rauf";
        Dictionary.Add(aID, a);

        aID = "a1";
        a = "Abdul Rauf";
        Dictionary.Add(aID, a);

    }
}
