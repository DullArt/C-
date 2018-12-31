using System;
using System.Diagnostics;
using System.Globalization;

class Date
{
    public void Dates()
    {
        DateTime data = new DateTime(2017, 9, 23);
        Debug.WriteLine(data.ToString("d"));
        Debug.WriteLine(data.ToString("d", new CultureInfo("pt-BR")));
        Debug.WriteLine(data.ToString("dd/MM"));
        
        Debug.WriteLine(new DateTime().Day);
        data = new DateTime(2017, 9, 23, 13, 14, 15, 987);
        
        Debug.WriteLine(data);
        Debug.WriteLine(data.ToString("HH:mm"));
        Debug.WriteLine(data.ToString("HH:mm:ss.fff"));

        Debug.WriteLine(data.ToString("D"));
        Debug.WriteLine(data.ToString("m"));
        Debug.WriteLine(data.ToString("Y"));

        Debug.WriteLine(data.ToString("G"));
        Debug.WriteLine(data.ToString("g"));
    }
}