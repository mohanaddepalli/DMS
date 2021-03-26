using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocumentManagementApp.Models
{
  public class DocumentModel
  {
    public int FileId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
  }
}