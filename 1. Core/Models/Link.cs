using Core.Abstractions;

namespace Core.Models
{
    public class Link : EntityBase
    {
        #region Properties

        public bool OpenNewWindow { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        #endregion Properties
    }
}