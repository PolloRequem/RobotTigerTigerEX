/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

/**
 *
 * @author Dante
 */
public class Ritrovamenti {
    
    
    private String missione;
    private String materiale;
    private String dataInzio;
    private double parziali;

    public Ritrovamenti() {
    }

    public Ritrovamenti(String missione, String materiale, String dataInzio, double parziali) {
        this.missione = missione;
        this.materiale = materiale;
        this.dataInzio = dataInzio;
        this.parziali = parziali;
    }

    
    public String getMissione() {
        return missione;
    }

    public String getMateriale() {
        return materiale;
    }

    public String getDataInzio() {
        return dataInzio;
    }

    public double getParziali() {
        return parziali;
    }

    public void setMissione(String missione) {
        this.missione = missione;
    }

    public void setMateriale(String materiale) {
        this.materiale = materiale;
    }

    public void setDataInzio(String dataInzio) {
        this.dataInzio = dataInzio;
    }

    public void setParziali(double parziali) {
        this.parziali = parziali;
    }

    @Override
    public String toString() {
        return "Ritrovamenti{" + "missione=" + missione + ", materiale=" + materiale + ", dataInzio=" + dataInzio + ", parziali=" + parziali + '}';
    }
    
    
}
