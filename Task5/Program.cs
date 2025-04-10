using System;
using System.IO;

class Program{
    static void Main(){
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        try{
            if(!File.Exists(inputFile)){
                throw new FileNotFoundException("There is no file like this");
            }
            string[] lines = File.ReadAllLines(inputFile);
            int lineCount = lines.Length;
            int wordCount = 0;

            foreach(string line in lines){
                string[] words = line.Split(" ");
                wordCount+=words.Length;
            }
            
            using(StreamWriter w = new StreamWriter(outputFile)){
                w.WriteLine("Text from \"input.txt\" file\n");
                w.WriteLine(File.ReadAllText(inputFile));
                w.WriteLine($"Line count : {lineCount}");
                w.WriteLine($"Word count : {wordCount}");
            }

            // Only used for quick writing
            // File.WriteAllText(outputFile,Convert.ToString(lineCount));
            Console.WriteLine("Process completed...Check for \"output.txt\"");
        }
        catch(FileNotFoundException e){
            Console.WriteLine(e);
        }
        catch(IOException e){
            Console.WriteLine(e);
        }
        catch(Exception e){
            Console.WriteLine(e);
        }
    }
}