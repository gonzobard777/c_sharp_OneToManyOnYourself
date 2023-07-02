namespace Domain.Entities;

public class Component
{
    public int Id { get; set; }
    public string Name { get; set; }

    /*
     * One Component - to - Many Components
     */
    public int? ParentId { get; set; }
    public Component? Parent { get; set; }
    public ICollection<Component> Children { get; set; }
}