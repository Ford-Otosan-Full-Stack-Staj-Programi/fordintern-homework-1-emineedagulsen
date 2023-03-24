using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FordApi.Data;
//Databasede kullanacağım (entity yapısı) create etmem gerek
[Table("STAFF")]
public class Staff
{
    [Required(ErrorMessage = "The ID is required")]
    [Column("ID")]
    public int Id { get; set; }

    [Required(ErrorMessage = "The creater is required")]
    [Column("CREATEDBY")]
    public string? CreatedBy { get; set; }

    [Column("CREATEDAT")]
    public DateTime CreatedAt { get; set; } //Fluent

    [Required(ErrorMessage = "First name is required")]
    [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
    [Column("FIRSTNAME")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [Column("LASTNAME")]
    public string? LastName { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; } //fluent

    [Column("PHONE")]
    public string? Phone { get; set; } //fluent

    [Required(ErrorMessage = "The Address is required")]
    [Column("ADDRESSLINE1")]
    public string? AddressLine1 { get; set; }

    [Column("DATEOFBIRTH")]
    public DateTime DateOfBirth { get; set; }//fluent

    [Required(ErrorMessage = " City name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The maximum length of city can be  50 and the minumum length  can be 2 !!")]
    [Column("CITY")]
    public string? City { get; set; }

    [Required(ErrorMessage = " Country name is required")]
    [Column("COUNTRY")]
    public string? Country { get; set; }

    [Required(ErrorMessage = " Province name is required")]
    [Column("PROVINCE")]
    public string? Province { get; set; }

    [NotMapped]
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}