using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private List<Child> registry;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();//!!!!!!!!!!!!!!!!!
        }

        public string Name  { get; set; }
        public int Capacity  { get; set; }
        public List<Child> Registry  { get; set; }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveChild(string childFullName)
        {
            if (Registry.Any(c => (c.FirstName+' '+c.LastName) == childFullName))
            {
                Registry.RemoveAll(c => (c.FirstName + ' ' + c.LastName) == childFullName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            return Registry.Find(c => (c.FirstName + ' ' + c.LastName) == childFullName);
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");

            foreach (Child child in Registry.OrderByDescending(c => c.Age).ThenBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
