using System;
using System.Collections.Generic;

public class Contatos
{
    private List<Contato> agenda;

    public Contatos()
    {
        agenda = new List<Contato>();
    }


    public LERList<Contato> Agenda
    {
        get { return agenda.LERList(); }
    }

    
    public bool Adicionar(Contato contato)
    {
        
        if (!agenda.Exists(c => c.Equals(contato)))
        {
            agenda.Add(contato);
            return true;
        }
        else
        {
            Console.WriteLine("O contato já existe na agenda.");
            return false;
        }
    }

   
    public Contato Pesquisar(Contato contato)
    {
        return agenda.Find(c => c.Equals(contato));
    }

    public bool Alterar(Contato contato)
    {
        int index = agenda.FindIndex(c => c.Equals(contato));
        if (index != -1)
        {
            agenda[index] = contato;
            return true;
        }
        else
        {
            Console.WriteLine("Contato não encontrado para alteração.");
            return false;
        }
    }

    public bool Remover(Contato contato)
    {
        return agenda.Remove(contato);
    }

    
    public void ListarContatos()
    {
        Console.WriteLine("Lista de Contatos:");
        foreach (Contato contato in agenda)
        {
            Console.WriteLine(contato);
            Console.WriteLine("-------------");
        }
    }
}