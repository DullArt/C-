using System;

class Aula : IComparable
{
    private string titulo;
    private int tempo;

    public Aula(string titulo, int tempo)
    {
        this.titulo = titulo;
        this.tempo = tempo;
    }

    public string Titulo { get => titulo; set => titulo = value; }
    public int Tempo { get => tempo; set => tempo = value; }
    
    public int CompareTo(object obj)
    {
        var that = obj as Aula;
        return this.titulo.CompareTo(that.titulo);
    }

    public override string ToString()
    {
        return $"{this.titulo} {this.tempo}";
    }
}