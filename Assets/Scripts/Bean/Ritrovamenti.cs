using System;

public class Ritrovamenti 
{

   public string missione { get; set; }
   public string materiale { get; set; }
   public string dataInzio { get; set; }
   public double parziali { get; set; }


    public string toString()
    {
        return "Ritrovamenti{" + "missione=" + missione + ", materiale=" + materiale + ", dataInzio=" + dataInzio + ", parziali=" + parziali + '}';
    }
}
