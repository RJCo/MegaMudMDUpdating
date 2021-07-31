
namespace Records
{
    public interface IRecord
    {
        string ToString();
        int ID { get; set; }
        string Name { get; set; }
    }
}
