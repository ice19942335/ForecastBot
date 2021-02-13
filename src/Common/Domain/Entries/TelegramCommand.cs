using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entries
{
    public class TelegramCommand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public string CommandName { get; set; }
    }
}
