using System;
using System.Collections.Generic;
using System.Linq;
public interface IRepository<T> where T : class {
    IEnumerable<T> GetAll();
    void Add(T obj);
    T Get(int id);
    void Update(T obj);
    void Delete(int id);
}
public class Repository<T> : IRepository<T> where T : class
{
    private readonly Dictionary<int, T> storage = new();
    private int currId = 1;

    public void Add(T obj)
    {
        var idProperty = typeof(T).GetProperty("Id");
        idProperty?.SetValue(obj, currId);
        storage.Add(currId, obj);
        Console.WriteLine($"{typeof(T).Name} added");
        currId++;
    }

    public T Get(int id)
    {
        return storage.ContainsKey(id) ? storage[id] : null;
    }

    public void Update(T obj)
    {
            var idValue = (int)typeof(T).GetProperty("Id").GetValue(obj);
            if (storage.ContainsKey(idValue))
            {
                storage[idValue] = obj;
                Console.WriteLine($"{typeof(T).Name} updated.");
            }
            else
            {
                Console.WriteLine($"{typeof(T).Name} not found to update.");
            }
    }

    public void Delete(int id)
    {
        if (storage.Remove(id))
        {
            Console.WriteLine($"{typeof(T).Name} deleted.");
        }
        else
        {
            Console.WriteLine($"{typeof(T).Name} not found to delete.");
        }
    }

    public IEnumerable<T> GetAll()
    {
        return storage.Values;
    }
}

public class Program{
    public static void Main(String[] args){
        IRepository<Product> repo = new Repository<Product>();
        bool flag = true;

        while(flag){
            Console.Write("\n\nChoose number from the menu\n\t1. Add\n\t2. Get\n\t3. Update\n\t4. Delete\n\t5. List of Products\n\t6. Exit\n");
            int n = Convert.ToInt32(Console.ReadLine());
            switch(n){
                case 1:
                    Console.Write("\nEnter the product name : ");
                    string name = Console.ReadLine();
                    Console.Write("\nEnter the product price : ");
                    int price = Convert.ToInt32(Console.ReadLine());
                    Product p = new Product{ Name = name , Price = price};
                    repo.Add(p);
                    break;
                case 2:
                    Console.Write("\nEnter the Product Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Product temp = repo.Get(id);
                    if(temp!=null){
                        Console.Write($"\nProduct name : {temp.Name} Product price : {temp.Price}");
                    }
                    else{
                        Console.Write("Check the Id...There is no product with this id");
                    }
                    break;
                case 3:
                    Console.Write("\nEnter the product ID to Update : ");
                    int uId = Convert.ToInt32(Console.ReadLine());
                    Product up = repo.Get(uId);
                    if(up!=null){
                        Console.Write($"\nProduct name : {up.Name} Product price : {up.Price}");
                        Console.Write("\nEnter the product name(update) : ");
                        up.Name = Console.ReadLine();
                        Console.Write("\nEnter the product price(update) : ");
                        up.Price = Convert.ToInt32(Console.ReadLine());
                        repo.Update(up);
                    }
                    else{
                        Console.Write("Check the Id to update..There is no product with this id");
                    }
                    break;
                case 4:
                    Console.Write("\nEnter the product ID to Delete : ");
                    int dId = Convert.ToInt32(Console.ReadLine());
                    repo.Delete(dId);
                    break;
                case 5:
                    var items = repo.GetAll();
                    if(items != null){
                        foreach (var item in items)
                        {
                            Console.Write($"\nProduct name : {item.Name} Product price : {item.Price}");
                        }
                    }
                    else{
                        Console.Write("\nThere is no product try to add.");
                    }
                    break;
                case 6:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Choose the correct option from the menu");
                    break;
            }
        }
    }
}

public class Product{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public int Price{ get; set; }
}