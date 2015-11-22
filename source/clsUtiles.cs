using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AzuPassProfileMgr
{
	/// <summary>
	/// Summary description for clsUtiles
	/// </summary>
	public class clsUtiles
	{
		public clsUtiles()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region " ENUMERACIONES "

		public enum enuRoundBoxColor
		{
			Azul,
			Gris
		}
		#endregion " FIN DE ENUMERACIONES "

		public static string getRoundedItem(string itemHeader, string itemContent, enuRoundBoxColor Color )
		{
			string color = Color.ToString() == "Azul" ? "_a" : "_g";

			System.Diagnostics.Debug.WriteLine(itemHeader.Length);
			System.Text.StringBuilder sbResult = new System.Text.StringBuilder("");
			sbResult.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
			sbResult.Append("<tr>");
			sbResult.Append("<td colspan=\"2\" class=\"round_Header_Left" + color + "\"><font size=\"2px\" face=\"Verdana\">" + itemHeader + "</b></font></td>");
			sbResult.Append( "<td colspan=\"2\" class=\"round_Header_Center" + color + "\"></td>" );
			sbResult.Append( "<td class=\"round_clear" + color + "\"></td>" );
			sbResult.Append("</tr>");
			sbResult.Append("<tr>");
			sbResult.Append( "<td class=\"round_Content_Left" + color + "\"></td>" );
			sbResult.Append( "<td class=\"round_Content" + color + "\">" + itemContent + "</td>" );
			sbResult.Append( "<td class=\"round_Content_Center" + color + "\"></td>" );
			sbResult.Append( "<td class=\"round_Content_Right" + color + "\"></td>" );
			sbResult.Append("</tr>");
			sbResult.Append("<tr>");
			sbResult.Append( "<td class=\"round_Footer_Left" + color + "\"></td>" );
			sbResult.Append( "<td colspan=\"2\" class=\"round_Footer_Center" + color + "\"></td>" );
			sbResult.Append("<td class=\"round_clear\"></td>");
			sbResult.Append("</tr>");
			sbResult.Append("</table>");
			return sbResult.ToString();
		}

		public static string getDatePatern()
		{
      /*
      System.Diagnostics.Debug.WriteLine("System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern: " + System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern);
      System.Diagnostics.Debug.WriteLine("System.Globalization.DateTimeFormatInfo.CurrentInfo.LongDatePattern: " + System.Globalization.DateTimeFormatInfo.CurrentInfo.LongDatePattern);
      System.Diagnostics.Debug.WriteLine("System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthDayPattern: " + System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthDayPattern);
      */
      string DatePatern = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
			string[] DatePaternParts = DatePatern.Split( System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator.ToCharArray() );
			string result = string.Empty;
			for( int i = 0; i <= ( DatePaternParts.Length - 1 ); i++ )
			{
				// "\d{2}(/\d{2})(/\d{4})?"
				if(result.Length==0)
				{
					// \d{2}
					result = @"\d{" + DatePaternParts[i].Length + "}";;
					continue;
				}
				result += @"(" + System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator + @"\d{" + DatePaternParts[i].Length + "})"; ;
			}
			result += "?";

			return result;
		
		}

	} // Fin de la clase.

} // Fin del namespace.