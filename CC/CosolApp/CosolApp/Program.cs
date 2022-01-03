using System;

public class Student
{
    private int _id;
    private string _Name;
    //private int _Mark=1000;

    public int id
    {
        set
        {
            if (value <= 0)
            {
                throw new Exception("Error");
            }
            this._id = value;
        }
        get
        {
            return this._id;
        }
    }
    public string Name
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                this._Name = "No Name";
            }
            this._Name = value;
        }
        get
        {
            if (string.IsNullOrEmpty(this._Name))
            {
                this._Name = "No Name";
            }
            return this._Name;
        }
    }

    public int Markk { set; get; }
}
class Program
{
    static void Main(string[] args)
    {
        Student s = new Student();
        s.id = 101;
        s.Name = null;
        s.Markk = 1000;
        Console.WriteLine("Hello World! = {0} AND Name is {1} And His Mark is {2}", s.id, s.Name, s.Markk);
        Console.WriteLine("Hello World! = {0}", s.Name);
    }
}
  
