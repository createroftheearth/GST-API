

using System.ComponentModel.DataAnnotations;

public class RegistrationModel
{
    [Required(ErrorMessage = "Password is mandatory.")]
    [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

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

    [StringLength(255, ErrorMessage = "Email cannot exceed 255 character.")]
    [Display(Name = "Email ID")]
    [Required(ErrorMessage = "Email ID is mandatory.")]
    [EmailAddress(ErrorMessage = "Not a valid EmailID")]
    public string Email { get; set; }

    [Display(Name = "Phone No")]
    [Required(ErrorMessage = "Phone No is mandatory.")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Username")]
    [MaxLength(50)]
    [Required(ErrorMessage = "Username is mandatory.")]
    [RegularExpression("^[a-z0-9_-]{3,15}$", ErrorMessage = "Username should be between 3 to 15 characters and it can contain (-) or (_) or lower Case alphanumeric keywords.")]
    public string Username { get; set; }

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

    [Required(ErrorMessage = "Pincode is mandatory.")]
    [StringLength(6, ErrorMessage = "Pincode cannot exceed 6 characters.")]
    [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Pincode")]
    public string Pincode { get; set; }

    [StringLength(120, ErrorMessage = "Address 2 cannot exceed 120 characters.")]
    [Display(Name = "Address 2")]
    public string Address2 { get; set; }

    [StringLength(50, ErrorMessage = "Place cannot exceed 50 characters.")]
    public string Place { get; set; }

    [Required(ErrorMessage = "Profile picture is mandatory.")]
    public string ProfilePicture { get; set; }
    [Required(ErrorMessage = "Cancelled Cheque is mandatory.")]
    [Display(Name = "Cancelled Cheque Picture")]
    public string CancelledChequePhoto { get; set; }

    [MaxLength(10, ErrorMessage = "Organization PAN cannot exceed 10 characters.")]
    [Required(ErrorMessage = "Organization PAN is mandatory.")]
    [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
    [Display(Name = "Organization PAN")]
    public string Organization_PAN { get; set; }
}

public class PublicRegistrationModel
{
    [Required(ErrorMessage = "Password is mandatory.")]
    [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "First Name is mandatory.")]
    [MaxLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is mandatory.")]
    [Display(Name = "Last Name")]
    [MaxLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    public string LastName { get; set; }

    [StringLength(255, ErrorMessage = "Email cannot exceed 255 character.")]
    [Display(Name = "Email ID")]
    [Required(ErrorMessage = "Email ID is mandatory.")]
    [EmailAddress(ErrorMessage = "Not a valid EmailID")]
    public string Email { get; set; }

    [Display(Name = "Phone No")]
    [Required(ErrorMessage = "Phone No is mandatory.")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Not a valid phone number")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Username")]
    [MaxLength(50)]
    [Required(ErrorMessage = "Username is mandatory.")]
    [RegularExpression("^[a-z0-9_-]{3,15}$", ErrorMessage = "Username should be between 3 to 15 characters and it can contain (-) or (_) or lower Case alphanumeric keywords.")]
    public string Username { get; set; }
}

