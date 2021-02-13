using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entries
{
    /// <summary>
    /// User notification type.
    /// Used on HangFire notification job execution.
    /// </summary>
    public class UserNotificationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public string Label { get; set; }
    }
}
