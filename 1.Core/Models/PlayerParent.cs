namespace Core.Models
{
    public class PlayerParent
    {
        #region Relationships

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }

        #endregion Relationships
    }
}