namespace Backend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<ExpenseModel> Expenses { get; set; } = new List<ExpenseModel>();
        public bool isAdmin { get; set; } = false;
    }
}
