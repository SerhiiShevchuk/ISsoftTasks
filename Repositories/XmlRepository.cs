using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Task_NET02_2.Repositories
{
    class XmlRepository : IRepository
    {
        public List<User> LoadUsers()
        {
            XDocument xdoc = LoadFile();

            var c = xdoc.Element("config").Elements("login")
                    .Select(u => new User()
                    {
                        Name = u.Attribute("name").Value,
                        Windows = GetWindowsFromXWindows(u.Elements("window"))
                    });

            return c.ToList();
        }
        public void SaveUsers(List<User> users)
        {
            var xdoc = new XDocument(
                         new XElement("config",
                         users.Select(u => new XElement(
                             "login", new XAttribute("name", u.Name), GetXWindowsFromWindows(u.Windows)))));

            xdoc.Descendants().Where(e => e.IsEmpty && !e.HasAttributes).Remove();
            xdoc.Save(_path);
        }
        private XDocument LoadFile()
        {
            try
            {
                return XDocument.Load(_path);

            }
            catch (Exception)
            {
                Console.WriteLine($"{_path} was not found");
                return null;
            }
        }
        private List<XElement> GetXWindowsFromWindows(IEnumerable<Window> windows)
        {
            if (windows == null)
            {
                return null;
            }

            return new List<XElement>(windows.Select(w => 
                    new XElement("window", new XAttribute("title", w.Title),
                        new XElement("top", w.Top),
                        new XElement("left", w.Left),
                        new XElement("width", w.Width),
                        new XElement("height", w.Height))));
        }
        private List<Window> GetWindowsFromXWindows(IEnumerable<XElement> xWindows)
        {
            return xWindows.Select(w => new Window
            {
                Title = w.Attribute("title")?.Value,
                Width = GetPropFromXProp(w, "width"),
                Height = GetPropFromXProp(w, "height"),
                Left = GetPropFromXProp(w, "left"),
                Top = GetPropFromXProp(w, "top"),
            }).ToList();

            double? GetPropFromXProp(XElement e, string prop)
            {
                return string.IsNullOrEmpty(e.Attribute(prop)?.Value) ? null : double.Parse(e.Attribute(prop).Value);
            }
        }

        private string _path = @"..\..\..\Config\User`sWindowsSettings.xml";
    }
}
