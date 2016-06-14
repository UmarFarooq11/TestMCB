using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public static class Others
{
    public static void GridMouseOver(string T, GridViewRowEventArgs e)
    {
        if (T.ToString() == "ColorSchemeBrown")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D2B48C';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='LightGoldenrodYellow';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D2B48C';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='PaleGoldenrod';");
                }
            }
        }
        else if (T.ToString() == "ColorSchemeBlue")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#507CD1';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#EFF3FB';");                 
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#507CD1';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF';");
                }
            }
        }
        else if (T.ToString() == "ColorSchemeGreen")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#3BA395';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#E3EAEB';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#3BA395';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF';");
                }
            }
        }

        else if (T.ToString() == "ColorSchemePurple")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C1BAE1';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#C1BAE1';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#E7E7FF';");
                }
            }
        }


        else if (T.ToString() == "ColorSchemeSliver")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#828382';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#DEDFDE';");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#828382';this.style.ForeColor='black';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White';");
                }
            }
        }


    }
}
