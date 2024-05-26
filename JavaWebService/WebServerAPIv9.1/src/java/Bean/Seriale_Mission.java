/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

/**
 *
 * @author Dante
 */
public class Seriale_Mission {
    
    private int seriale;
    
    public Seriale_Mission(int seriale){
        
        this.seriale = seriale;
    }

    @Override
    public String toString() {
        return String.valueOf(seriale);
    }

    public int getSeriale() {
        return seriale;
    }

    public void setSeriale(int seriale) {
        this.seriale = seriale;
    }
    
    
}
