namespace Domain.Base.Interfaces
{
    /// <summary>
    /// Base entity.
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Entity Id in Database.
        /// </summary>
        string Id { get; set; }
    }
}
