namespace DocumentManagementDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status
    {
        public Status()
        {
            Documents = new HashSet<Document>();
            Users = new HashSet<User>();
        }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusId { get; set; }

        [Required]
        [StringLength(30)]
        public string StatusName { get; set; }

        public DateTime LastModifiedTimestamp { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
