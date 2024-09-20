namespace Domain.Entities
{
    public class Student
    {
        public Student(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;

    }
}
