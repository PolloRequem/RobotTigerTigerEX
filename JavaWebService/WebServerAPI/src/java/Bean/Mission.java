/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

import java.util.Date;

/**
 *
 * @author Dante
 */
public class Mission {

    private String id;
    private String nome;
    private String robot;
    private String player;
    private int punteggio;
    private String dataInizio;
    private String dataFine;
    private boolean completata;  
   
    

    public Mission(String id, int punteggio, boolean completata, String nome, String robot, String dataInizio, String dataFine ,String player) {
        this.id = id;
        this.punteggio = punteggio;
        this.completata = completata;
        this.nome = nome;
        this.robot = robot;
        this.dataInizio = dataInizio;
        this.dataFine = dataFine;
        this.player = player;
        
    }
    
    public Mission(String id, int punteggio, String nome, String robot,String player, String dataInizio  ) {
        this.id = id;
        this.nome = nome;
        this.robot = robot;
         this.player = player;
        this.dataInizio = dataInizio;
       
      
    }

    public String getId() {
        return id;
    }

    public int getPunteggio() {
        return punteggio;
    }

    public boolean isCompletata() {
        return completata;
    }

    public String getNome() {
        return nome;
    }

    public String getRobot() {
        return robot;
    }

    public String getDataInizio() {
        return dataInizio;
    }

    public String getDataFine() {
        return dataFine;
    }

    public void setId(String id) {
        this.id = id;
    }

    public void setPunteggio(int punteggio) {
        this.punteggio = punteggio;
    }

    public void setCompletata(boolean completata) {
        this.completata = completata;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public void setRobot(String robot) {
        this.robot = robot;
    }

    public void setDataInizio(String dataInizio) {
        this.dataInizio = dataInizio;
    }

    public void setDataFine(String dataFine) {
        this.dataFine = dataFine;
    }

    public String getPlayer() {
        return player;
    }

    public void setPlayer(String player) {
        this.player = player;
    }

    @Override
    public String toString() {
        return "Mission{" + "id=" + id + ", nome=" + nome + ", robot=" + robot + ", player=" + player + ", punteggio=" + punteggio + ", dataInizio=" + dataInizio + ", dataFine=" + dataFine + ", completata=" + completata + '}';
    }

    
    
    
  

  
   
    

    
    
}
