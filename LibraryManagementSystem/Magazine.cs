using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Magazine : LibraryItemBase
    {
        public override int Id { get; protected set; }
        public int IssueNumberl {  get; set; }
        public int Year { get; set; }
        public string Title { get; set; }

        public Magazine(string title, int year, int issueNumberl) : base(title, year)
        {
            Year = year;
            IssueNumberl = issueNumberl;
            Title = title;
        }
        public override string GetItemType()
        {
            return "Magazine";
        }
        public override string GetDisplayInfo()
        {
            return $"{Id}: {Title} — {IssueNumberl}";
        }
    }
}
