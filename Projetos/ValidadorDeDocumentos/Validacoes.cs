using System;
using System.Diagnostics;
using Caelum.Stella.CSharp.Format;
using Caelum.Stella.CSharp.Validation;

class Validacoes
{
     public void Validacao()
     {
        //Caelum.Stella.CSharp
            string cpf1 = "86288366757";
            string cpf2 = "98745366797";
            string cpf3 = "22222222222";

            ValidarCPF(cpf1);
            ValidarCPF(cpf2);
            ValidarCPF(cpf3);

            string cnpj1 = "51241758000152";
            string cnpj2 = "14128481000120";

            ValidarCNPJ(cnpj1);
            ValidarCNPJ(cnpj2);

            string titulo1 = "041372570132";
            string titulo2 = "774387480132";

            ValidarTitulo(titulo1);
            ValidarTitulo(titulo2);

            string v = new CPFFormatter().Format(cpf1);
            Debug.WriteLine(v);
            
            string un = new CPFFormatter().Unformat(v);
            Debug.WriteLine(un);
            
            //format cnpj
            Debug.WriteLine(new CNPJFormatter().Format(cnpj1));
            //format titulo
            Debug.WriteLine(new TituloEleitoralFormatter().Format(titulo1));

            Console.ReadLine();
    }

        private static void ValidarTitulo(string titulo)
        {
            if (new TituloEleitoralValidator().IsValid(titulo))
            {
                Debug.WriteLine("Título inválido");
            }
            else
            {
                Debug.WriteLine("Título não é válido");
            }
        }

        private static void ValidarCNPJ(string cnpj)
        {
            if (new CNPJValidator().IsValid(cnpj))
            {
                Debug.WriteLine("CNPJ is valid");
            }
            else
            {
                Debug.WriteLine("CNPJ is not valid");
            }
        }

        private static void ValidarCPF(string cpf)
        {
            try
            {
                new CPFValidator().AssertValid(cpf);
                Debug.WriteLine("Cpf válido");
            }
            catch (Exception e)
            {
                Debug.WriteLine("CPF inválido "+e.Message);
            }
        }

        private static void ValidarCPFBool(string cpf)
        {
            if(new CPFValidator().IsValid(cpf))
            {
                Debug.WriteLine("Cpf é válido");
            }
            else
            {
                Debug.WriteLine("CPF inválido");
            }
        }
}