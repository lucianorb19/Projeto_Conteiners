namespace ContainRs.Domain.Models;

public static class UfStringConverter
{
    //MÉTODO QUE CONVERTE UMA STRING PARA ENUM
    public static UnidadeFederativa? From(string? uf)
    {
        if (uf is null) return null;//SE A STRING FOR NULL, RETORNA NULL
        
        //SE NÃO CONSEGUIR CONVERTER, RETORNA NULL
        return Enum
            .TryParse<UnidadeFederativa>(uf, out var parsedUf) ? parsedUf : null;
    }
}

public enum UnidadeFederativa
{
    AC,
    AL,
    AP,
    AM,
    BA,
    CE,
    DF,
    ES,
    GO,
    MA,
    MT,
    MS,
    MG,
    PA,
    PB,
    PR,
    PE,
    PI,
    RJ,
    RN,
    RS,
    RO,
    RR,
    SC,
    SP,
    SE,
    TO
}
