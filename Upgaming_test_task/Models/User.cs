namespace Upgaming_test_task.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        public DateOnly CreateDate { get; set; }
    }
}
