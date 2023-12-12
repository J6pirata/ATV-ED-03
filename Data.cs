public class Data
{

    private int dia;
    private int mes;
    private int ano;

    
    public Data()
    {
        
    }

    
    public void SetData(int dia, int mes, int ano)
    {
        
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    
    public override string ToString()
    {
        return $"{dia:D2}/{mes:D2}/{ano:D4}";
    }
}