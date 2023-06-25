using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GST_API_DAL.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "GSTIN Username cannot exceed 50 characters.")]
        [Display(Name = "GSTIN Username")]
        public string GSTINUsername { get; set; }

        [Required(ErrorMessage = "First Name is mandatory.")]
        [MaxLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is mandatory.")]
        [Display(Name = "Last Name")]
        [MaxLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "GSTIN No is mandatory.")]
        [StringLength(15, ErrorMessage = "GSTIN No cannot exceed 15 characters.")]
        [Display(Name = "GSTIN No")]
        [RegularExpression(@"\d{2}[A-Z]{5}\d{4}[A-Z]{1}[A-Z\d]{1}[Z\d]{1}[A-Z\d]{1}", ErrorMessage = "Not a valid GSTIN-No.")]
        public string GSTNNo { get; set; }

        [StringLength(100, ErrorMessage = "Organization name cannot exceed 100 characters.")]
        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Organization Name is mandatory.")]
        public string OrganizationName { get; set; }

        [StringLength(120, ErrorMessage = "Address cannot exceed 120 characters.")]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is mandatory.")]
        public string Address { get; set; }

        [StringLength(3)]
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is mandatory.")]
        public string StateCode { get; set; }

        public string LargeImageString { get; set; }
        public string CancelledChequeString { get; set; }
        [Required(ErrorMessage = "Pincode is mandatory.")]
        [StringLength(6, ErrorMessage = "Pincode cannot exceed 6 characters.")]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Pincode")]
        public string Pincode { get; set; }

        [StringLength(120, ErrorMessage = "Address 2 cannot exceed 120 characters.")]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [StringLength(50, ErrorMessage = "Place cannot exceed 50 characters.")]
        public string Place { get; set; }

        [MaxLength(10, ErrorMessage = "Organization PAN cannot exceed 10 characters.")]
        [Required(ErrorMessage = "Organization PAN is mandatory.")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        [Display(Name = "Organization PAN")]
        public string Organization_PAN { get; set; }
        public string verificationEmailLink { get; set; }
    }
}
