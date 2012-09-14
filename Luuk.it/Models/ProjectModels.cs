using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace LuukitWebsite.Models
{
    public class ProjectsContext : DbContext
    {
        public ProjectsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
    }

    [Table("Project")]
    public class Project
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Designer { get; set; }
        [StringLength(4)]
        public string Year { get; set; }
        [StringLength(100)]
        public string Url { get; set; }
        [StringLength(100)]
        public string ProgrammingLanguage { get; set; }
        [StringLength(1000)]
        public string ShortDescription { get; set; }
        public int SortingOrder { get; set; }

        public virtual Collection<ProjectImage> Images { get; set; }
    }

    [Table("ProjectImage")]
    public class ProjectImage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        [StringLength(100)]
        public string Url { get; set; }
        public virtual Project Project { get; set; }
    }


    public class ProjectModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Designer")]
        public string Designer { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string Url { get; set; }

        [Required]
        [Display(Name = "Programming Language")]
        public string ProgrammingLanguage { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ShortDescription { get; set; }

        public string[] Images { get; set; }
    }
}
