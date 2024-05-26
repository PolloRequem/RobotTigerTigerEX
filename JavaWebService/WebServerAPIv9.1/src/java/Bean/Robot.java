/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

/**
 *
 * @author Dante
 */
public class Robot {
    
    private String nome;
    private int serial;
    private int nPorte;
    private int nRuote;

    public Robot(String nome, int serial, int nPorte, int nRuote) {
        this.nome = nome;
        this.serial = serial;
        this.nPorte = nPorte;
        this.nRuote = nRuote;
    }

    public String getNome() {
        return nome;
    }

    public int getSerial() {
        return serial;
    }

    public int getnPorte() {
        return nPorte;
    }

    public int getnRuote() {
        return nRuote;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public void setSerial(int serial) {
        this.serial = serial;
    }

    public void setnPorte(int nPorte) {
        this.nPorte = nPorte;
    }

    public void setnRuote(int nRuote) {
        this.nRuote = nRuote;
    }

    @Override
    public String toString() {
        return "Robot{" + "nome=" + nome + ", serial=" + serial + ", nPorte=" + nPorte + ", nRuote=" + nRuote + '}';
    }

    
    
    
}
