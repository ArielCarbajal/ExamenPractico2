namespace Examen2.DB;

public record Items
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Descripcion { get; set; }
}

public class TiendaDB
{
    private static List<Items> _item = new List<Items>()
   {
     
   };

    public static List<Items> GetItems()
    {
        return _item;
    }

    public static Items? GetItem(int id)
    {
        return _item.SingleOrDefault(item => item.Id == id);
    }

    public static Items CreateItem(Items item)
    {
        _item.Add(item);
        return item;
    }

    public static Items UpdateItem(Items update)
    {
        _item = _item.Select(item =>
        {
            if (item.Id == update.Id)
            {
                item.Name = update.Name;
                item.Descripcion = update.Descripcion;
            }
            return item;
        }).ToList();
        return update;
    }

    public static void RemoveItem(int id)
    {
        _item = _item.FindAll(item => item.Id != id).ToList();
    }
}