using Handy.DotNETCoreCompatibility.ColourTranslations;
using System.Collections.Generic;
using System.Drawing;

namespace GetOrganized.Models.Domain
{
    public class Topic
    {

        public static List<Topic> topics = new List<Topic>() {
            new Topic{ Id = 1 ,  Name = "Work"},
            new Topic{ Id = 2 ,  Name = "Work 2"},
        };

        public virtual int Id { get; set; }
        //public Color Color { get; set; }
        public virtual string Name { get; set; }

        public override bool Equals(object obj)
        {
            var topic = obj as Topic;
            return topic != null &&
                   Id == topic.Id &&
                   //Color.Equals(topic.Color) &&
                   Name == topic.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1369090114;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            //hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(Color);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public virtual string ColorInWebHex()
        {
            return "#D00000";
        }
    }
}
