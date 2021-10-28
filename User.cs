using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_NET02_2
{
    public class User
    {
        public string Name { get; set; }
        public List<Window> Windows { get; set; }
        public bool IsCorrect()
        {
            if (Windows != null)
            {
                int countMainWindows = Windows.Where(w => w.Title == "main").Count();

                if (Windows.Count == 1 && Windows[0].IsAllSettings() || countMainWindows == 0)
                {
                    return true;
                }
            }
            
            return false;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Login: {Name}");

            if (Windows != null)
            {
                foreach (var window in Windows)
                {
                    str.Append("\n  " + window.ToString());
                }
            }

            return str.ToString();
        }
    }
}
