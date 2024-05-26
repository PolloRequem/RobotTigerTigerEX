/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

/**
 *
 * @author Dante
 */
public class Materiale {
    
    
    private int id;
    private String colore;
    private String descrizione;

    public Materiale(int id, String colore, String descrizione) {
        this.id = id;
        this.colore = colore;
        this.descrizione = descrizione;
    }

    public Materiale() {
    }

    public int getId() {
        return id;
    }

    public String getColore() {
        return colore;
    }

    public String getDescrizione() {
        return descrizione;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setColore(String colore) {
        this.colore = colore;
    }

    public void setDescrizione(String descrizione) {
        this.descrizione = descrizione;
    }

    @Override
    public String toString() {
        return "Materiale{" + "id=" + id + ", colore=" + colore + ", descrizione=" + descrizione + '}';
    }
    
    
}
