using System;
using System.Collections;
class Program{
    static void Main (){
        List<string> names = new List<string>();
        bool flag = true;
        while(flag){
            int n;
            Console.Write("Select option\n1.Add\n2.Remove\n3.Show\n4.Exit\n");
            n = Convert.ToInt32(Console.ReadLine());
            switch(n){
                case 1:
                    Console.Write("Enter the name to add : ");
                    names.Add(Console.ReadLine().ToUpper().Trim());
                    break;
                case 2:
                    Console.Write("Enter the name to remove : ");
                    string rmv = Console.ReadLine().ToUpper().Trim();
                    if(names.Contains(rmv)){
                        names.Remove(rmv);
                        Console.WriteLine($"{rmv} removed from List");
                    }
                    else{
                        Console.WriteLine($"There is no name like {rmv}");
                    }
                    break;
                case 3:
                    if(names.Count>0){
                      Console.WriteLine("Here are the names ");
                        for(int i=0;i<names.Count;i++){
                            Console.WriteLine($"{i+1}.{names[i]}");
                        }
                    }
                    else{
                        Console.WriteLine("There is no names in the list");
                    }
                    break;
                case 4:
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Enter Proper Menu options");
                    break;
            }
        }
    }
}