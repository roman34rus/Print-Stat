namespace WebUI.Models.Shared
{
    public class DeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DeleteViewModel()
        { }

        public DeleteViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}