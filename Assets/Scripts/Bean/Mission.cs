
using System;
public class Mission
{

    public string id { get; set; }
    public string nome { get; set; }
    public string robot { get; set; }
    public string player { get; set; }
    public int punteggio { get; set; }
    public string dataInizio { get; set; }
    public string dataFine { get; set; }
    public bool completata { get; set; }


    public string toString()
    {
        return "Mission{" + "id=" + id + ", nome=" + nome + ", robot=" + robot + ", player=" + player + ", punteggio=" + punteggio + ", dataInizio=" + dataInizio + ", dataFine=" + dataFine + ", completata=" + completata + '}';
    }
}