﻿namespace GestioneSagre.Models.Entities;

public class Versione
{
    public int Id { get; private set; }
    public string CodiceVersione { get; private set; } = string.Empty;
    public string TestoVersione { get; private set; } = string.Empty;
    public VersioneStato VersioneStato { get; private set; }

    public void ChangeCodiceVersione(string codiceVersione)
    {
        CodiceVersione = codiceVersione;
    }

    public void ChangeTestoVersione(string testoVersione)
    {
        TestoVersione = testoVersione;
    }

    public void ChangeVersioneStato(VersioneStato versioneStato)
    {
        VersioneStato = versioneStato;
    }
}
