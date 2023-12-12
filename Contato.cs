using System;
using System.Collections.Generic;

public class Contato
{
    // Attributes
    private string email;
    private string nome;
    private Data dtNasc;
    private List<Telefone> telefones;

    // Constructor
    public Contato(string email, string nome, Data dtNasc)
    {
        this.email = email;
        this.nome = nome;
        this.dtNasc = dtNasc;
        this.telefones = new List<Telefone>();
    }

    public int GetIdade()
    {
       
        return DateTime.Now.Year - dtNasc.Ano;
    }

    public void AdicionarTelefone(Telefone telefone)
    {
        telefones.Add(telefone);
    }

    
    public string GetTelefonePrincipal()
    {
        Telefone telefonePrincipal = telefones.Find(t => t.Principal);
        return telefonePrincipal != null ? telefonePrincipal.Numero : "Nenhum telefone principal";
    }

    
    public override string ToString()
    {
       
        return $"Email: {email}\nNome: {nome}\nData de Nascimento: {dtNasc}\nTelefone Principal: {GetTelefonePrincipal()}";
    }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Contato otherContato = (Contato)obj;
        return email == otherContato.email && nome == otherContato.nome && dtNasc.Equals(otherContato.dtNasc);
    }
}