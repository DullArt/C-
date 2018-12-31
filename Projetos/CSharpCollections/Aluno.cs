class Aluno
{
    private string nome;
    public string Nome
    {
        get { return nome;}
        set { nome =value;}
    }

    private int numeroMatricula;
   
    public Aluno(string v1, int v2)
    {
        this.nome = v1;
        this.numeroMatricula = v2;
    }

    public int NumeroMatricula
    {
        get { return numeroMatricula;}
        set { numeroMatricula= value;}
    }    

    public override string ToString()
    {
        return $"Nome: {nome}, Matrícula: {numeroMatricula}]";
    }

    public override bool Equals(object obj)
    {
        Aluno outro = obj as Aluno;
        if(outro == null)
        {
            return false;
        }
        return this.nome.Equals(outro.nome);
    }

    public override int GetHashCode()
    {
        return this.nome.GetHashCode();
    }

}    