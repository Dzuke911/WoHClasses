using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WoH_Data.Models
{
    [Table("TutorialProgress")]
    public class UserTutorialProgress
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("TutorialProgress")]
        public int Progress { get; set; }

        [Required]
        [Column("UserId")]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
    }
}
