namespace DocumentManagementDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DocumentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DocumentName { get; set; }

        [StringLength(10)]
        public string DocumentExtension { get; set; }

        [Required]
        public string DocumentPath { get; set; }

        public int StatusId { get; set; }

        public int UserId { get; set; }

        public DateTime LastModifiedTimestamp { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}
