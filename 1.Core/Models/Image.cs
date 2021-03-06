using Core.Abstractions;

namespace Core.Models
{
    public class Image : EntityBase
    {
        #region Properties

        public string AlternativeText { get; set; }

        public string Url { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public string Style { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        //public FormFile File { get; set; }

        #endregion Properties
    }
}