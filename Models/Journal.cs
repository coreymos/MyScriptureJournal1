using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;


namespace MyScriptureJournal1.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string? Book { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string? Entry { get; set; }
    }
}
