using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CSharpCollections;

class Curso
{
    private IDictionary<int, Aluno> dicionarioAlunos = new Dictionary<int, Aluno>();
    private ISet<Aluno> alunos = new HashSet<Aluno>();
    public IList<Aluno> Alunos
    {
        get
        {
            return new ReadOnlyCollection<Aluno>(alunos.ToList());
        }
    }

    private IList<Aula> aulas;
    public IList<Aula> Aulas
    {
        get
        {
            return new ReadOnlyCollection<Aula>(aulas);
        }
    }

    private string nome;

    internal void Adiciona(Aula aula)
    {
        this.aulas.Add(aula);
    }

    private string instrutor;

    public Curso(string nome, string instrutor)
    {
        this.nome = nome;
        this.instrutor = instrutor;
        this.aulas = new List<Aula>();
    }

    public string Nome { get => nome; set => nome = value; }
    public string Instrutor { get => instrutor; set => instrutor = value; }

    public int TempoTotal
    {
        get{
            // int total = 0;
            // foreach(var aula in aulas)
            // {
            //     total += aula.Tempo;
            // }

            // return total;

            return aulas.Sum(aula => aula.Tempo);
        }
    }


    public override string ToString()
    {
        return $"Curso: {nome}, Tempo: {TempoTotal}, Aulas: {string.Join(",",aulas)}"; 
    }

    public void Matricula(Aluno aluno)
    {
        this.alunos.Add(aluno);
        this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
    }

    public void SubstituiAluno(Aluno aluno,int numeroMatricula)
    {
        this.dicionarioAlunos[aluno.NumeroMatricula] = aluno;
    }

    public bool EstaMatriculado(Aluno aluno)
    {
        return alunos.Contains(aluno);
    }

    public Aluno BuscaMatriculado(int numeroMatricula)
    {
        // foreach(var aluno in alunos)
        // {
        //     if(aluno.NumeroMatricula == numeroMatricula)
        //         return aluno;
        // }
        //     throw new Exception("Matrícula não encontrada: "+numeroMatricula);
            
            //return this.dicionariAlunos[numeroMatricula];
            
            // Aluno aluno = null;
            this.dicionarioAlunos.TryGetValue(numeroMatricula, out Aluno aluno);
            return aluno;
    }

}