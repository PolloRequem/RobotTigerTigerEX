/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Bean;

import com.fasterxml.jackson.annotation.JsonProperty;
import java.util.Date;

/**
 *
 * @author Dante
 */
public class Mission {

    @JsonProperty("id")
    private String id;
    @JsonProperty("nome")
    private String nome;
    @JsonProperty("robot")
    private String robot;
    @JsonProperty("player")
    private String player;
    @JsonProperty("punteggio")
    private int punteggio;
    @JsonProperty("dataInizio")
    private String dataInizio;
    @JsonProperty("dataFine")
    private String dataFine;


    public Mission() {
    }

    
    
    
    
    public Mission(String id, int punteggio, String nome, String robot, String dataInizio, String dataFine, String player) {
        this.id = id;
        this.punteggio = punteggio;
    
        this.nome = nome;
        this.robot = robot;
        this.dataInizio = dataInizio;
        this.dataFine = dataFine;
        this.player = player;

    }

    public Mission(String id, int punteggio, String nome, String robot, String player, String dataInizio) {
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
        return "Mission{" + "id=" + id + ", nome=" + nome + ", robot=" + robot + ", player=" + player + ", punteggio=" + punteggio + ", dataInizio=" + dataInizio + ", dataFine=" + dataFine + '}';
    }

}
