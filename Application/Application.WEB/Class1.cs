using System;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AntiYes.Helpers
{
    public static class CalendarExtensions
    {
        public static IHtmlString Calendar(this HtmlHelper helper, DateTime dateToShow)
        {
            DateTimeFormatInfo cinfo = DateTimeFormatInfo.CurrentInfo;
            StringBuilder sb = new StringBuilder();
            DateTime date = new DateTime(dateToShow.Year, dateToShow.Month, 1);
            int emptyCells = ((int)date.DayOfWeek + 7 - (int)cinfo.FirstDayOfWeek) % 7;
            int days = DateTime.DaysInMonth(dateToShow.Year, dateToShow.Month);
            sb.Append("<table class='cal'><tr><th colspan='7'>" + cinfo.MonthNames[date.Month - 1] + " " + dateToShow.Year + "</th></tr>");
            for (int i = 0; i < ((days + emptyCells) > 35 ? 42 : 35); i++)
            {
                if (i % 7 == 0)
                {
                    if (i > 0) sb.Append("</tr>");
                    sb.Append("<tr>");
                }

                if (i < emptyCells || i >= emptyCells + days)
                {
                    sb.Append("<td class='cal-empty'>&nbsp;</td>");
                }
                else
                {
                    sb.Append("<td class='cal-day'>" + date.Day + "</td>");
                    date = date.AddDays(1);
                }
            }
            sb.Append("</tr></table>");
            return helper.Raw(sb.ToString());
        }
    }
}


//db.Find(e=>e.Name =="...") или db.Find(e=>e.Name =="..." && e.Price > 100)


//    public IEnumerable<postdto> GetPostsByUserId(Guid? userId)
//{
//    if (userId == null)
//        throw new ValidationException("UserId parameter is null!", "userId");

//    var posts = DB.Posts.Find(x => x.User.Id == userId.Value);
//    if (posts == null)
//        throw new ValidationException("The posts not finded!", "");

//    Mapper.CreateMap < post, postdto = "" > ();
//    return Mapper.Map<ienumerable<post>, List<postdto>>(posts);
//}

/*классы - в DAL, всякие usermanagerы и rolmanagerы - в BLL, и формы авторизации и контроллеры, которые передают данные в BLL - а уровне представления*/
