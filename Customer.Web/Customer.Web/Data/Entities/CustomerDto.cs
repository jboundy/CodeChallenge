using System.ComponentModel.DataAnnotations;

namespace Customer.Web.Data.Entities
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [RegularExpression(@"^[\w\s-]*$"), Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [RegularExpression(@"^[\w\s-]*$"), Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
    }
}
