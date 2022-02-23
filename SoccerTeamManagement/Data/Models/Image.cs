namespace SoccerTeamManagement.Data.Models
{
    public class Image : EntityBase
    {
        public string AlternativeText { get; set; }

        public Link Source { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public string Style { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }
    }
}