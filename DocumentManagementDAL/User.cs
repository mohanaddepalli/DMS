namespace DocumentManagementDAL
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("User")]
  public partial class User
  {
    public User()
    {
      Documents = new HashSet<Document>();
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    [StringLength(30)]
    public string FirstName { get; set; }

    [StringLength(30)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(30)]
    public string LastName { get; set; }

    [Required]
    [StringLength(11)]
    public string Password { get; set; }

    [Required]
    [StringLength(50)]
    public string LoginName { get; set; }

    public int StatusId { get; set; }

    public DateTime LastModifiedTimestamp { get; set; }

    public DateTime CreatedTimestamp { get; set; }

    public DateTime? date_last_login { get; set; }

    public virtual ICollection<Document> Documents { get; set; }

    public virtual Status Status { get; set; }
  }
}
