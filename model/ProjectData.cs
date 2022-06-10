using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }
        public string State { get; set; }
        public bool GlobalCategory { get; set; }
        public string Visibility { get; set; }
        public string Description { get; set; }

        public ProjectData()
        {
        }
        public ProjectData(string name)
        {
            Name = name;
        }
        public ProjectData(string name, string state, bool category, string visibility, string description)
        {
            Name = name;
            State = state;
            GlobalCategory = category;
            Visibility = visibility;
            Description = description;
        }
        
        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name;
        }
        
        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
